using System;
using System.ComponentModel;
using CastleLegends.Common;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor.RenderModels
{
    [DisplayName("Tile Set")]
    [DefaultProperty("Tileset.Asset")]
    public class TilesetRenderModel : Sprite
    {
        public TilesetRenderModel(Tileset tileset, Texture2D texture) : base(tileset, texture)
        {          
        }

        #region Properties
    
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
