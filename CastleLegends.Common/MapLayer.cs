using System.Collections.Generic;
using System.Linq;

namespace CastleLegends.Common
{  
    public class MapLayer : MapLayerBase<Tile>
    {
        public MapLayer(int countX, int countY, string name)
            : base(countX, countY, name, (x, y) => new Tile(x, y))
        {            
            this.Visible = true;
        }

        #region Methods

        public IEnumerable<Tileset> GetTilesets()
        {
            return this.Tiles.Cast<Tile>().Where(t => null != t.Tileset)
                                            .Select(t => t.Tileset)
                                            .Distinct()
                                            .ToArray();
        }

        #endregion Methods

        #region Properties

        public bool Visible { get; set; }

        #endregion Properties
    }
}
