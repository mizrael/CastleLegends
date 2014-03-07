using System;
using System.Collections.Generic;
using System.Linq;
using CastleLegends.Common;
using GlyphEngine.AI;
using GlyphEngine.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleLegends.GameComponents
{
    public class MapInputController : DrawableGameComponent
    {
        #region Members

        private HexMap _map;
        private MouseState _lastMouseState;

        private AITile _hoverTile;
        private Queue<AITile> _endpoints;

        private SpriteBatch _spriteBatch;

        private Vector2 _halfTileSize;
        private float _cursorRadius;

        private KeyboardState _lastKeyState;

        private Path<AITile> _foundPath;

        private Func<AITile, AITile, double> _distanceFunc;        
        private Func<AITile, IEnumerable<AITile>> _findNeighboursFunc;

        private CameraService _camera;

        private Vector2[,] _tilePositions;

        #endregion Members

        public MapInputController(Game game)
            : base(game)
        {
            base.Visible = this.Enabled = false;

            _distanceFunc = (t1, t2) => 0;
         
            _findNeighboursFunc = t => { return _map.AILayer.GetNeighbours(t).Where(nt => nt.TileType == AITile.AITileTypes.Walkable); };
        }

        #region DrawableGameComponent overrides

        protected override void LoadContent()
        {
            base.LoadContent();

            _spriteBatch = new SpriteBatch(base.GraphicsDevice);
        }

        public override void Initialize()
        {
            base.Initialize();

            _camera = base.Game.Services.GetService(typeof(CameraService)) as CameraService;
            if (null == _camera)
                throw new Exception("Unable to find CameraService");
        }

        public override void Update(GameTime gameTime)
        {
            var state = Keyboard.GetState();

            if (state.IsKeyUp(Keys.Enter) && _lastKeyState.IsKeyDown(Keys.Enter) && 2 == _endpoints.Count)
                _foundPath = Pathfinder.FindPath<AITile>(_endpoints.ElementAt(0), _endpoints.ElementAt(1),
                                                         _distanceFunc, this.ComputeTilesDistance, _findNeighboursFunc);

            _lastKeyState = state;

            UpdateMouse();
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.Additive);

            Vector2 tmpPos;
            var cursorSize = _cursorRadius * _camera.Zoom;

            if (null != _foundPath)
            {
                foreach (var node in _foundPath)
                {
                    ComputeCursorPosition(node, out tmpPos);
                    _spriteBatch.DrawCircle(tmpPos, cursorSize * 0.5f, 6, Color.PowderBlue, 3f);
                }
            }

            if (0 != _endpoints.Count)
            {
                foreach (var point in _endpoints)
                {
                    ComputeCursorPosition(point, out tmpPos);
                    _spriteBatch.DrawCircle(tmpPos, cursorSize, 6, Color.Red, 3f);
                }
            }

            if (null != _hoverTile)
            {
                ComputeCursorPosition(_hoverTile, out tmpPos);
                _spriteBatch.DrawCircle(tmpPos, cursorSize, 6, Color.Green, 3f);
            }

            _spriteBatch.End();
        }

        #endregion DrawableGameComponent overrides

        #region Public Methods

        public void SetMap(HexMap map)
        {
            _endpoints = _endpoints ?? new Queue<AITile>();
            _endpoints.Clear();

            _map = map;

            if (_map.TilesType == HexTileType.FlatTopped)
                _halfTileSize = new Vector2(_map.TilesRadius, _map.TileVerticalDistanceHalf);
            else
                _halfTileSize = new Vector2(_map.TileHorizontalDistanceHalf, _map.TilesRadius);

            _cursorRadius = _map.TilesRadius;

            _tilePositions = new Vector2[_map.TilesCountX, _map.TilesCountY];
            for (int x = 0; x != _map.TilesCountX; ++x)
                for (int y = 0; y != _map.TilesCountY; ++y)
                {
                    _tilePositions[x, y] = _map.TileToCoords(x, y) + _halfTileSize;
                }
            
            _hoverTile = null;

            base.Visible = base.Enabled = (null != _map);
        }

        public IEnumerable<AITile> GetEndpoints()
        {
            return _endpoints.ToArray();
        }

        #endregion Public Methods

        #region Private Methods

        private double ComputeTilesDistance(AITile t1, AITile t2) {
            var p1 = _tilePositions[t1.IndexX, t1.IndexY];
            var p2 = _tilePositions[t2.IndexX, t2.IndexY];
            return Vector2.DistanceSquared(p1, p2);
        }

        private void ComputeCursorPosition(AITile tile, out Vector2 position)
        {
            position = _tilePositions[tile.IndexX, tile.IndexY];
            Vector2.Transform(ref position, ref _camera.Matrix, out position);
        }

        private AITile PickTile(ref Vector2 mousePosVec)
        {
            int i, j;
            if (!_map.CoordsToTile(mousePosVec, ref _camera.InverseMatrix, out i, out j))
                return null;
            return _map.AILayer.Tiles[i, j];
        }

        private void UpdateMouse()
        {
            var mouseState = Mouse.GetState();
            var mousePosVec = new Vector2(mouseState.X, mouseState.Y);

            _hoverTile = PickTile(ref mousePosVec);

            if (null != _hoverTile)
            {
                if (mouseState.LeftButton == ButtonState.Released && _lastMouseState.LeftButton == ButtonState.Pressed)
                    _hoverTile.TileType = _hoverTile.TileType == AITile.AITileTypes.Walkable ? AITile.AITileTypes.Wall : AITile.AITileTypes.Walkable;

                if (mouseState.RightButton == ButtonState.Released && _lastMouseState.RightButton == ButtonState.Pressed)
                {
                    if (_endpoints.Contains(_hoverTile))
                        _endpoints.Dequeue();
                    else if (_endpoints.Count < 2)
                        _endpoints.Enqueue(_hoverTile);
                }
            }

            _lastMouseState = mouseState;
        }

        #endregion Private Methods
    }    
}
