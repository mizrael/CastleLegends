using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor
{
    public class Texture2DInfo
    {
        #region Properties

        public string Asset { get; private set; }
        public Texture2D Texture { get; private set; }

        #endregion Properties

        #region Factory

        public static Texture2DInfo Load(string asset, GraphicsDevice device) {
            var fullPath = Path.Combine(Application.StartupPath, asset);
            using (var texStream = File.OpenRead(fullPath))
            {
                var texture = Texture2D.FromStream(device, texStream);
                if (null != texture) 
                    return new Texture2DInfo() { Asset = asset, Texture = texture };                
            }
            return null;
        }

        #endregion Factory
    }
}
