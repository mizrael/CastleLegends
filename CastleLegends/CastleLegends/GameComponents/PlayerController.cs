using System;
using System.Collections.Generic;
using System.Linq;
using CastleLegends.Common;
using GlyphEngine.AI;
using GlyphEngine.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CastleLegends.GameComponents
{
    public class PlayerController : GameComponent
    {
        #region Members

        private HexMap _map;
        private MouseState _lastMouseState;

        #endregion Members

        public PlayerController(Game game)
            : base(game)
        {
            base.Enabled = false;            
        }
    }
}
