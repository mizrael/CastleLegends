using System.IO;
using CastleLegends.Common;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor
{ 
    public static class TilesetFactory
    {
        public static Tileset Load(string fullPath, GraphicsDevice device)
        {
            using (var texStream = File.OpenRead(fullPath))
            {
                var texture = Texture2D.FromStream(device, texStream);
                if (null != texture)
                    return new Tileset(fullPath, texture);
            }
            return null;
        }
    }
}
