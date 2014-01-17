using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlyphEngine.GameScreens;
using GlyphEngine.Services;
using GlyphEngine.Extensions;
using Microsoft.Xna.Framework;
using CastleLegends.SceneNodes;

namespace CastleLegends.GameScreens
{
    public class PlayScreen : GameBasicScreen
    {
        public override void LoadContent()
        {
            base.LoadContent();
            
            var sceneGraph = ScreenManager.Instance.Game.Services.GetService<ISceneGraphService>();

            var mapRepo = new CastleLegends.Common.Persistence.HexMapRepository();
            var mapData = mapRepo.Load(@"E:\Personale\XNA\CastleLegends\CastleLegends\test data\test_map.xml");
            var level = new Level(mapData);

            sceneGraph.AddNode(level, null);
        }

        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            if (otherScreenHasFocus || coveredByOtherScreen)
                return;

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }
    }
}
