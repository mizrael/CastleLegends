﻿using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using CastleLegends.Editor.Extensions;
using CastleLegends.Editor.Services;
using CastleLegends.Editor.UserControls;
using CastleLegends.Common;
using CastleLegends.Common.RenderModels;

namespace CastleLegends.Editor
{
    public partial class frmMain : Form
    {
        #region Members

        private ucMapRenderer _mapRenderer;
        private HexMap _mapData;

        private frmSelectTile _frmSelTile = null;
        private frmTools _frmTools = null;

        #endregion Members

        public frmMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmMain_Load);
         
            this.ResizeEnd += new EventHandler(frmMain_ResizeEnd);
            this.MaximizedBoundsChanged += new EventHandler(frmMain_MaximizedBoundsChanged);
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);

            Commands.CommandManager.CommandsUndo += new Commands.CommandManager.CommandEventHandler(CommandManager_CommandsUndo);    
            Commands.CommandManager.CommandsExecuted += new Commands.CommandManager.CommandEventHandler(CommandManager_CommandsExecuted);
        }

        #region Command Manager Events

        private void CommandManager_CommandsExecuted(Commands.CommandEventArgs data)
        {
            this.undoToolStripMenuItem.Enabled = true;
        }

        private void CommandManager_CommandsUndo(Commands.CommandEventArgs data)
        {
            this.redoToolStripMenuItem.Enabled = true;
        }

        #endregion Command Manager Events

        #region Form Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            _frmSelTile = new frmSelectTile();
            _frmSelTile.TileSelectionChange += new frmSelectTile.TileSelectionChangeHandler(_frmSelTile_TileSelectionChange);
          
            _frmTools = new frmTools();          
        }

        private void _frmTools_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.toolsToolStripMenuItem.Checked = false;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            SetScrollbars();
        }

        private void frmMain_MaximizedBoundsChanged(object sender, EventArgs e)
        {
            SetScrollbars();
        }

        private void pnlMain_SizeChanged(object sender, EventArgs e)
        {
            SetScrollbars();
        }

        private void btnAddTileset_Click(object sender, EventArgs e)
        {
            var frm = new frmImportTileset();
            var result = frm.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            this.lbTilesets.Items.Add(frm.TileSet);
        }

        private void TilesetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currTileset = this.lbTilesets.SelectedItem as TilesetRenderModel;
            _frmSelTile.SetTileset(currTileset);
        }

        private void TilesetsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //_frmSelTile.Visible = true;            
            this.selectTileMenuItem.Checked = true;
        }

        private void btnAddMapLayer_Click(object sender, EventArgs e)
        {
            AddMapLayer();
        }
        
        #endregion Form Events

        #region Menu Events
        
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == _mapData) return;

            var sfd = new SaveFileDialog();
            sfd.RestoreDirectory = false;
            sfd.Title = "Save Map";
            sfd.DefaultExt = ".xml";
            var result = sfd.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            var repo = new CastleLegends.Common.Persistence.HexMapRepository();
            repo.Save(_mapData, sfd.FileName);
        }
        
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMap();

            var ofd = new OpenFileDialog();
            ofd.Title = "Open Map"; 
            ofd.DefaultExt = ".xml";
            var result = ofd.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;
            
            var repo = new CastleLegends.Common.Persistence.HexMapRepository();
            _mapData = repo.Load(ofd.FileName);
            if (null != _mapData)
            {
                ResetUIForNewMap();

                InitRenderer();

                var tilesets = _mapData.GetTilesets();
                if (null != tilesets && tilesets.Any()) {
                    foreach (var tileset in tilesets) {
                        var vm = TilesetFactory.Get(tileset, _mapRenderer.GraphicsDevice);
                        this.lbTilesets.Items.Add(vm);
                    }
                }

                if (null != _mapData.Layers && _mapData.Layers.Any())
                {
                    this.chklMapLayers.Items.AddRange(_mapData.Layers.ToArray());
                    for (int i = 0; i != _mapData.Layers.Count; ++i)
                        this.chklMapLayers.SetItemChecked(i, true);
                }
                
            }
        }
        
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMap();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMap();
        }

        private void drawDebugLinesToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (null != _mapRenderer)
                _mapRenderer.CanDrawDebugLines = drawDebugLinesToolStripMenuItem.Checked;
        }

        private void drawHexagonsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (null != _mapRenderer)
                _mapRenderer.CanDrawHexagons = this.drawHexagonsToolStripMenuItem.Checked;
        }

        private void SelectTileMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.selectTileMenuItem.Checked)
            {
                _frmSelTile.Show();
                _frmSelTile.BringToFront();
            }
            else
                _frmSelTile.Hide();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolsToolStripMenuItem.Checked)
            {
                _frmTools.Show();
                _frmTools.BringToFront();
            }
            else
                _frmTools.Hide();
        }
        
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commands.CommandManager.UndoCommand();
            this.undoToolStripMenuItem.Enabled = (0 != Commands.CommandManager.UndoCount);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commands.CommandManager.ExecuteCommand();
            this.redoToolStripMenuItem.Enabled = (0 != Commands.CommandManager.Count);
        }

        #endregion Menu Events

        #region Tileset Selection Form Events

        private void _frmSelTile_TileSelectionChange(object sender, TileSelectionEventArgs data)
        {
            if (null == _mapData)
                return;
        }

        #endregion Tileset Selection Form Events

        #region Map Renderer Events

        private void _mapRenderer_MapTileSelected(object sender, MapTileSelectedEventArgs data)
        {
            var currLayer = GetCurrentLayer();

            if (null != data && null != currLayer)
            {
                this.tabInfoPropertyGrid.Enabled = true;
                this.tabInfoPropertyGrid.SelectedObject = currLayer.Tiles[data.TileIndexX, data.TileIndexY];
                
                if (_frmTools.SelectedTool == frmTools.Tools.SetTileTexture && _frmSelTile.SelectedTileIndex.HasValue)
                {
                    var tilesetSelectedTileIndex = _frmSelTile.SelectedTileIndex.Value;

                    var tileIndex = new Microsoft.Xna.Framework.Point(data.TileIndexX, data.TileIndexY);

                    var texBounds = new Microsoft.Xna.Framework.Rectangle()
                    {
                        X = tilesetSelectedTileIndex.X * _frmSelTile.TileSet.Tileset.TileWidth,
                        Y = tilesetSelectedTileIndex.Y * _frmSelTile.TileSet.Tileset.TileHeight,
                        Width = _frmSelTile.TileSet.Tileset.TileWidth,
                        Height = _frmSelTile.TileSet.Tileset.TileHeight
                    };

                    var command = new Commands.SetTileTextureCommand(currLayer, tileIndex, _frmSelTile.TileSet.Tileset, texBounds);
                    Commands.CommandManager.AddAndExecute(command);
                }
            }
            else {
                this.tabInfoPropertyGrid.Enabled = false;
                this.tabInfoPropertyGrid.SelectedObject = null;
            }
        }

        #endregion Map Renderer Events
        
        #region Map Layers Tab events

        private void chklMapLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var layer = this.chklMapLayers.Items[e.Index] as MapLayer;
            if (null == layer)
                return;

            layer.Visible = (e.NewValue == CheckState.Checked);
        }

        #endregion Map Layers Tab events

        #region Private Methods

        private MapLayer GetCurrentLayer()
        {
            var selLayer = this.chklMapLayers.SelectedItem as MapLayer;
            return selLayer ?? _mapData.Layers.FirstOrDefault();
        }

        private void AddMapLayer()
        {
            var name = "Layer " + (_mapData.Layers.Count + 1).ToString();

            var newLayer = new MapLayer(_mapData.TilesCountX, _mapData.TilesCountY, name);
            _mapData.Layers.Add(newLayer);

            this.chklMapLayers.Items.Add(newLayer, true);
            this.chklMapLayers.SelectedIndex = this.chklMapLayers.Items.Count - 1;
        }

        private void NewMap()
        {
            CloseMap();

            var frm = new frmNewMap();
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            _mapData = new HexMap(frm.HexMapType, frm.HexTileType, frm.TileCountX, frm.TileCountY, frm.TileRadius);

            AddMapLayer();

            ResetUIForNewMap();

            InitRenderer();         
        }

        private void ResetUIForNewMap()
        {
            this.drawDebugLinesToolStripMenuItem.Enabled = true;
            this.drawDebugLinesToolStripMenuItem.Checked = false;

            this.drawHexagonsToolStripMenuItem.Enabled = true;
            this.drawHexagonsToolStripMenuItem.Checked = true;

            this.selectTileMenuItem.Enabled = true;
            this.selectTileMenuItem.Checked = false;

            this.toolsToolStripMenuItem.Enabled = true;
            this.toolsToolStripMenuItem.Checked = false;

            this.saveToolStripMenuItem.Enabled = true;
            this.closeToolStripMenuItem.Enabled = true;

            this.tabTools.Enabled = true;
        }

        private void CloseMap()
        {
            this.lbTilesets.Items.Clear();
            this.chklMapLayers.Items.Clear();

            this.tabInfoPropertyGrid.Enabled = false;
            this.tabInfoPropertyGrid.SelectedObject = null;

            this.toolsToolStripMenuItem.Enabled = false;
            this.selectTileMenuItem.Enabled = false;
            this.drawDebugLinesToolStripMenuItem.Enabled = false;
            this.drawHexagonsToolStripMenuItem.Enabled = false;
            this.tabTools.Enabled = false;
            
            this.saveToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Enabled = false;
            
            this.rendererContainer.SetRenderer(null);
        }

        private void InitRenderer()
        {
            _mapRenderer = new ucMapRenderer(_mapData);
            _mapRenderer.Dock = DockStyle.Fill;
            _mapRenderer.Location = new Point(0, 0);
            _mapRenderer.TabIndex = 0;
            _mapRenderer.MapTileSelected += new ucMapRenderer.MapTileSelectedEventHandler(_mapRenderer_MapTileSelected);

            this.rendererContainer.SetRenderer(_mapRenderer);

            SetScrollbars();
        }

        private void SetScrollbars()
        {
            if (null == _mapData) return;

            var hMax = (int)_mapData.MapWidth - this.rendererContainer.Width;
            var vMax = (int)_mapData.MapHeight - this.rendererContainer.Height;

            this.rendererContainer.SetScrollbars(vMax, hMax);
        }

        #endregion Private Methods

    }
}
