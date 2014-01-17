using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using GlyphEngine.Extensions;

namespace CastleLegends.Common
{
    public enum HexTileType
    {
        PointyTopped,
        FlatTopped        
    }

    public enum HexMapType
    {
        Odd,
        Even
    }

    public class HexMap
    {
        public HexMap(HexMapType coordsType, HexTileType tilesType, int tilesCountX, int tilesCountY, float tileRadius)
        {
            this.MapCoordsType = coordsType;
            this.TilesType = tilesType;
            this.TilesCountX = tilesCountX;
            this.TilesCountY = tilesCountY;
            this.TilesRadius = tileRadius;

            this.Layers = new List<MapLayer>();

            ComputeBounds();
        }

        #region Methods

        public IEnumerable<Tileset> GetTilesets()
        {
            var allTilesets = this.Layers.SelectMany(l => l.GetTilesets());
            var distinctTilesets = allTilesets.Distinct();
            return distinctTilesets.ToArray();
        }

        public Vector2 TileToCoords(int i, int j)
        {
            var offset = 0f;
            if (this.TilesType == HexTileType.FlatTopped)
            {
                offset = (this.MapCoordsType == HexMapType.Even) ? (i.IsEven() ? this.TileVerticalDistanceHalf : 0f) :
                                                                           (!i.IsEven() ? this.TileVerticalDistanceHalf : 0f);
                return new Vector2(this.TileHorizontalDistance * i, this.TileVerticalDistance * j + offset);
            }

            offset = (this.MapCoordsType == HexMapType.Even) ? (j.IsEven() ? this.TileHorizontalDistanceHalf : 0f) :
                                                                   (!j.IsEven() ? this.TileHorizontalDistanceHalf : 0f);
            return new Vector2(this.TileHorizontalDistance * i + offset, this.TileVerticalDistance * j);
        }

        #endregion Methods

        #region Private Methods

        private void ComputeBounds()
        {
            if (this.TilesType == HexTileType.FlatTopped)
            {
                TileWidth = 2f * this.TilesRadius;
                TileHorizontalDistance = TileWidth * 3f * 0.25f;

                TileHeight = (float)(Math.Sqrt(3.0) * 0.5) * TileWidth;
                TileVerticalDistance = TileHeight;

                this.MapWidth = (1 + TilesCountX) * TileHorizontalDistance;
                this.MapHeight = (1 + TilesCountY) * TileHeight;
            }
            else
            {
                TileHeight = this.TilesRadius * 2f;
                TileVerticalDistance = TileHeight * 3f / 4f;

                TileWidth = (float)(Math.Sqrt(3) * 0.5 * TileHeight);
                TileHorizontalDistance = TileWidth;

                this.MapWidth = (1+TilesCountX) * TileWidth;
                this.MapHeight = (1+TilesCountY) * TileVerticalDistance;
            }

            TileHorizontalDistanceHalf = TileHorizontalDistance * 0.5f;
            TileVerticalDistanceHalf = TileVerticalDistance * 0.5f;
        }

        #endregion Private Methods

        #region Properties

        public List<MapLayer> Layers { get; private set; }

        public HexMapType MapCoordsType { get; private set; }
        public HexTileType TilesType { get; private set; }

        public int TilesCountX { get; private set; }
        public int TilesCountY { get; private set; }

        public float TilesRadius { get; private set; }

        public float TileWidth { get; private set; }
        public float TileHeight { get; private set; }
        public float TileHorizontalDistance { get; private set; }
        public float TileHorizontalDistanceHalf { get; private set; }
        public float TileVerticalDistance { get; private set; }
        public float TileVerticalDistanceHalf { get; private set; }

        public float MapWidth { get; private set; }
        public float MapHeight { get; private set; }

        #endregion Properties
    }
}
