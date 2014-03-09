using System;
using System.ComponentModel;
using CastleLegends.Common;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor.RenderModels
{
    [DisplayName("Tile Set")]
    [DefaultProperty("Tileset.Asset")]
    public class TilesetViewModel : SpriteViewModel
    {
        public TilesetViewModel(Tileset tileset, Texture2D texture) : base(texture)
        {
            if (null == tileset) throw new ArgumentNullException("tilset");
            this.Tileset = tileset;
        }

        #region Properties

        [DisplayName("Asset")]
        [Category("SpriteViewModel Properties")]
        public Tileset Tileset { get; private set; }
    
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
    }
}
