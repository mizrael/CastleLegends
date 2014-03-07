using System;
using System.ComponentModel;
using CastleLegends.Common;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor.RenderModels
{
    [DisplayName("Sprite")]
    [DefaultProperty("Sprite.Asset")]
    public class Sprite
    {
        public Sprite(Tileset tileset, Texture2D texture)
        {
            if (null == tileset) throw new ArgumentNullException("tilset");
            if (null == texture) throw new ArgumentNullException("texture");
            this.Tileset = tileset;
            this.Texture = texture;
        }

        #region Properties

        [DisplayName("Asset")]
        [Category("Sprite Properties")]
        public Tileset Tileset { get; private set; }

        [Browsable(false)]
        public Texture2D Texture { get; private set; }

        [DisplayName("Image Width")]
        [Category("Sprite Properties")]
        public int Width { get { return (null != Texture) ? Texture.Width : 0; } }

        [DisplayName("Image Height")]
        [Category("Sprite Properties")]
        public int Height { get { return (null != Texture) ? Texture.Height : 0; } }

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
