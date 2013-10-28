using System;
using System.ComponentModel;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Common
{
    [DisplayName("Tile Set")]
    [DefaultProperty("Asset")]
    public class Tileset : IDisposable
    {
        public Tileset(string filename, Texture2D texture) :this(filename, texture, 32, 32) { 
        }

        public Tileset(string filename, Texture2D texture, int tileWidth, int tileHeight) {
            this.Asset = filename;
            this.Texture = texture;

            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
        }

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

        [DisplayName("Tile Count on X")]
        [Category("Tile Set Properties")]
        public int TilesCountX {
            get { return (null != Texture) ? this.Width / this.TileWidth : 0; }
        }

        [DisplayName("Tile Count on Y")]
        [Category("Tile Set Properties")]
        public int TilesCountY
        {
            get { return (null != Texture) ? this.Height / this.TileHeight : 0; }
        }

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
    }

}
