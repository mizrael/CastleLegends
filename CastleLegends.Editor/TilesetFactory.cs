﻿using System;
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

        public static TilesetRenderModel Get(Tileset tileset, GraphicsDevice device)
        {
            if (null == tileset)
                throw new ArgumentNullException("tileset");

            TilesetRenderModel model = null;
            if (!_cache.TryGetValue(tileset.ID, out model)) 
                model = Load(tileset, device);                
            
            return model;
        }

        public static TilesetRenderModel Load(Tileset tileset, GraphicsDevice device)
        {
            if (null == tileset)
                throw new ArgumentNullException("tileset");
            if (null == device)
                throw new ArgumentNullException("device");

            using (var texStream = File.OpenRead(tileset.Asset))
            {
                var texture = Texture2D.FromStream(device, texStream);
                if (null != texture)
                {
                    var model = new TilesetRenderModel(tileset, texture);
                    _cache.Add(model.Tileset.ID, model);
                    return model;
                }
            }
            return null;
        }

        public static TilesetRenderModel Load(string fullPath, GraphicsDevice device)
        {
            var tileset = new Tileset(fullPath);
            return Load(tileset, device);           
        }
    }
}
