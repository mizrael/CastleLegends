using Microsoft.Xna.Framework;

namespace CastleLegends.Common
{
    public class AITile : TileBase
    {
        public AITile(int indexX, int indexY)
            : base(indexX, indexY)
        {
            this.TileType = AITileTypes.Walkable;
        }

        #region Properties

        public AITileTypes TileType { get; set; }

        #endregion Properties

        public override TileBase Clone()
        {
            return new AITile(this.IndexX, this.IndexY)
            {
              
            };
        }

        public enum AITileTypes
        {
            Walkable = 0,
            Wall,
        }
    }
}
