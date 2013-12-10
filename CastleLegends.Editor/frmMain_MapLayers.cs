using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CastleLegends.Common;
using CastleLegends.Editor.Extensions;

namespace CastleLegends.Editor
{
    public partial class frmMain
    {
        #region Map Layers Tab events
        
        private void chklMapLayers_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var layer = this.chklMapLayers.Items[e.Index] as MapLayer;
            if (null == layer)
                return;

            layer.Visible = (e.NewValue == CheckState.Checked);
        }

        private void btnAddMapLayer_Click(object sender, EventArgs e)
        {
            AddMapLayer();
        }

        private void btnRemoveMapLayer_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure?", "Remove layer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;
            var layer = GetCurrentLayer();
            if (null != layer)
                RemoveMapLayer(layer);
        }

        private void btnMapLayerUp_Click(object sender, EventArgs e)
        {
            var destIndex = this.chklMapLayers.SelectedIndex - 1;
            _mapData.Layers.Swap(this.chklMapLayers.SelectedIndex, destIndex);
            BindMapLayers();
            this.chklMapLayers.SelectedIndex = destIndex;
        }

        private void btnMapLayerDown_Click(object sender, EventArgs e)
        {
            var destIndex = this.chklMapLayers.SelectedIndex + 1;
            _mapData.Layers.Swap(this.chklMapLayers.SelectedIndex, destIndex);
            BindMapLayers();
            this.chklMapLayers.SelectedIndex = destIndex;
        }

        #endregion Map Layers Tab events

        #region Private Methods

        private void BindMapLayers()
        {
            this.chklMapLayers.Items.Clear();
            this.btnMapLayerDown.Enabled = false;
            this.btnMapLayerUp.Enabled = false;

            if (null == _mapData.Layers || !_mapData.Layers.Any())
                return;

            this.chklMapLayers.Items.AddRange(_mapData.Layers.ToArray());
            for (int i = 0; i != _mapData.Layers.Count; ++i)
                this.chklMapLayers.SetItemChecked(i, _mapData.Layers[i].Visible);

            if (_mapData.Layers.Count > 1)
            {
                this.btnMapLayerDown.Enabled = true;
                this.btnMapLayerUp.Enabled = true;
            }
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

            this.btnMapLayerDown.Enabled = true;
            this.btnMapLayerUp.Enabled = true;
        }

        private void RemoveMapLayer(MapLayer layer) {            
            _mapData.Layers.Remove(layer);
            BindMapLayers();
        }

        #endregion Private Methods

    }
}
