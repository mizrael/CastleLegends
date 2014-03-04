using CastleLegends.GameComponents;
using CastleLegends.SceneNodes;
using GlyphEngine.Extensions;
using GlyphEngine.GameScreens;
using GlyphEngine.Services;
using Microsoft.Xna.Framework;

namespace CastleLegends.GameScreens
{
    public class PlayScreen : GameBasicScreen
    {
        private MapInputController _mapInput;
        
        public PlayScreen()
        {
            var camera = new CameraService(ScreenManager.Instance.Game);
            ScreenManager.Instance.Game.Components.Add(camera);
            ScreenManager.Instance.Game.Services.AddService(typeof(CameraService), camera);

            _mapInput = new MapInputController(ScreenManager.Instance.Game);
            ScreenManager.Instance.Game.Components.Add(_mapInput);
        }
                
        public override void LoadContent()
        {
            base.LoadContent();
            
            var sceneGraph = ScreenManager.Instance.Game.Services.GetService<ISceneGraphService>();
            
            var mapRepo = new CastleLegends.Common.Persistence.HexMapRepository();
            var mapData = mapRepo.Load(@"E:\Personale\XNA\CastleLegends\CastleLegends\test data\test_map.xml");
            var level = new Level(mapData);

            _mapInput.SetMap(mapData);

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
