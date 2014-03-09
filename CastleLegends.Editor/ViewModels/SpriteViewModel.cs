using System;
using System.ComponentModel;
using CastleLegends.Common;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor.RenderModels
{
    [DisplayName("SpriteViewModel")]
    [DefaultProperty("SpriteViewModel.Asset")]
    public class SpriteViewModel : IDisposable
    {
        public SpriteViewModel(Texture2D texture)
        {          
            if (null == texture) throw new ArgumentNullException("texture");
           
            this.Texture = texture;
        }

        #region Properties
        
        [Browsable(false)]
        public Texture2D Texture { get; private set; }

        [DisplayName("Image Width")]
        [Category("SpriteViewModel Properties")]
        public int Width { get { return this.Texture.Width; } }

        [DisplayName("Image Height")]
        [Category("SpriteViewModel Properties")]
        public int Height { get { return this.Texture.Height; } }

        #endregion Properties

        public override string ToString()
        {
            return this.Texture.ToString();
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
