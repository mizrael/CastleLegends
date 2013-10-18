
using System;
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

            ComputeBounds();
        }

        #region Private Methods

        private void ComputeBounds()
        {
            if (this.TilesType == HexTileType.FlatTopped)
            {
                TileWidth = 2f * this.TilesRadius;
                TileHorizontalDistance = TileWidth * 3f * 0.25f;

                TileHeight = (float)(Math.Sqrt(3.0) * 0.5) * TileWidth;
                TileVerticalDistance = TileHeight;
            }
            else
            {
                TileHeight = this.TilesRadius * 2f;
                TileVerticalDistance = TileHeight * 3f / 4f;

                TileWidth = (float)(Math.Sqrt(3) * 0.5 * TileHeight);
                TileHorizontalDistance = TileWidth;
            }

            TileHorizontalDistanceHalf = TileHorizontalDistance * 0.5f;
            TileVerticalDistanceHalf = TileVerticalDistance * 0.5f;
        }

        #endregion Private Methods

        #region Properties

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

        #endregion Properties
    }
}
