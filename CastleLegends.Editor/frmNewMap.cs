using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CastleLegends.Common;

namespace CastleLegends.Editor
{
    public partial class frmNewMap : Form
    {
        public frmNewMap()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmNewMap_Load);
        }

        void frmNewMap_Load(object sender, EventArgs e)
        {
            this.cmbHexType.Items.Add(HexTileType.FlatTopped);
            this.cmbHexType.Items.Add(HexTileType.PointyTopped);
            this.cmbHexType.SelectedIndex = 0;            

            this.cmbMapCoordsType.Items.Add(HexMapType.Even);
            this.cmbMapCoordsType.Items.Add(HexMapType.Odd);
            this.cmbMapCoordsType.SelectedIndex = 0;
        }

        public int TileCountX
        {
            get { return (int)_tileCountX.Value; }
        }

        public int TileCountY
        {
            get { return (int)_tileCountY.Value; }
        }

        public int TileRadius
        {
            get { return (int)_tileRadius.Value; }
        }

        public HexMapType HexMapType
        {
            get { return (HexMapType)this.cmbMapCoordsType.SelectedItem; }
        }

        public HexTileType HexTileType
        {
            get { return (HexTileType)cmbHexType.SelectedItem; }
        }
    }
}
