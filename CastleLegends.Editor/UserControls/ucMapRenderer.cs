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
        private float _tileWidth;
        private float _tileHeight;
        private float _tileVerticalDistance;
        private float _tileHorizontalDistance;

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

            if (_mapData.TilesType == HexTileType.FlatTopped)
            {
                _tileWidth = _mapData.TilesRadius * 2f;
                _tileHorizontalDistance = _tileWidth * 3f / 4f;

                _tileHeight = _tileWidth * (float)Math.Sqrt(3) * 0.5f;
                _tileVerticalDistance = _tileHeight;
            }
            else {
                _tileHeight = _mapData.TilesRadius * 2f;
                _tileVerticalDistance = _tileHeight * 3f / 4f;

                _tileWidth = _tileHeight * (float)Math.Sqrt(3) * 0.5f;
                _tileHorizontalDistance = _tileWidth;
            }

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

            for (int y = 0; y != _mapData.TilesCountY; ++y) 
            for (int x = 0; x != _mapData.TilesCountX; ++x)
            {
                var pos = GetTilePosition(x,y) + _positionOffset;
                _spriteBatch.DrawHexagon(pos, _mapData.TilesRadius, Color.Green, _mapData.TilesType);
            }   
        
            _spriteBatch.End();
        }

        private Vector2 GetTilePosition(int x, int y) 
        {
            var offset = 0f;
            if (_mapData.TilesType == HexTileType.FlatTopped)
            {
                offset = (_mapData.MapCoordsType == HexMapType.Even) ? (x.IsEven() ? _mapData.TilesRadius : 0f) :
                                                                           (!x.IsEven() ? _mapData.TilesRadius : 0f);
                return new Vector2(_tileHorizontalDistance * x, _tileVerticalDistance * y + offset);
            }

            offset = (_mapData.MapCoordsType == HexMapType.Even) ? (y.IsEven() ? _mapData.TilesRadius : 0f) :
                                                                   (!y.IsEven() ? _mapData.TilesRadius : 0f);
            return new Vector2(_tileHorizontalDistance * x + offset, _tileVerticalDistance * y);
        }

        #endregion Private Methods
    }
}
