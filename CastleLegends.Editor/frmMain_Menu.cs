using System;
using System.Linq;
using System.Windows.Forms;
using CastleLegends.Common;


namespace CastleLegends.Editor
{
    public partial class frmMain
    {
        #region Menu Events

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == _mapData) return;

            var sfd = new SaveFileDialog();
            sfd.RestoreDirectory = false;
            sfd.Title = "Save Map";
            sfd.DefaultExt = ".xml";
            var result = sfd.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            var repo = new CastleLegends.Common.Persistence.HexMapRepository();
            repo.Save(_mapData, sfd.FileName);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMap();

            var ofd = new OpenFileDialog();
            ofd.Title = "Open Map";
            ofd.DefaultExt = ".xml";
            var result = ofd.ShowDialog();
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            var repo = new CastleLegends.Common.Persistence.HexMapRepository();
            _mapData = repo.Load(ofd.FileName);
            if (null != _mapData)
            {
                ResetUIForNewMap();

                InitRenderer();

                var tilesets = _mapData.GetTilesets();
                if (null != tilesets && tilesets.Any())
                {
                    foreach (var tileset in tilesets)
                    {
                        var vm = TilesetFactory.Get(tileset, _mapRenderer.GraphicsDevice);
                        this.lbTilesets.Items.Add(vm);
                    }
                }

                BindMapLayers();
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseMap();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewMap();
        }

        private void drawDebugLinesToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (null != _mapRenderer)
                _mapRenderer.CanDrawDebugLines = drawDebugLinesToolStripMenuItem.Checked;
        }

        private void drawHexagonsToolStripMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (null != _mapRenderer)
                _mapRenderer.CanDrawHexagons = this.drawHexagonsToolStripMenuItem.Checked;
        }

        private void SelectTileMenuItem_CheckStateChanged(object sender, EventArgs e)
        {
            if (this.selectTileMenuItem.Checked)
            {
                _frmSelTile.Show();
                _frmSelTile.BringToFront();
            }
            else
                _frmSelTile.Hide();
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.toolsToolStripMenuItem.Checked)
            {
                _frmTools.Show();
                _frmTools.BringToFront();
            }
            else
                _frmTools.Hide();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commands.CommandManager.UndoCommand();
            this.undoToolStripMenuItem.Enabled = (0 != Commands.CommandManager.UndoCount);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commands.CommandManager.ExecuteCommand();
            this.redoToolStripMenuItem.Enabled = (0 != Commands.CommandManager.Count);
        }

        #endregion Menu Events
    }
}
