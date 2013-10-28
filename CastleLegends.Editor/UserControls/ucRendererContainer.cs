using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CastleLegends.Editor.Services;
using CastleLegends.Editor.Extensions;

namespace CastleLegends.Editor.UserControls
{
    public partial class ucRendererContainer : UserControl
    {
        private ucBaseRender _renderer = null;

        public ucRendererContainer()
        {
            InitializeComponent();
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (null == _renderer) return;
            var camera = _renderer.Services.GetService<CameraService>();
            if(null != camera) camera.Position.Y = this.vScrollBar.Value;
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            if (null == _renderer) return;
            var camera = _renderer.Services.GetService<CameraService>();
            if (null != camera) camera.Position.X = this.hScrollBar.Value;
        }

        public void SetRenderer(ucBaseRender renderer) {
            if (null != _renderer)
                this.Controls.Remove(_renderer);

            if (null == renderer) return;

            _renderer = renderer;
            _renderer.Dock = DockStyle.Fill;
            this.Controls.Add(_renderer);
        }

        public void SetScrollbars(int vMax, int hMax) {
            if (vMax > 0)
            {
                this.vScrollBar.Minimum = 0;
                this.vScrollBar.Maximum = vMax;
                this.vScrollBar.Value = 0;
                this.vScrollBar.Enabled = true;
                this.vScrollBar.Visible = true;
            }
            else
            {
                this.vScrollBar.Enabled = false;
                this.vScrollBar.Visible = false;

                 var camera = _renderer.Services.GetService<CameraService>();
                 if (null != camera) camera.Position.Y = 0;
            } 

            if (hMax > 0)
            {
                this.hScrollBar.Minimum = 0;
                this.hScrollBar.Maximum = hMax;
                this.hScrollBar.Value = 0;
                this.hScrollBar.Enabled = true;
                this.hScrollBar.Visible = true;
            }
            else {
                this.hScrollBar.Enabled = false;
                this.hScrollBar.Visible = false;

                var camera = _renderer.Services.GetService<CameraService>();
                if (null != camera) camera.Position.X = 0;
            }
        }
    }
}
