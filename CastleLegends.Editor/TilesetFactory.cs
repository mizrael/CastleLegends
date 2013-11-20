using System;
using System.Collections.Generic;
using System.IO;
using CastleLegends.Common;
using CastleLegends.Common.RenderModels;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor
{ 
    public static class TilesetFactory
    {
        private static Dictionary<Guid, TilesetRenderModel> _cache = new Dictionary<Guid, TilesetRenderModel>();

        public static TilesetRenderModel Get(Guid id) {
            TilesetRenderModel model = null;
            _cache.TryGetValue(id, out model);
            return model;
        }

        public static TilesetRenderModel Load(string fullPath, GraphicsDevice device)
        {
            using (var texStream = File.OpenRead(fullPath))
            {
                var texture = Texture2D.FromStream(device, texStream);
                if (null != texture)
                {
                   var model = new TilesetRenderModel(new Tileset(fullPath), texture);
                   _cache.Add(model.Tileset.ID, model);
                   return model;
                }
            }
            return null;
        }
    }
}
