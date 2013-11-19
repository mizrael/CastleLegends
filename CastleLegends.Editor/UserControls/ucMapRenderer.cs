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

            this.Click += new EventHandler(ucMapRenderer_Click);
        }

        #region Events

        private void ucMapRenderer_Click(object sender, EventArgs e)
        {
            int tileIndexX, tileIndexY;
            if (null != MapTileSelected && SelectTile(out tileIndexX, out tileIndexY))
                MapTileSelected(this, new MapTileSelectedEventArgs(tileIndexX, tileIndexY));
        }

        #endregion Events

        #region Public Methods

        public void SetMapData(HexMap mapData) {
            if (null == mapData)
                throw new ArgumentNullException("mapData");
            _mapData = mapData;

            if(_mapData.TilesType == HexTileType.FlatTopped)
                _positionOffset = new Vector2(_mapData.TilesRadius, _mapData.TileVerticalDistanceHalf);
            else
                _positionOffset = new Vector2(_mapData.TileHorizontalDistanceHalf, _mapData.TilesRadius);            
        }

        #endregion Public Methods

        #region Private Methods

        protected override void OnInitialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _camera = new CameraService(this.GraphicsDevice);
            base.Services.AddService<CameraService>(_camera);      
        }

        /// <summary>
        /// http://www.redblobgames.com/grids/hexagons/
        /// </summary>
        protected override void OnDraw()
        {
            base.GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.Matrix);

            Vector2 tileCenter;
            Vector2 tileCoords;

            for (int y = 0; y != _mapData.TilesCountY; ++y)
                for (int x = 0; x != _mapData.TilesCountX; ++x)
                {
                    tileCoords = TileToCoords(x, y);
                    tileCenter = tileCoords + _positionOffset;

                    var tile = _mapData.Tiles[x, y];
                    if (null != tile && null != tile.Tileset)
                    {
                        var model = TilesetFactory.Get(tile.Tileset.ID);
                        if (null != model) {
                            var destRect = new Rectangle((int)tileCoords.X, (int)tileCoords.Y, (int)_mapData.TileWidth, (int)_mapData.TileHeight);
                            _spriteBatch.Draw(model.Texture, destRect, tile.TextureSourceBounds, Color.White);                            
                        }                        
                    }

                    _spriteBatch.DrawHexagon(tileCenter, _mapData.TilesRadius, Color.Green, _mapData.TilesType);
                }

            int tileIndexX, tileIndexY;
            if (SelectTile(out tileIndexX, out tileIndexY))
            {
                tileCenter = TileToCoords(tileIndexX, tileIndexY) + _positionOffset;
                _spriteBatch.DrawHexagon(tileCenter, _mapData.TilesRadius, Color.Red, _mapData.TilesType, 3f);
            }

            if (this.DrawDebugLines)
            {
                DrawDebug();
            }
            _spriteBatch.End();
        }

        private bool SelectTile(out int tileIndexX, out int tileIndexY)
        {
            var relativeMousePos = this.PointToClient(MousePosition);
            var mousePosVec = new Vector2(relativeMousePos.X, relativeMousePos.Y);
            return CoordsToTile(mousePosVec, out tileIndexX, out tileIndexY);
        }
        
        private Vector2 TileToCoords(int i, int j) 
        {
            var offset = 0f;
            if (_mapData.TilesType == HexTileType.FlatTopped)
            {
                offset = (_mapData.MapCoordsType == HexMapType.Even) ? (i.IsEven() ? _mapData.TileVerticalDistanceHalf : 0f) :
                                                                           (!i.IsEven() ? _mapData.TileVerticalDistanceHalf : 0f);
                return new Vector2(_mapData.TileHorizontalDistance * i, _mapData.TileVerticalDistance * j + offset);
            }

            offset = (_mapData.MapCoordsType == HexMapType.Even) ? (j.IsEven() ? _mapData.TileHorizontalDistanceHalf : 0f) :
                                                                   (!j.IsEven() ? _mapData.TileHorizontalDistanceHalf : 0f);
            return new Vector2(_mapData.TileHorizontalDistance * i + offset, _mapData.TileVerticalDistance * j);
        }

        #region CoordsToTile

        /// <summary>      
        /// http://gamedev.stackexchange.com/questions/20742/how-can-i-implement-hexagonal-tilemap-picking-in-xna
        /// </summary>
        private bool CoordsToTile(Vector2 screenCoords, out int i, out int j) {
            if (_mapData.TilesType == HexTileType.FlatTopped)
                return CoordsToTileFlatTop(screenCoords, out i, out j);
            return CoordsToTilePointyTop(screenCoords, out i, out j);
        }

        private bool CoordsToTileFlatTop(Vector2 screenCoords, out int i, out int j)
        {
            Vector2.Transform(ref screenCoords, ref _camera.InverseMatrix, out screenCoords);

            var _k = (_mapData.TileWidth + _mapData.TilesRadius) * .5f;

            i = (int)Math.Floor(screenCoords.X / _k);
            j = (int)Math.Floor((screenCoords.Y * 2f) / _mapData.TileHeight);

            var u = screenCoords.X - (_k * i);
            var v = screenCoords.Y - (_mapData.TileHeight * j * 0.5f);

            var is_i_even = i.IsEven();

            var isGreenArea = (u < (_mapData.TileWidth - _mapData.TilesRadius) * 0.5f);
            if (isGreenArea)
            {
                var is_j_even = j.IsEven();

                var sum = ((i + j) & 1);
                var isUpper = (_mapData.MapCoordsType == HexMapType.Even) ? (0 != sum) : (0 == sum);

                u = (2f * u) / (_mapData.TileWidth - _mapData.TilesRadius);
                v = (2f * v) / _mapData.TileHeight;

                if ((!isUpper && v > u) || (isUpper && (1f - v) > u))
                {
                    i--;
                    is_i_even = !is_i_even;
                }
            }

            if ((_mapData.MapCoordsType == HexMapType.Even && is_i_even) || (_mapData.MapCoordsType == HexMapType.Odd && !is_i_even))
                j--;

            j = (int)Math.Floor(j * 0.5);

            if (i < 0 || i >= _mapData.TilesCountX) return false;
            if (j < 0 || j >= _mapData.TilesCountY) return false;

            return true;
        }

        private bool CoordsToTilePointyTop(Vector2 screenCoords, out int i, out int j)
        {
            Vector2.Transform(ref screenCoords, ref _camera.InverseMatrix, out screenCoords);

            var _k = (_mapData.TileHeight + _mapData.TilesRadius) * .5f;

            i = (int)Math.Floor((screenCoords.X * 2f) / _mapData.TileWidth);
            j = (int)Math.Floor(screenCoords.Y / _k);

            var is_j_even = j.IsEven();

            var u = screenCoords.X - (_mapData.TileWidth * i * 0.5f);
            var v = screenCoords.Y - (_k * j);            

            var isGreenArea = (v < (_mapData.TileHeight - _mapData.TilesRadius) * 0.5f);
            if (isGreenArea)
            {
                var is_i_even = i.IsEven();

                var sum = ((i + j) & 1);
                var isLeft = (_mapData.MapCoordsType == HexMapType.Even) ? (0 != sum) : (0 == sum);

                u = (2f * u) / _mapData.TileHeight;
                v = (2f * v) / (_mapData.TileWidth - _mapData.TilesRadius);

                if ((!isLeft && u > v) || (isLeft && (1f - u) > v))
                {
                    j--;
                    is_j_even = !is_j_even;
                }
            }

            if ((_mapData.MapCoordsType == HexMapType.Even && is_j_even) || (_mapData.MapCoordsType == HexMapType.Odd && !is_j_even))
                i--;

            i = (int)Math.Floor(i * 0.5);

            if (i < 0 || i >= _mapData.TilesCountX) return false;
            if (j < 0 || j >= _mapData.TilesCountY) return false;

            return true;
        }

        #endregion CoordsToTile

        #endregion Private Methods

        #region DrawDebug

        private void DrawDebug()
        {
            if (_mapData.TilesType == HexTileType.FlatTopped) DrawDebugFlat();
            else DrawDebugPointy();
        }

        private void DrawDebugPointy()
        {
            var lineColor = Color.Magenta;

            var halfRadius = _mapData.TilesRadius * 0.5f;

            var lineLength = _mapData.TilesCountY * _mapData.TileVerticalDistance + halfRadius;

            for (int i = 0; i != _mapData.TilesCountX; ++i)
            {
                var currTileCoords = TileToCoords(i, 0);

                var lineStartPos = new Vector2(currTileCoords.X, 0f);
                _spriteBatch.DrawLine(lineStartPos, lineLength, MathHelper.PiOver2, lineColor);

                lineStartPos = new Vector2(currTileCoords.X + _mapData.TileHorizontalDistanceHalf, 0f);
                _spriteBatch.DrawLine(lineStartPos, lineLength, MathHelper.PiOver2, lineColor);
            }

            _spriteBatch.DrawLine(new Vector2(_mapData.TilesCountX * _mapData.TileWidth +_mapData.TileHorizontalDistanceHalf, 0f), 
                                  lineLength, MathHelper.PiOver2, lineColor);

            lineLength = _mapData.TilesCountX * _mapData.TileWidth + +_mapData.TileHorizontalDistanceHalf;

            for (int j = 0; j != _mapData.TilesCountY; ++j)
            {
                var currTileCoords = TileToCoords(0, j);

                var y = currTileCoords.Y + halfRadius;
                var lineStartPos = new Vector2(0f, y);
                _spriteBatch.DrawLine(lineStartPos, lineLength, 0f, lineColor);

                lineStartPos = new Vector2(0f, y + _mapData.TilesRadius);
                _spriteBatch.DrawLine(lineStartPos, lineLength, 0f, lineColor);
            }

            _spriteBatch.DrawLine(new Vector2(0f, _mapData.TilesCountY * _mapData.TileVerticalDistance + halfRadius),
                                  lineLength, 0f, lineColor);
        }

        private void DrawDebugFlat()
        {
            var lineColor = Color.Magenta;

            var halfRadius = _mapData.TilesRadius * 0.5f;

            var lineLength = _mapData.TilesCountY * _mapData.TileHeight + _mapData.TileHeight * 0.5f;

            for (int i = 0; i != _mapData.TilesCountX; ++i)
            {
                var currTileCoords = TileToCoords(i, 0);

                var x = currTileCoords.X + halfRadius;

                var lineStartPos = new Vector2(x, 0f);
                _spriteBatch.DrawLine(lineStartPos, lineLength, MathHelper.PiOver2, lineColor);

                lineStartPos = new Vector2(x + _mapData.TilesRadius, 0f);
                _spriteBatch.DrawLine(lineStartPos, lineLength, MathHelper.PiOver2, lineColor);
            }

            var lastTileCoords = TileToCoords(_mapData.TilesCountX, 0);
            var lineStart = new Vector2(lastTileCoords.X + halfRadius, 0f);
            _spriteBatch.DrawLine(lineStart, lineLength, MathHelper.PiOver2, lineColor);

            lineLength = _mapData.TilesCountX * _mapData.TileHorizontalDistance + halfRadius;

            for (int j = 0; j != _mapData.TilesCountY; ++j)
            {
                var currTileCoords = TileToCoords(0, j);

                var lineStartPos = new Vector2(0f, currTileCoords.Y);
                _spriteBatch.DrawLine(lineStartPos, lineLength, 0f, lineColor);

                lineStartPos = new Vector2(0f, currTileCoords.Y + _mapData.TileHeight * 0.5f);
                _spriteBatch.DrawLine(lineStartPos, lineLength, 0f, lineColor);
            }

            lineStart = new Vector2(0, _mapData.TilesCountY * _mapData.TileHeight + _mapData.TileVerticalDistanceHalf);
            _spriteBatch.DrawLine(lineStart, lineLength, 0f, lineColor);
        }

        #endregion DrawDebug

        #region Properties

        public bool DrawDebugLines { get; set; }

        #endregion Properties

        #region Custom Events

        public delegate void MapTileSelectedEventHandler(object sender, MapTileSelectedEventArgs data);
        public event MapTileSelectedEventHandler MapTileSelected;

        #endregion Custom Events
    }

    public class MapTileSelectedEventArgs : EventArgs {
        public MapTileSelectedEventArgs(int tileIndexX, int tileIndexY) {
            this.TileIndexX = tileIndexX;
            this.TileIndexY = tileIndexY;
        }

        public int TileIndexX { get; private set; }
        public int TileIndexY { get; private set; }
    }
}

