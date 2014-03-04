
namespace CastleLegends.Common
{
    public class TileBase
    {
        public TileBase(int indexX, int indexY)
        {
            this.IndexX = indexX;
            this.IndexY = indexY;
        }

        #region Properties

        public int IndexX { get; private set; }

        public int IndexY { get; private set; }
        
        #endregion Properties

        public virtual TileBase Clone()
        {
            return new TileBase(this.IndexX, this.IndexY);            
        }
    }
}
