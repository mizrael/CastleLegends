using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CastleLegends.Editor
{
    public partial class frmTools : Form
    {
        private List<CheckBox> _buttons;

        public frmTools()
        {
            InitializeComponent();

            _buttons = new List<CheckBox>();
            _buttons.Add(this.chkSetTileTexture);
        }

        private void chkSetTileTexture_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSetTileTexture.Checked)
                CheckTool(this.chkSetTileTexture, Tools.SetTileTexture);
            else
                UncheckTools();
        }

        #region Methods

        private void UncheckTools() {
            CheckTool(null, Tools.None);
        }

        private void CheckTool(CheckBox btnTool, Tools tool)
        {
            this.SelectedTool = tool;
            _buttons.ForEach(b => b.Checked = (btnTool == b));
        }

        #endregion Methods

        #region Properties

        public Tools SelectedTool { get; set; }

        #endregion Properties

        public enum Tools { 
            None = 0,
            SetTileTexture = 1
        }
    }

   
}


