using System;
using System.Collections.Generic;
using System.IO;
using CastleLegends.Common;
using CastleLegends.Editor.RenderModels;
using GlyphEngine.Utils;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor
{ 
    public static class TilesetFactory
    {
        private static Dictionary<Guid, TilesetViewModel> _cache = new Dictionary<Guid, TilesetViewModel>();

        public static TilesetViewModel Get(Tileset tileset, GraphicsDevice device)
        {
            if (null == tileset)
                throw new ArgumentNullException("tileset");

            TilesetViewModel model = null;
            if (!_cache.TryGetValue(tileset.ID, out model)) 
                model = Load(tileset, device);                
            
            return model;
        }

        public static TilesetViewModel Load(string fullPath, GraphicsDevice device)
        {
            var tileset = new Tileset(fullPath);
            return Load(tileset, device);
        }

        private static TilesetViewModel Load(Tileset tileset, GraphicsDevice device)
        {
            if (null == tileset)
                throw new ArgumentNullException("tileset");
            if (null == device)
                throw new ArgumentNullException("device");

            var texture = TextureHelpers.LoadTexture(device, tileset.Asset);
            if (null != texture)
            {
                var model = new TilesetViewModel(tileset, texture);
                _cache.Add(model.Tileset.ID, model);
                return model;
            }
            return null;
        }
    }
}
