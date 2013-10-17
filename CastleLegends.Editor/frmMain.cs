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

        #endregion Members

        public frmMain()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmMain_Load);
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

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var camera = _mapRenderer.Services.GetService<CameraService>();
            camera.Position.Y += e.NewValue - e.OldValue;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            var camera = _mapRenderer.Services.GetService<CameraService>();
            camera.Position.X += e.NewValue - e.OldValue;
        }

        #endregion Form Events

        #region Private Methods

        private void NewMap()
        {
            CloseMap();

            var frm = new frmNewMap();
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var mapData = new HexMap()
            {
                MapCoordsType = frm.HexMapType,
                TilesType = frm.HexTileType,
                TilesCountX = frm.TileCountX,
                TilesCountY = frm.TileCountY,
                TilesRadius = frm.TileRadius
            };

            InitRenderer(mapData);
            // _MapCtrl.NewMap(frm.TileCountX, frm.TileCountY, frm.TileSize);
            //  _ucLayers.UpdateData();
            //  _ucTilePathfinding.UpdateData();

        }

        private void CloseMap()
        {
            this.pnlMain.Controls.Remove(_mapRenderer);
        }

        private void InitRenderer(HexMap mapData)
        {
            _mapRenderer = new ucMapRenderer(mapData);
            _mapRenderer.Dock = DockStyle.Fill;
            _mapRenderer.Location = new Point(0, 0);
            _mapRenderer.TabIndex = 0;

            this.pnlMain.Controls.Add(_mapRenderer);
        }

        #endregion Private Methods
    }
}
