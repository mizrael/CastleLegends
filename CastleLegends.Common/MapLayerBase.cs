using System;

namespace CastleLegends.Common
{
    public class MapLayerBase<TTile> where TTile : TileBase
    {
        private Func<int, int, TTile> _tileCreator;

        public MapLayerBase(int countX, int countY, string name, Func<int,int,TTile> tileCreator)
        {
            _tileCreator = tileCreator;
            this.Name = name;

            InitTiles(countX, countY);            
        }

        #region Private Methods

        private void InitTiles(int countX, int countY)
        {
            this.Tiles = new TTile[countX, countY];
            for (int y = 0; y != countY; ++y)
                for (int x = 0; x != countX; ++x)
                    this.Tiles[x, y] = _tileCreator(x, y);
        }

        #endregion Private Methods

        #region Methods

        public override string ToString()
        {
            return this.Name;
        }

        #endregion Methods

        #region Properties

        public string Name { get; set; }

        public TTile[,] Tiles { get; private set; }

        #endregion Properties
    }
}
