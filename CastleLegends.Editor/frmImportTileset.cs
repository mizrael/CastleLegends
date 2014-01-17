using System;
using System.Windows.Forms;
using CastleLegends.Editor.UserControls;
using CastleLegends.Common;
using CastleLegends.Editor.RenderModels;

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
            if (null != this.TileSet)
                this.TileSet.Dispose();

            this.tilesetProperties.Enabled = false;
            this.btnSetGridColor.Enabled = false;
            this.chkShowGrid.Enabled = false;
            this.btnOK.Enabled = false;

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.bmp;*.jpg;*.png;*.tga";
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            this.TileSet = TilesetFactory.Load(ofd.FileName, _renderer.GraphicsDevice);
            this.TileSet.Tileset.TileWidth = 32;
            this.TileSet.Tileset.TileHeight = 32;
            _renderer.SetTileset(TileSet);

            this.tilesetProperties.SelectedObject = TileSet;
            this.tilesetProperties.Enabled = true;
            this.btnSetGridColor.Enabled = this.chkShowGrid.Checked;            
            this.btnSetGridColor.Enabled = true;
            this.btnOK.Enabled = true; 
            this.chkShowGrid.Enabled = true;

            _renderer.ShowGrid = this.chkShowGrid.Checked;            

            SetScrollbars();
        }

        private void chkShowGrid_CheckedChanged(object sender, EventArgs e)
        {
            this.btnSetGridColor.Enabled = this.chkShowGrid.Checked;
            if (null != _renderer)
                _renderer.ShowGrid = this.chkShowGrid.Checked;
        }

        private void tilesetProperties_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            switch (e.ChangedItem.PropertyDescriptor.Name) {
                case "TileWidth":
                    TileSet.Tileset.TileWidth = (int)e.ChangedItem.Value;
                    break;
                case "TileHeight":
                    TileSet.Tileset.TileHeight = (int)e.ChangedItem.Value;
                    break;
            }
        }

        private void btnSetGridColor_Click(object sender, EventArgs e)
        {
            ColorDialog frm = new ColorDialog();
            frm.AllowFullOpen = true;
            frm.FullOpen = true;
            frm.Color = System.Drawing.Color.FromArgb(0, 255, 0);

            if (frm.ShowDialog() != DialogResult.OK) return;
            _renderer.GridColor = new Microsoft.Xna.Framework.Color(frm.Color.R, frm.Color.G, frm.Color.B);
        }

        #endregion Form Events

        #region Private Methods

        private void SetScrollbars()
        {
            if (null == TileSet) return;

            var vMax = TileSet.Height - ucRendererContainer.Height;
            var hMax = TileSet.Width - ucRendererContainer.Width;

            this.ucRendererContainer.SetScrollbars(vMax, hMax);
        }

        #endregion Private Methods

        #region Properties

        public TilesetRenderModel TileSet { get; private set; }

        #endregion Properties
    }
}
