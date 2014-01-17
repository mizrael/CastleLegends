using System;
using System.ComponentModel;
using CastleLegends.Common;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor.RenderModels
{
    [DisplayName("Tile Set")]
    [DefaultProperty("Tileset.Asset")]
    public class TilesetRenderModel : IDisposable
    {
        public TilesetRenderModel(Tileset tileset, Texture2D texture)
        {
            if (null == tileset) throw new ArgumentNullException("tilset");
            if (null == texture) throw new ArgumentNullException("texture");
            this.Tileset = tileset;
            this.Texture = texture;
        }

        #region Properties
                
        [DisplayName("Asset")]
        [Category("Tile Set Properties")]
        public Tileset Tileset { get; private set; }

        [Browsable(false)]
        public Texture2D Texture { get; private set; }

        [DisplayName("Tile Width")]
        [Category("Tile Set Properties")]
        public int TileWidth
        {
            get { return (null != Tileset) ? Tileset.TileWidth : 0; }
            set { if (null != Tileset) Tileset.TileWidth = value; }
        }

        [DisplayName("Tile Height")]
        [Category("Tile Set Properties")]
        public int TileHeight
        {
            get { return (null != Tileset) ? Tileset.TileHeight : 0; }
            set { if (null != Tileset) Tileset.TileHeight = value; }
        }

        [DisplayName("Image Width")]
        [Category("Tile Set Properties")]
        public int Width { get { return (null != Texture) ? Texture.Width : 0; } }

        [DisplayName("Image Height")]
        [Category("Tile Set Properties")]
        public int Height { get { return (null != Texture) ? Texture.Height : 0; } }

        [DisplayName("Tile Count on X")]
        [Category("Tile Set Properties")]
        public int TilesCountX
        {
            get { return (null != Texture) ? this.Width / this.Tileset.TileWidth : 0; }
        }

        [DisplayName("Tile Count on Y")]
        [Category("Tile Set Properties")]
        public int TilesCountY
        {
            get { return (null != Texture) ? this.Height / this.Tileset.TileHeight : 0; }
        }

        #endregion Properties

        public override string ToString()
        {
            return this.Tileset.ToString();
        }

        public void Dispose()
        {
            if (null != this.Texture)
            {
                this.Texture.Dispose();
                this.Texture = null;
            }
        }
    }
}
