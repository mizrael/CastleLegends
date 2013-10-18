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

        #endregion Members

        public frmMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmMain_Load);
            this.ResizeEnd += new EventHandler(frmMain_ResizeEnd);
            this.FormClosing += new FormClosingEventHandler(frmMain_FormClosing);
        }        

        #region Form Events

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to quit?", "Exit?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res != System.Windows.Forms.DialogResult.Yes)
                e.Cancel = true;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMap();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void frmMain_ResizeEnd(object sender, EventArgs e)
        {
            SetScrollbars();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var camera = _mapRenderer.Services.GetService<CameraService>();         
            camera.Position.Y = this.vScrollBar.Value;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var camera = _mapRenderer.Services.GetService<CameraService>();
            camera.Position.X = this.hScrollBar.Value;
        }

        #endregion Form Events

        #region Private Methods

        private void NewMap()
        {
            CloseMap();

            var frm = new frmNewMap();
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            _mapData = new HexMap(frm.HexMapType, frm.HexTileType, frm.TileCountX, frm.TileCountY, frm.TileRadius);

            InitRenderer();         
        }

        private void CloseMap()
        {
            this.pnlMain.Controls.Remove(_mapRenderer);
        }

        private void InitRenderer()
        {
            _mapRenderer = new ucMapRenderer(_mapData);
            _mapRenderer.Dock = DockStyle.Fill;
            _mapRenderer.Location = new Point(0, 0);
            _mapRenderer.TabIndex = 0;        

            this.pnlMain.Controls.Add(_mapRenderer);

            SetScrollbars();
        }

        private void SetScrollbars()
        {
            if (null == _mapData) return;
            this.hScrollBar.Minimum = 0;
            this.hScrollBar.Maximum = _mapData.TilesCountX * (int)_mapData.TileWidth - this.Width / 2;
            this.hScrollBar.Enabled = true;

            this.vScrollBar.Minimum = 0;
            this.vScrollBar.Maximum = _mapData.TilesCountY * (int)_mapData.TileHeight - this.Height / 2;
            this.vScrollBar.Enabled = true;
        }

        #endregion Private Methods
    }
}
