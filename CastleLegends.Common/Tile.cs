using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace CastleLegends.Common
{
    public class Tile
    {
        public Tile(int indexX, int indexY) {
            this.IndexX = indexX;
            this.IndexY = indexY;
        }

        public int IndexX { get; private set; }

        public int IndexY { get; private set; }

        public Tileset Tileset { get; set; }

        public Rectangle TextureSourceBounds { get; set; }        
    }
}
