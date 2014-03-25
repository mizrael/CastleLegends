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
    public partial class frmProperties : Form
    {
        public frmProperties()
        {
            InitializeComponent();
        }

        #region Public Methods

        public void SetObject(object data) {
            this.tabInfoPropertyGrid.Enabled = (null != data);
            this.tabInfoPropertyGrid.SelectedObject = data;
        }

        #endregion Public Methods
    }
}


