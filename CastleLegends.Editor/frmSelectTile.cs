using System;
using System.Windows.Forms;
using CastleLegends.Editor.UserControls;

namespace CastleLegends.Editor
{
    public partial class frmSelectTile : Form
    {
        #region Members

        private ucTilesetRenderer _renderer;

        #endregion Members

        public frmSelectTile()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmSelectTile_Load);
            this.ResizeEnd += new EventHandler(frmSelectTile_ResizeEnd);
        }

        #region Form Events

        private void frmSelectTile_Load(object sender, EventArgs e)
        {            
            InitRenderer();
        }
        
        private void frmSelectTile_ResizeEnd(object sender, EventArgs e)
        {
            SetScrollbars();
        }

        #endregion Form Events

        #region Methods

        public void SetTileset(Tileset set) {
            InitRenderer();

            this.TileSet = set;

            _renderer.SetTileset(this.TileSet);

            SetScrollbars();
        }

        #endregion Methods

        #region Private Methods

        private void InitRenderer()
        {
            if (null != _renderer) return;
            _renderer = new ucTilesetRenderer();
            this.ucRendererContainer.SetRenderer(_renderer);
        }

        private void SetScrollbars()
        {
            if (null == TileSet) return;

            var vMax = TileSet.Height - ucRendererContainer.Height;
            var hMax = TileSet.Width - ucRendererContainer.Width;

            this.ucRendererContainer.SetScrollbars(vMax, hMax);
        }

        #endregion Private Methods

        #region Properties

        public Tileset TileSet { get; private set; }

        #endregion Properties
    }
}
