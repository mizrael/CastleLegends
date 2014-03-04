using Microsoft.Xna.Framework;

namespace CastleLegends.Common
{
    public class Tile : TileBase
    {
        public Tile(int indexX, int indexY) : base(indexX, indexY){
            
        }

        #region Properties

        public Tileset Tileset { get; set; }

        public Rectangle TextureSourceBounds { get; set; }        
        
        #endregion Properties

        public override TileBase Clone()
        {
            return new Tile(this.IndexX, this.IndexY)
            {
                Tileset = this.Tileset,
                TextureSourceBounds = this.TextureSourceBounds
            };
        }
    }
}
