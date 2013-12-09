using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

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

    public class MapLayer
    {
        public MapLayer(int countX, int countY, string name) {
            InitTiles(countX, countY);

            this.Name = name;
        }

        #region Private Methods

        private void InitTiles(int countX, int countY)
        {
            this.Tiles = new Tile[countX, countY];
            for (int y = 0; y != countY; ++y)
                for (int x = 0; x != countX; ++x)
                    this.Tiles[x, y] = new Tile(x, y);
        }

        #endregion Private Methods

        #region Methods

        public IEnumerable<Tileset> GetTilesets()
        {
            return this.Tiles.Cast<Tile>().Where(t => null != t.Tileset)
                                            .Select(t => t.Tileset)
                                            .Distinct()
                                            .ToArray();
        }

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods

        #region Properties

        public string Name { get; set; }

        public Tile[,] Tiles { get; private set; }

        #endregion Properties

    }
}
