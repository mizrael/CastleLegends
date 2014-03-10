using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using CastleLegends.Common;

namespace CastleLegends.Editor.Commands
{
    public class RemoveTileTextureCommand : ICommand
    {
        private MapLayer _layer = null;        
        private Tile _oldTile = null;
        private Point _tileIndices;

        public RemoveTileTextureCommand(MapLayer layer, Point tileIndices)
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
            _tileIndices = tileIndices;

            _oldTile = _layer.Tiles[tileIndices.X, tileIndices.Y];
            if (null != _oldTile)
                _oldTile = _oldTile.Clone() as Tile;
            else
                _oldTile = new Tile(tileIndices.X, tileIndices.Y);
        }

        public void Execute()
        {
            SetTile(null);
        }

        public void Undo()
        {
            SetTile(_oldTile);
        }

        private void SetTile(Tile tile) {
            _layer.Tiles[_tileIndices.X, _tileIndices.Y] = tile;
        }
    }
}
