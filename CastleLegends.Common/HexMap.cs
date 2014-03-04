using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using GlyphEngine.Extensions;

namespace CastleLegends.Common
{
    public enum HexTileType
    {
        PointyTopped,
        FlatTopped        
    }

    public enum HexMapType
    {
        Odd,
        Even
    }

    public class HexMap
    {
        
        public HexMap(HexMapType coordsType, HexTileType tilesType, int tilesCountX, int tilesCountY, float tileRadius)
        {
            this.MapCoordsType = coordsType;
            this.TilesType = tilesType;
            this.TilesCountX = tilesCountX;
            this.TilesCountY = tilesCountY;
            this.TilesRadius = tileRadius;

            this.Layers = new List<MapLayer>();

            this.AILayer = new AIMapLayer(tilesCountX, tilesCountY, "AI", tilesType);

            if (this.TilesType == HexTileType.FlatTopped)
                CoordsToTile = CoordsToTileFlatTop;
            else 
                CoordsToTile = CoordsToTilePointyTop;

            ComputeBounds();
        }

        #region Methods

        public IEnumerable<Tileset> GetTilesets()
        {
            var allTilesets = this.Layers.SelectMany(l => l.GetTilesets());
            var distinctTilesets = allTilesets.Distinct();
            return distinctTilesets.ToArray();
        }

        public Vector2 TileToCoords(int i, int j)
        {
            var offset = 0f;
            if (this.TilesType == HexTileType.FlatTopped)
            {
                offset = (this.MapCoordsType == HexMapType.Even) ? (i.IsEven() ? this.TileVerticalDistanceHalf : 0f) :
                                                                           (!i.IsEven() ? this.TileVerticalDistanceHalf : 0f);
                return new Vector2(this.TileHorizontalDistance * i, this.TileVerticalDistance * j + offset);
            }

            offset = (this.MapCoordsType == HexMapType.Even) ? (j.IsEven() ? this.TileHorizontalDistanceHalf : 0f) :
                                                                   (!j.IsEven() ? this.TileHorizontalDistanceHalf : 0f);
            return new Vector2(this.TileHorizontalDistance * i + offset, this.TileVerticalDistance * j);
        }

        /// <summary>      
        /// http://gamedev.stackexchange.com/questions/20742/how-can-i-implement-hexagonal-tilemap-picking-in-xna
        /// </summary>
        public delegate bool CoordsToTileDelegate(Vector2 screenCoords, ref Matrix cameraInverseMatrix, out int i, out int j);
        public CoordsToTileDelegate CoordsToTile { get; private set; }

        #endregion Methods

        #region Private Methods

        private void ComputeBounds()
        {
            if (this.TilesType == HexTileType.FlatTopped)
            {
                TileWidth = 2f * this.TilesRadius;
                TileHorizontalDistance = TileWidth * 3f * 0.25f;

                TileHeight = (float)(Math.Sqrt(3.0) * 0.5) * TileWidth;
                TileVerticalDistance = TileHeight;

                this.MapWidth = (1 + TilesCountX) * TileHorizontalDistance;
                this.MapHeight = (1 + TilesCountY) * TileHeight;
            }
            else
            {
                TileHeight = this.TilesRadius * 2f;
                TileVerticalDistance = TileHeight * 3f / 4f;

                TileWidth = (float)(Math.Sqrt(3) * 0.5 * TileHeight);
                TileHorizontalDistance = TileWidth;

                this.MapWidth = (1+TilesCountX) * TileWidth;
                this.MapHeight = (1+TilesCountY) * TileVerticalDistance;
            }

            TileHorizontalDistanceHalf = TileHorizontalDistance * 0.5f;
            TileVerticalDistanceHalf = TileVerticalDistance * 0.5f;
        }
        
        private bool CoordsToTileFlatTop(Vector2 screenCoords, ref Matrix cameraInverseMatrix, out int i, out int j)
        {
            Vector2.Transform(ref screenCoords, ref cameraInverseMatrix, out screenCoords);

            var _k = (this.TileWidth + this.TilesRadius) * .5f;

            i = (int)Math.Floor(screenCoords.X / _k);
            j = (int)Math.Floor((screenCoords.Y * 2f) / this.TileHeight);

            var u = screenCoords.X - (_k * i);
            var v = screenCoords.Y - (this.TileHeight * j * 0.5f);

            var is_i_even = i.IsEven();

            var isGreenArea = (u < (this.TileWidth - this.TilesRadius) * 0.5f);
            if (isGreenArea)
            {
                var is_j_even = j.IsEven();

                var sum = ((i + j) & 1);
                var isUpper = (this.MapCoordsType == HexMapType.Even) ? (0 != sum) : (0 == sum);

                u = (2f * u) / (this.TileWidth - this.TilesRadius);
                v = (2f * v) / this.TileHeight;

                if ((!isUpper && v > u) || (isUpper && (1f - v) > u))
                {
                    i--;
                    is_i_even = !is_i_even;
                }
            }

            if ((this.MapCoordsType == HexMapType.Even && is_i_even) || (this.MapCoordsType == HexMapType.Odd && !is_i_even))
                j--;

            j = (int)Math.Floor(j * 0.5);

            if (i < 0 || i >= this.TilesCountX) return false;
            if (j < 0 || j >= this.TilesCountY) return false;

            return true;
        }

        private bool CoordsToTilePointyTop(Vector2 screenCoords, ref Matrix cameraInverseMatrix, out int i, out int j)
        {
            Vector2.Transform(ref screenCoords, ref cameraInverseMatrix, out screenCoords);

            var _k = (this.TileHeight + this.TilesRadius) * .5f;

            i = (int)Math.Floor((screenCoords.X * 2f) / this.TileWidth);
            j = (int)Math.Floor(screenCoords.Y / _k);

            var is_j_even = j.IsEven();

            var u = screenCoords.X - (this.TileWidth * i * 0.5f);
            var v = screenCoords.Y - (_k * j);

            var isGreenArea = (v < (this.TileHeight - this.TilesRadius) * 0.5f);
            if (isGreenArea)
            {
                var is_i_even = i.IsEven();

                var sum = ((i + j) & 1);
                var isLeft = (this.MapCoordsType == HexMapType.Even) ? (0 != sum) : (0 == sum);

                u = (2f * u) / this.TileHeight;
                v = (2f * v) / (this.TileWidth - this.TilesRadius);

                if ((!isLeft && u > v) || (isLeft && (1f - u) > v))
                {
                    j--;
                    is_j_even = !is_j_even;
                }
            }

            if ((this.MapCoordsType == HexMapType.Even && is_j_even) || (this.MapCoordsType == HexMapType.Odd && !is_j_even))
                i--;

            i = (int)Math.Floor(i * 0.5);

            if (i < 0 || i >= this.TilesCountX) return false;
            if (j < 0 || j >= this.TilesCountY) return false;

            return true;
        }


        #endregion Private Methods

        #region Properties

        public List<MapLayer> Layers { get; private set; }

        public AIMapLayer AILayer { get; private set; }       

        public HexMapType MapCoordsType { get; private set; }
        public HexTileType TilesType { get; private set; }

        public int TilesCountX { get; private set; }
        public int TilesCountY { get; private set; }

        public float TilesRadius { get; private set; }

        public float TileWidth { get; private set; }
        public float TileHeight { get; private set; }
        public float TileHorizontalDistance { get; private set; }
        public float TileHorizontalDistanceHalf { get; private set; }
        public float TileVerticalDistance { get; private set; }
        public float TileVerticalDistanceHalf { get; private set; }

        public float MapWidth { get; private set; }
        public float MapHeight { get; private set; }

        #endregion Properties
    }
}
