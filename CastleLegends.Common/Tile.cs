using Microsoft.Xna.Framework;

namespace CastleLegends.Common
{
    public class Tile
    {
        public Tile(int indexX, int indexY) {
            this.IndexX = indexX;
            this.IndexY = indexY;
        }

        #region Properties

        public int IndexX { get; private set; }

        public int IndexY { get; private set; }

        public Tileset Tileset { get; set; }

        public Rectangle TextureSourceBounds { get; set; }        
        
        #endregion Properties

        public Tile Clone() {
            return new Tile(this.IndexX, this.IndexY)
            {
                Tileset = this.Tileset,
                TextureSourceBounds = this.TextureSourceBounds
            };
        }
    }
}
