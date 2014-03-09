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
        private TilesetViewModel _tileset = null;

        private ucTilesetRenderer _renderer;       

        #endregion Members

        public frmImportTileset()
        {
            InitializeComponent();
           
            this.ResizeEnd += new EventHandler(frmImportTileset_ResizeEnd);

            SetupRenderer();
        }        

        #region Form Events
    
        private void frmImportTileset_ResizeEnd(object sender, EventArgs e)
        {
            SetScrollbars();
        }        

        private void btnLoad_Click(object sender, EventArgs e)
        {
            TilesetViewModel newTileset = null;           

            var ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.bmp;*.jpg;*.png;*.tga";
            ofd.Multiselect = false;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() == DialogResult.OK)            
                newTileset = TilesetFactory.Load(ofd.FileName, _renderer.GraphicsDevice);

            SetTileset(newTileset);

            if (null != newTileset)
            {
                this.TileSet.Tileset.TileWidth = 32;
                this.TileSet.Tileset.TileHeight = 32;
            }
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

        private void SetupRenderer()
        {
            _renderer = new ucTilesetRenderer();
            this.ucRendererContainer.SetRenderer(_renderer);
        }

        private void ResetUI()
        {
            this.tilesetProperties.Enabled = false;
            this.btnSetGridColor.Enabled = false;
            this.chkShowGrid.Enabled = false;
            this.btnOK.Enabled = false;
        }

        private void BindTileset()
        {
            this.tilesetProperties.SelectedObject = _tileset;
            this.tilesetProperties.Enabled = true;
            this.btnSetGridColor.Enabled = this.chkShowGrid.Checked;
            this.btnSetGridColor.Enabled = true;
            this.btnOK.Enabled = true;
            this.chkShowGrid.Enabled = true;

            if (null != _renderer)
            {
                _renderer.SetTileset(_tileset);
                _renderer.ShowGrid = this.chkShowGrid.Checked;
            }

            SetScrollbars();
        }

        private void SetScrollbars()
        {
            if (null == _tileset) return;

            var vMax = TileSet.Height - ucRendererContainer.Height;
            var hMax = TileSet.Width - ucRendererContainer.Width;

            this.ucRendererContainer.SetScrollbars(vMax, hMax);
        }

        #endregion Private Methods

        public void SetTileset(TilesetViewModel tileset) {
            ResetUI();

            _tileset = tileset;
            
            BindTileset(); 
        }

        #region Properties

        public TilesetViewModel TileSet {
            get { return _tileset; }           
        }

        #endregion Properties
    }
}
