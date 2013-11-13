using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using CastleLegends.Editor.Services;
using Microsoft.Xna.Framework;
using CastleLegends.Common.Utils;
using CastleLegends.Common;

namespace CastleLegends.Editor.UserControls
{
    public partial class ucTilesetRenderer : ucBaseRender
    {
        #region Members       

        private SpriteBatch _spriteBatch = null;

        private CameraService _camera = null;

        private Tileset _tileset = null;

        private Point _selectedTileIndex = Point.Zero;

        #endregion Members

        public ucTilesetRenderer()
        {
            InitializeComponent();

            this.EnableSelection = false;            
        }

        #region Eventds


        #endregion Eventds

        #region Public Methods

        public void SetTileset(Tileset tileset)
        {  
            _tileset = tileset;
        }

        public bool SelectTile(out Point tileIndices)
        {
            var relativeMousePos = this.PointToClient(MousePosition);
            var mousePosVec = new Vector2(relativeMousePos.X, relativeMousePos.Y) + _camera.Position;

            tileIndices.X = (int)Math.Floor(mousePosVec.X / _tileset.TileWidth);
            tileIndices.Y = (int)Math.Floor(mousePosVec.Y / _tileset.TileHeight);

            return CheckIsSelectionValid(ref tileIndices);
        }

        #endregion Public Methods

        #region Private Methods

        protected override void OnInitialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _camera = new CameraService(this.GraphicsDevice);
            base.Services.AddService<CameraService>(_camera);
        }

        protected override void OnUpdate()
        {
            if (null == _tileset) return;

            if (this.EnableSelection)
                SelectTile(out _selectedTileIndex);            
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

                if (this.EnableSelection)
                    DrawSelectedTile();                
            }            

            _spriteBatch.End();
        }

        private void DrawGrid() {
            _spriteBatch.DrawGrid(Vector2.Zero, 
                                  new Vector2(this._tileset.Width, this._tileset.Height), 
                                  new Vector2(_tileset.TileWidth, _tileset.TileHeight),
                                  this.GridColor);
        }

        private void DrawSelectedTile()
        {
            if (!CheckIsSelectionValid(ref _selectedTileIndex)) return;

            var bounds = new Rectangle(_selectedTileIndex.X * _tileset.TileWidth, 
                                       _selectedTileIndex.Y * _tileset.TileHeight, 
                                        _tileset.TileWidth, 
                                         _tileset.TileHeight);
            _spriteBatch.DrawRectangle(bounds, Color.Magenta, 2f);
        }
     
        private bool CheckIsSelectionValid(ref Point tileIndices)
        {
            return (tileIndices.X > -1 && tileIndices.X < _tileset.TilesCountX) &&
                    (tileIndices.Y > -1 && tileIndices.Y < _tileset.TilesCountY);
        }
               
        #endregion Private Methods

        #region Properties

        public bool EnableSelection { get; set; }

        public bool ShowGrid { get; set; }

        public Color GridColor { get; set; }

        #endregion Properties
               
    }
}
