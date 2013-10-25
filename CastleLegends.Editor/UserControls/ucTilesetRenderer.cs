using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using CastleLegends.Editor.Services;
using Microsoft.Xna.Framework;

namespace CastleLegends.Editor.UserControls
{
    public partial class ucTilesetRenderer : ucBaseRender
    {
        #region Members       

        private SpriteBatch _spriteBatch = null;

        private CameraService _camera = null;
       
        private Rectangle _tilesetRect;

        #endregion Members

        public ucTilesetRenderer()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void LoadTileset(string filePath)
        {
            if (null != Tileset)
            {
                Tileset.Dispose();
                Tileset = null;
            }

            using (var stream = System.IO.File.OpenRead(filePath))
            {
                Tileset = Texture2D.FromStream(base.GraphicsDevice, stream);
            }
            _tilesetRect = new Rectangle(0, 0, Tileset.Width, Tileset.Height);
        }

        #endregion Public Methods

        #region Private Methods

        protected override void OnInitialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _camera = new CameraService(this.GraphicsDevice);
            base.Services.AddService<CameraService>(_camera);
        }

        protected override void OnDraw()
        {
            base.GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.Matrix);
            if (null != Tileset)
            {
                _spriteBatch.Draw(Tileset, _tilesetRect, Color.White);
            }

            this.DrawGrid();

            _spriteBatch.End();
        }

        private void DrawGrid() {
            if (!this.ShowGrid) return;
        }

        #endregion Private Methods

        #region Properties

        public Texture2D Tileset { get; private set; }

        public bool ShowGrid { get; set; }

        public int TileWidth { get; set; }
        
        public int TileHeight { get; set; }

        #endregion Properties
    }
}
