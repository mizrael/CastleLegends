using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;

namespace CastleLegends.Common
{    
    public class Tileset 
    {
        public Tileset(string filename) : this(filename, 32, 32) { 
        }

        public Tileset(string filename, int tileWidth, int tileHeight) : this( Guid.NewGuid(), filename, 32, 32) { }

        public Tileset(Guid id, string filename, int tileWidth, int tileHeight) {
            this.Asset = filename;

            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;

            this.ID = id;
        }

        #region Properties

        public Guid ID { get; private set; }

        [Category("Tile Set Properties")]
        public string Asset { get; private set; }
        
        [DisplayName("Tile Width")]
        [Category("Tile Set Properties")]
        public int TileWidth { get; set; }

        [DisplayName("Tile Height")]
        [Category("Tile Set Properties")]
        public int TileHeight { get; set; }

        [Category("Tile Set Properties")]
        public Color Alpha { get; set; }

        #endregion Properties

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override string ToString()
        {
            return System.IO.Path.GetFileName(this.Asset);
        }
    }
       
}
