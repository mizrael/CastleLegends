using System.IO;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.ComponentModel;
using System;

namespace CastleLegends.Editor
{
    [DisplayName("Tile Set")]
    [DefaultProperty("Asset")]
    public class Tileset : IDisposable
    {
        #region Properties

        [Category("Tile Set Properties")]
        public string Asset { get; private set; }

        [Browsable(false)]
        public Texture2D Texture { get; private set; }

        [DisplayName("Image Width")]
        [Category("Tile Set Properties")]
        public int Width { get { return (null != Texture) ? Texture.Width : 0; } }

        [DisplayName("Image Height")]
        [Category("Tile Set Properties")]
        public int Height { get { return (null != Texture) ? Texture.Height : 0; } }

        [Category("Tile Set Properties")]
        public Color Alpha { get; set; }

        [DisplayName("Tile Width")]
        [Category("Tile Set Properties")]
        public int TileWidth { get; set; }

        [DisplayName("Tile Height")]
        [Category("Tile Set Properties")]
        public int TileHeight { get; set; }

        #endregion Properties

        public override string ToString()
        {
            return System.IO.Path.GetFileName(this.Asset);
        }

        public void Dispose()
        {
            if (null != this.Texture)
                this.Texture.Dispose();
        }

        #region Factory

        public static Tileset Load(string fullPath, GraphicsDevice device) {
            using (var texStream = File.OpenRead(fullPath))
            {
                var texture = Texture2D.FromStream(device, texStream);
                if (null != texture)
                    return new Tileset() { Asset = fullPath, Texture = texture };                
            }
            return null;
        }

        #endregion Factory

    }
}
