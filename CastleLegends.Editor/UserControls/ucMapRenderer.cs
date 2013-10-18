using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CastleLegends.Editor.Services;
using CastleLegends.Common.Utils;
using CastleLegends.Common;
using System;

namespace CastleLegends.Editor.UserControls
{
    public partial class ucMapRenderer : ucBaseRender
    { 
        #region Members

        private HexMap _mapData; 

        private Vector2 _positionOffset;

        private SpriteBatch _spriteBatch = null;

        private CameraService _camera;

        #endregion Members

        public ucMapRenderer(HexMap mapData)
        {
            SetMapData(mapData); 
            InitializeComponent();            
        }

        #region Public Methods

        public void SetMapData(HexMap mapData) {
            if (null == mapData)
                throw new ArgumentNullException("mapData");
            _mapData = mapData;            

            _positionOffset = Vector2.One * _mapData.TilesRadius;
        }

        #endregion Public Methods

        #region Private Methods

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _camera = new CameraService(this.GraphicsDevice);
            base.Services.AddService<CameraService>(_camera);      
        }

        protected override void Update()
        {
            _camera.Update();
        }

        /// <summary>
        /// http://www.redblobgames.com/grids/hexagons/
        /// </summary>
        protected override void Draw()
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.Matrix);

            Vector2 pos;

            for (int y = 0; y != _mapData.TilesCountY; ++y) 
            for (int x = 0; x != _mapData.TilesCountX; ++x)
            {
                pos = TileToCoords(x,y) + _positionOffset;
                _spriteBatch.DrawHexagon(pos, _mapData.TilesRadius, Color.Green, _mapData.TilesType);
            }


            var relativeMousePos = this.PointToClient(MousePosition);
            var mousePosVec = new Vector2(relativeMousePos.X, relativeMousePos.Y);

            int tileIndexX, tileIndexY;
            if (CoordsToTile(mousePosVec, out tileIndexX, out tileIndexY))
            {
                pos = TileToCoords(tileIndexX, tileIndexY) + _positionOffset;
                _spriteBatch.DrawHexagon(pos, _mapData.TilesRadius, Color.Red, _mapData.TilesType, 3f);
            }

            _spriteBatch.End();
        }

        private Vector2 TileToCoords(int x, int y) 
        {
            var offset = 0f;
            if (_mapData.TilesType == HexTileType.FlatTopped)
            {
                offset = (_mapData.MapCoordsType == HexMapType.Even) ? (x.IsEven() ? _mapData.TileVerticalDistanceHalf : 0f) :
                                                                           (!x.IsEven() ? _mapData.TileVerticalDistanceHalf : 0f);
                return new Vector2(_mapData.TileHorizontalDistance * x, _mapData.TileVerticalDistance * y + offset);
            }

            offset = (_mapData.MapCoordsType == HexMapType.Even) ? (y.IsEven() ? _mapData.TileHorizontalDistanceHalf : 0f) :
                                                                   (!y.IsEven() ? _mapData.TileHorizontalDistanceHalf : 0f);
            return new Vector2(_mapData.TileHorizontalDistance * x + offset, _mapData.TileVerticalDistance * y);
        }

        private bool CoordsToTile(Vector2 screenCoords, out int i, out int j)
        {
            Vector2.Transform(ref screenCoords, ref _camera.InverseMatrix, out screenCoords);

            var _h = _mapData.TileHeight;
            var _W = _mapData.TileWidth;
            var _w = _mapData.TileWidth * 0.25f; // flat side length
            var _k = (_W + _w) * .5f;

            i = (int)Math.Floor(screenCoords.X / _k);
            j = (int)Math.Floor((screenCoords.Y * 2f) / _h);

            var u = screenCoords.X - (_k * i);
            var v = screenCoords.Y - (_h * j * 0.5f);

            var is_i_even = i.IsEven();

            var isGreenArea = (u < (_W - _w) * 0.5f);
            if (isGreenArea)
            {
                var is_j_even = j.IsEven();

                var isUpper = (0 == ((i + j) & 1));
                u = (2f * u) / (_W - _w);
                v = (2f * v) / _h;

                if ((!isUpper && v > u) || (isUpper && (1f - v) > u))
                {
                    i--;
                    is_i_even = !is_i_even;
                }
            }

            if (!is_i_even)
                j--;

            j = (int)Math.Floor(j * 0.5);

            if (i < 0 || i >= _mapData.TilesCountX) return false;
            if (j < 0 || j >= _mapData.TilesCountY) return false;

            return true;
        }

        #endregion Private Methods
    }
}
