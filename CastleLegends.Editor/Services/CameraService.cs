using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor.Services
{
    public class CameraService : IUpdateable
    {
        #region Members

        Vector3 _pos3 = Vector3.Zero;

        Matrix _scaleMatrix;

        GraphicsDevice _device;

        private bool _enabled = true;
        private int _updateOrder = 0;

        #endregion Members

        public CameraService(GraphicsDevice device)
        {
            _device = device;
        }

        public void Initialize()
        {
            this.ScreenSize = new Vector2(_device.Viewport.Width, _device.Viewport.Height);

            this.HalfScreenSize = this.ScreenSize * .5f;
        }

        public void Update(GameTime gameTime)
        {
            _pos3.X = -Position.X;
            _pos3.Y = -Position.Y;

            Matrix.CreateTranslation(ref _pos3, out this.Matrix);
            Matrix.CreateScale(this.Zoom, this.Zoom, 1, out _scaleMatrix);
            Matrix.Multiply(ref this.Matrix, ref _scaleMatrix, out this.Matrix);

            Matrix.Invert(ref this.Matrix, out this.InverseMatrix);
        }

        #region Properties

        public Vector2 Position = Vector2.Zero;
        public float Zoom = 1f;
        public Matrix Matrix;
        public Matrix InverseMatrix;
        public Vector2 ScreenSize = Vector2.Zero;
        public Vector2 HalfScreenSize = Vector2.Zero;

        #endregion Properties

        public bool Enabled
        {
            get { return _enabled; }
            set
            {
                _enabled = value;
                if (null != this.EnabledChanged) EnabledChanged(this, null);
            }
        }

        public event System.EventHandler<System.EventArgs> EnabledChanged;

        public int UpdateOrder
        {
            get { return _updateOrder; }
            set
            {
                _updateOrder = value;
                if (null != this.UpdateOrderChanged) UpdateOrderChanged(this, null);
            }
        }

        public event System.EventHandler<System.EventArgs> UpdateOrderChanged;
    }
}
