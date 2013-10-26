using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using CastleLegends.Editor.Services;
using Microsoft.Xna.Framework;
using CastleLegends.Common.Utils;

namespace CastleLegends.Editor.UserControls
{
    public partial class ucTilesetRenderer : ucBaseRender
    {
        #region Members       

        private SpriteBatch _spriteBatch = null;

        private CameraService _camera = null;

        private Tileset _tileset = null;

        #endregion Members

        public ucTilesetRenderer()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void SetTileset(Tileset tileset)
        {  
            _tileset = tileset;
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
            if (null != _tileset)
            {
                _spriteBatch.Draw(_tileset.Texture, _tileset.Texture.Bounds, Color.White);

                if (this.ShowGrid) 
                    this.DrawGrid();
            }            

            _spriteBatch.End();
        }

        private void DrawGrid() {
            _spriteBatch.DrawGrid(Vector2.Zero, 
                                  new Vector2(this._tileset.Width, this._tileset.Height), 
                                  new Vector2(_tileset.TileWidth, _tileset.TileHeight),
                                  this.GridColor);
        }

        #endregion Private Methods

        #region Properties

        public bool ShowGrid { get; set; }

        public Color GridColor { get; set; }

        #endregion Properties
    }
}
