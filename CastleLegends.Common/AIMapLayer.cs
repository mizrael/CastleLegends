﻿using System.Collections.Generic;
using GlyphEngine.Extensions;

namespace CastleLegends.Common
{
    public class AIMapLayer : MapLayerBase<AITile>
    {
        public AIMapLayer(int countX, int countY, string name)
            : base(countX, countY, name, (x,y) =>new AITile(x,y))
        {

        }

        public IEnumerable<AITile> GetNeighbours(AITile tile)
        {
            var indexes_even = new[]{
                new[]{-1,-1}, new[]{0,-1}, new[]{1,-1},
                new[]{-1, 0}, new[] {0, 1}, new[]{1, 0},                            
            };

            var indexes_odd = new[]{
                new[]{-1,0}, new[]{0,-1}, new[]{1,0},
                new[]{-1, 1}, new[] {0, 1}, new[]{1, 1},                            
            };
            
            var indexes = tile.IndexX.IsEven() ? indexes_even : indexes_odd;

            var maxX = this.Tiles.GetLength(0);
            var maxY = this.Tiles.GetLength(1);

            for (int i = 0; i != indexes.Length; ++i)
            {
                var nx = indexes[i][0] + tile.IndexX;
                var ny = indexes[i][1] + tile.IndexY;
                if (nx >= 0 && ny >= 0 && nx < maxX && ny < maxY)
                    yield return this.Tiles[nx, ny];
            }
        }

    }
}
