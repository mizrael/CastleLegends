using System;
using System.Linq;
using System.Windows.Forms;
using CastleLegends.Common;

namespace CastleLegends.Editor
{
    public partial class frmMain
    {
        #region Map Layers Tab events

        private void btnAddMapLayer_Click(object sender, EventArgs e)
        {
            AddMapLayer();
        }        

        private void chklMapLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var layer = this.chklMapLayers.Items[e.Index] as MapLayer;
            if (null == layer)
                return;

            layer.Visible = (e.NewValue == CheckState.Checked);
        }

        private void btnMapLayerUp_Click(object sender, EventArgs e)
        {

        }

        private void btnMapLayerDown_Click(object sender, EventArgs e)
        {

        }
        
        #endregion Map Layers Tab events

        #region Private Methods

        private void BindMapLayers()
        {
            if (null == _mapData.Layers || !_mapData.Layers.Any())
                return;

            this.chklMapLayers.Items.AddRange(_mapData.Layers.ToArray());
            for (int i = 0; i != _mapData.Layers.Count; ++i)
                this.chklMapLayers.SetItemChecked(i, _mapData.Layers[i].Visible);
        }

        private MapLayer GetCurrentLayer()
        {
            var selLayer = this.chklMapLayers.SelectedItem as MapLayer;
            return selLayer ?? _mapData.Layers.FirstOrDefault();
        }

        private void AddMapLayer()
        {
            var name = "Layer " + (_mapData.Layers.Count + 1).ToString();

            var newLayer = new MapLayer(_mapData.TilesCountX, _mapData.TilesCountY, name);
            _mapData.Layers.Add(newLayer);

            this.chklMapLayers.Items.Add(newLayer, true);
            this.chklMapLayers.SelectedIndex = this.chklMapLayers.Items.Count - 1;
        }

        #endregion Private Methods

    }
}
