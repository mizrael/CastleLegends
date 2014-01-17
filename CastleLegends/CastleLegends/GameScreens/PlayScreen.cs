using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GlyphEngine.GameScreens;
using Microsoft.Xna.Framework;

namespace CastleLegends.GameScreens
{
    public class PlayScreen : GameBasicScreen
    {
        public override void Update(GameTime gameTime, bool otherScreenHasFocus, bool coveredByOtherScreen)
        {
            if (otherScreenHasFocus || coveredByOtherScreen)
                return;

            base.Update(gameTime, otherScreenHasFocus, coveredByOtherScreen);
        }
    }
}
