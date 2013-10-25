using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CastleLegends.Editor.UserControls;

namespace CastleLegends.Editor
{
    public partial class frmImportTileset : Form
    {
        #region Members

        private ucTilesetRenderer _renderer;

        #endregion Members

        public frmImportTileset()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmImportTileset_Load);
            this.ResizeEnd += new EventHandler(frmImportTileset_ResizeEnd);
        }        

        #region Form Events

        private void frmImportTileset_Load(object sender, EventArgs e)
        {
            _renderer = new ucTilesetRenderer();            
            this.ucRendererContainer.SetRenderer(_renderer);
        }

        private void frmImportTileset_ResizeEnd(object sender, EventArgs e)
        {
            SetScrollbars();
        }        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.bmp;*.jpg;*.png;*.tga";
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            _renderer.LoadTileset(ofd.FileName);
           
            SetScrollbars();
        }

        private void chkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            if (null != _renderer)
                _renderer.ShowGrid = this.chkShowGrid.Checked;
        }

        private void numTileWidth_ValueChanged(object sender, EventArgs e)
        {
            if (null != _renderer) _renderer.TileWidth = (int)this.numTileWidth.Value;
        }

        private void numTileHeight_ValueChanged(object sender, EventArgs e)
        {
            if (null != _renderer) _renderer.TileHeight = (int)this.numTileHeight.Value;
        }

        #endregion Form Events

        #region Private Methods

        private void SetScrollbars()
        {
            if (null == _renderer.Tileset) return;
            
            var vMax = _renderer.Tileset.Height - ucRendererContainer.Height;
            var hMax = _renderer.Tileset.Width - ucRendererContainer.Width;

            this.ucRendererContainer.SetScrollbars(vMax, hMax);
        }

        #endregion Private Methods

    }
}
