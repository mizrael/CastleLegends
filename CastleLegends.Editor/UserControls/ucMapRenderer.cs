using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CastleLegends.Editor.Services;
using CastleLegends.Common.Utils;
using CastleLegends.Common;
using System;

namespace CastleLegends.Editor.UserControls
{
    public partial class ucMapRenderer : ucBaseRender
    { 
        #region Members

        private HexMap _mapData;

        private SpriteBatch _spriteBatch = null;

        private CameraService _camera;

        #endregion Members

        public ucMapRenderer(HexMap mapData)
        {
            if (null == mapData)
                throw new ArgumentNullException("mapData");
            _mapData = mapData;

            InitializeComponent();
        }

        #region Public Methods

        #endregion Public Methods

        #region Private Methods

        protected override void Initialize()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _camera = new CameraService(this.GraphicsDevice);
            base.Services.AddService<CameraService>(_camera);      
        }

        protected override void Update()
        {
            _camera.Update();
        }

        /// <summary>
        /// http://www.redblobgames.com/grids/hexagons/
        /// </summary>
        protected override void Draw()
        {
            base.GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, _camera.Matrix);

            float height =  _mapData.TilesRadius * 2;
            float vertDist = (height * 3f)/4;
            
            float width = height * (float)Math.Sqrt(3) / 2;            
            float horDist = width;
            
            
            for (int x = 0; x != _mapData.TilesCountX; ++x)
            {
                for (int y = 0; y != _mapData.TilesCountY; ++y) {
                    var pos = new Vector2(horDist * x, vertDist * y);
                    _spriteBatch.DrawHexagon(pos, _mapData.TilesRadius, Color.Green, _mapData.TilesType);
                }
            }           
        
            _spriteBatch.End();
        }

        #endregion Private Methods
    }
}
