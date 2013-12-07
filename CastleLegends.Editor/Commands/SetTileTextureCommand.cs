using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CastleLegends.Common;
using CastleLegends.Common.RenderModels;

namespace CastleLegends.Editor.Commands
{
    public class SetTileTextureCommand : ICommand
    {
        private HexMap _map = null;
        private Tile _newTile = null;
        private Tile _oldTile = null;

        public SetTileTextureCommand(HexMap map, Point tileIndices, Tileset tileset, Rectangle sourceTextureBounds)
        {
            if (null == map)
                throw new ArgumentNullException("hexMap");
            if (null == map.Tiles)
                throw new ArgumentException("Map Tiles not initialized!");
            if (tileIndices.X < 0 || tileIndices.X > map.TilesCountX)
                throw new ArgumentOutOfRangeException("tileIndices.X");
            if (tileIndices.Y < 0 || tileIndices.Y > map.TilesCountY)
                throw new ArgumentOutOfRangeException("tileIndices.Y");

            _map = map;
            
            _oldTile = _map.Tiles[tileIndices.X, tileIndices.Y];
            if (null != _oldTile)
                _oldTile = _oldTile.Clone();
            else
                _oldTile = new Tile(tileIndices.X, tileIndices.Y);

            _newTile = new Tile(tileIndices.X, tileIndices.Y)
            {
                Tileset = tileset,
                TextureSourceBounds = sourceTextureBounds
            };           
        }

        public void Execute()
        {
            SetTile(_newTile);
        }

        public void Undo()
        {
            SetTile(_oldTile);
        }

        private void SetTile(Tile tile) {
            _map.Tiles[tile.IndexX, tile.IndexY] = tile;
        }
    }
}
