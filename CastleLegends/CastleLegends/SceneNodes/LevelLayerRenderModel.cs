using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CastleLegends.Common;
using GlyphEngine.Components;
using GlyphEngine.GameScreens;
using GlyphEngine.SceneGraph;
using GlyphEngine.Services;
using GlyphEngine.Extensions;
using GlyphEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GlyphEngine.Core;
using GlyphEngine.Utils;


namespace CastleLegends.SceneNodes
{
    public class LevelLayerRenderModel : IRenderable
    {
        #region Members

        private HexMap _mapData;
        private MapLayer _layer;
        private Rectangle _bounds = Rectangle.Empty;
        private Vector2 _positionOffset = Vector2.Zero;
        private TileRenderModel[,] _tileRenderModels;

        #endregion Members

        public LevelLayerRenderModel(HexMap mapData, MapLayer layer)
        {
            if (null == layer)
                throw new ArgumentNullException("layer");
            if (null == mapData)
                throw new ArgumentNullException("mapData");

            _mapData = mapData;
            _layer = layer;

            if (null != _layer.Tiles)
                _bounds = new Rectangle(0, 0, (int)_mapData.MapWidth, (int)_mapData.MapHeight);

            if (_mapData.TilesType == HexTileType.FlatTopped)
                _positionOffset = new Vector2(_mapData.TilesRadius, _mapData.TileVerticalDistanceHalf);
            else
                _positionOffset = new Vector2(_mapData.TileHorizontalDistanceHalf, _mapData.TilesRadius);
        }

        #region IRenderable implementation

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, Transform tr, Color col, float depth)
        {
            InitTileModels(spriteBatch.GraphicsDevice);
            for (int y = 0; y != _mapData.TilesCountY; ++y)
                for (int x = 0; x != _mapData.TilesCountX; ++x)
                {
                    var vm = _tileRenderModels[x, y];
                    if (null == vm || null == vm.Texture) continue;

                    var color = Color.White;
                    var aiTile = _mapData.AILayer.Tiles[x, y];
                    if (null != aiTile && aiTile.TileType != AITile.AITileTypes.Walkable)
                        color = Color.DarkRed;

                    spriteBatch.Draw(vm.Texture, vm.DestRect, vm.Tile.TextureSourceBounds, color);
                }
        }

        public void Draw(Microsoft.Xna.Framework.GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, ref Microsoft.Xna.Framework.Vector2 pos, float rot, ref Microsoft.Xna.Framework.Vector2 scale, Microsoft.Xna.Framework.Color col, float depth)
        {
            throw new NotImplementedException();
        }

        #endregion IRenderable implementation

        #region Private Methods

        private void InitTileModels(GraphicsDevice graphicsDevice)
        {
            if (null != _tileRenderModels)
                return;

            _tileRenderModels = new TileRenderModel[_layer.Tiles.GetLength(0), _layer.Tiles.GetLength(1)];

            Vector2 tileCenter;
            Vector2 tileCoords;

            for (int y = 0; y != _mapData.TilesCountY; ++y)
                for (int x = 0; x != _mapData.TilesCountX; ++x)
                {
                    tileCoords = _mapData.TileToCoords(x, y);
                    tileCenter = tileCoords + _positionOffset;

                    var tile = _layer.Tiles[x, y];
                    if (null != tile && null != tile.Tileset)
                    {
                        _tileRenderModels[x, y] = new TileRenderModel()
                        {
                            Tile = tile,
                            DestRect = new Rectangle((int)tileCoords.X, (int)tileCoords.Y, (int)_mapData.TileWidth, (int)_mapData.TileHeight),
                            Texture = TextureHelpers.LoadTexture(graphicsDevice, tile.Tileset.Asset)
                        };
                    }
                }
        }

        #endregion Private Methods

        #region Properties

        public Rectangle Bounds
        {
            get
            {
                return _bounds;
            }
        }

        public Rectangle CollisionBounds
        {
            get { return this.Bounds; }
        }

        public Vector2 Origin
        {
            get
            {
                return Vector2.Zero;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Vector2 BaseCenter
        {
            get
            {
                return Vector2.Zero;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion Properties
    }

    internal class TileRenderModel
    {
        public Tile Tile = null;

        public Texture2D Texture = null;

        public Rectangle DestRect = Rectangle.Empty;
    }
}
