
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
        public HexTileType TilesType = HexTileType.PointyTopped;
        public HexMapType MapCoordsType = HexMapType.Odd;
        public int TilesRadius = 64;
        public int TilesCountX = 10;
        public int TilesCountY = 10;
    }
}
