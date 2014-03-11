using Microsoft.Xna.Framework;

namespace CastleLegends.Common
{
    public class Tile : TileBase
    {
        public Tile(int indexX, int indexY)
            : base(indexX, indexY)
        {
            this.TextureOffset = Vector2.Zero;
            this.TextureSourceBounds = Rectangle.Empty;
        }

        #region Properties

        public Tileset Tileset;

        public Rectangle TextureSourceBounds;

        public Vector2 TextureOffset;
        
        #endregion Properties

        public override TileBase Clone()
        {
            return new Tile(this.IndexX, this.IndexY)
            {
                Tileset = this.Tileset,
                TextureSourceBounds = this.TextureSourceBounds,
                TextureOffset = this.TextureOffset
            };
        }
    }
}
