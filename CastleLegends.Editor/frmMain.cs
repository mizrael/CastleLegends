using System;
using System.Drawing;
using System.Windows.Forms;
using CastleLegends.Editor.Extensions;
using CastleLegends.Editor.Services;
using CastleLegends.Editor.UserControls;
using CastleLegends.Common;

namespace CastleLegends.Editor
{
    public partial class frmMain : Form
    {
        #region Members

        private ucMapRenderer _mapRenderer;
        private HexMap _mapData;

        private frmSelectTile _frmSelTile = null;

        #endregion Members

        public frmMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmMain_Load);
         
            this.ResizeEnd += new EventHandler(frmMain_ResizeEnd);
            this.MaximizedBoundsChanged += new EventHandler(frmMain_MaximizedBoundsChanged);
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }        

        #region Form Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            _frmSelTile = new frmSelectTile();
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

            this.TilesetsList.Items.Add(frm.TileSet);
        }

        private void TilesetsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currTileset = this.TilesetsList.SelectedItem as Tileset;
            _frmSelTile.SetTileset(currTileset);
        }

        #endregion Form Events

        #region Menu Events

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
                _mapRenderer.DrawDebugLines = drawDebugLinesToolStripMenuItem.Checked;
        }

        private void SelectTileMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if(this.selectTileMenuItem.Checked)
                _frmSelTile.Show();
            else
                _frmSelTile.Hide();
        }

        #endregion Menu Events

        #region Private Methods

        private void NewMap()
        {
            CloseMap();

            var frm = new frmNewMap();
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            _mapData = new HexMap(frm.HexMapType, frm.HexTileType, frm.TileCountX, frm.TileCountY, frm.TileRadius);
            
            this.drawDebugLinesToolStripMenuItem.Enabled = true;
            this.drawDebugLinesToolStripMenuItem.Checked = false;

            this.selectTileMenuItem.Enabled = true;
            this.selectTileMenuItem.Checked = false;

            this.tabTools.Enabled = true;

            InitRenderer();         
        }

        private void CloseMap()
        {
            this.selectTileMenuItem.Enabled = false;
            this.drawDebugLinesToolStripMenuItem.Enabled = false;
            this.tabTools.Enabled = false;

            this.rendererContainer.SetRenderer(null);
        }

        private void InitRenderer()
        {
            _mapRenderer = new ucMapRenderer(_mapData);
            _mapRenderer.Dock = DockStyle.Fill;
            _mapRenderer.Location = new Point(0, 0);
            _mapRenderer.TabIndex = 0;

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
