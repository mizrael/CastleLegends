using System.Collections.Generic;
using System.Linq;

namespace CastleLegends.Common
{
    public class MapLayer
    {
        public MapLayer(int countX, int countY, string name)
        {
            InitTiles(countX, countY);

            this.Name = name;
            this.Visible = true;
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

        public bool Visible { get; set; }

        public Tile[,] Tiles { get; private set; }

        #endregion Properties

    }
}
