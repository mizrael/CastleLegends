using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CastleLegends.Common;
using GlyphEngine.Components;
using GlyphEngine.GameScreens;
using GlyphEngine.SceneGraph;
using GlyphEngine.Services;
using GlyphEngine.Extensions;
using GlyphEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using GlyphEngine.Core;
using GlyphEngine.Utils;

namespace CastleLegends.SceneNodes
{
    public class Level : SceneNode
    {
        #region Members

        private HexMap _mapData;
        private TransformComponent _transfComp = null;
        
        #endregion Members

        public Level(HexMap mapData)
        {
            if (null == mapData)
                throw new ArgumentNullException("mapData");
            _mapData = mapData;
            
            var sceneGraph = ScreenManager.Instance.Game.Services.GetService<ISceneGraphService>();

            _transfComp = new TransformComponent(this);

            foreach (var layer in _mapData.Layers)
            {
                var layerNode = new SceneNode();

                var transfComp = new TransformComponent(layerNode);
                var renderComp = new RenderComponent(layerNode);
                renderComp.Active = true;
                renderComp.Visible = true;
                renderComp.Model = new LevelLayerRenderModel(_mapData, layer);
                renderComp.LayerDepth = ObjectsDepthEnum.LevelDepth;

                sceneGraph.AddNode(layerNode, this);
            }
        }
    }

    
}
