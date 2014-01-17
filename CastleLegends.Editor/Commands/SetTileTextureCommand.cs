using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CastleLegends.Common;

namespace CastleLegends.Editor.Commands
{
    public class SetTileTextureCommand : ICommand
    {
        private MapLayer _layer = null;
        private Tile _newTile = null;
        private Tile _oldTile = null;

        public SetTileTextureCommand(MapLayer layer, Point tileIndices, Tileset tileset, Rectangle sourceTextureBounds)
        {
            if (null == layer)
                throw new ArgumentNullException("layer");
            if (null == layer.Tiles)
                throw new ArgumentException("Map Tiles not initialized!");
            if (tileIndices.X < 0 || tileIndices.X > layer.Tiles.GetLength(0))
                throw new ArgumentOutOfRangeException("tileIndices.X");
            if (tileIndices.Y < 0 || tileIndices.Y > layer.Tiles.GetLength(1))
                throw new ArgumentOutOfRangeException("tileIndices.Y");

            _layer = layer;
            
            _oldTile = _layer.Tiles[tileIndices.X, tileIndices.Y];
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
            _layer.Tiles[tile.IndexX, tile.IndexY] = tile;
        }
    }
}
