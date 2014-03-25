using System;
using System.Drawing;
using System.Windows.Forms;
using CastleLegends.Common;
using CastleLegends.Editor.RenderModels;
using CastleLegends.Editor.UserControls;
using CastleLegends.Editor.ViewModels;

namespace CastleLegends.Editor
{
    public partial class frmMain : Form
    {
        #region Members

        private ucMapRenderer _mapRenderer;
        private HexMap _mapData;

        private frmSelectTile _frmSelTile = null;
        private frmTools _frmTools = null;
        private frmProperties _frmProperties = null;

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

            _frmProperties = new frmProperties();
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
            var currTileset = this.lbTilesets.SelectedItem as TilesetViewModel;
            _frmSelTile.SetTileset(currTileset);
        }

        private void TilesetsList_MouseDoubleClick(object sender, MouseEventArgs e)
        {            
            this.selectTileMenuItem.Checked = true;
            ToggleForm(_frmSelTile, this.selectTileMenuItem.Checked);
        }
        
    /*    private void tabInfoPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            var tile = this.tabInfoPropertyGrid.SelectedObject as TileViewModel;
            if (null == tile)
                return;       
        }*/

        #endregion Form Events       

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
                var currTile = currLayer.Tiles[data.TileIndexX, data.TileIndexY]; 
                
                var propData = (null == currTile) ? null : new TileViewModel(currTile, _mapData);
                _frmProperties.SetObject(propData);                
                
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
                else if (_frmTools.SelectedTool == frmTools.Tools.RemoveTileTexture)
                {
                    var tileIndex = new Microsoft.Xna.Framework.Point(data.TileIndexX, data.TileIndexY);
                    var command = new Commands.RemoveTileTextureCommand(currLayer, tileIndex);
                    Commands.CommandManager.AddAndExecute(command);
                }
            }
            else {
                _frmProperties.SetObject(null);
            }
        }

        #endregion Map Renderer Events
               
        #region Private Methods

        private void ToggleForm(Form form, bool show)
        {
            if (show)
            {
                form.Show();
                form.BringToFront();
            }
            else
                form.Hide();
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

            this.propertiesToolStripMenuItem.Enabled = true;
            this.propertiesToolStripMenuItem.Checked = false;

            this.saveToolStripMenuItem.Enabled = true;
            this.closeToolStripMenuItem.Enabled = true;

            this.btnMapLayerDown.Enabled = false;
            this.btnMapLayerUp.Enabled = false;

            this.tabTools.Enabled = true;
        }

        private void CloseMap()
        {
            this.lbTilesets.Items.Clear();
            this.chklMapLayers.Items.Clear();

            this.toolsToolStripMenuItem.Enabled = false;
            this.propertiesToolStripMenuItem.Enabled = false;
            this.selectTileMenuItem.Enabled = false;
            this.drawDebugLinesToolStripMenuItem.Enabled = false;
            this.drawHexagonsToolStripMenuItem.Enabled = false;
            this.tabTools.Enabled = false;
            
            this.saveToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Enabled = false;
            
            this.rendererContainer.SetRenderer(null);

            _frmProperties.SetObject(null);
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
