﻿using System;
using System.Windows.Forms;
using CastleLegends.Editor.UserControls;
using Microsoft.Xna.Framework;
using CastleLegends.Common;
using CastleLegends.Editor.RenderModels;

namespace CastleLegends.Editor
{
    public partial class frmSelectTile : Form
    {
        #region Members

        private ucTilesetRenderer _renderer;        

        #endregion Members

        public frmSelectTile()
        {
            InitializeComponent();

            this.Load += new EventHandler(frmSelectTile_Load);
            this.ResizeEnd += new EventHandler(frmSelectTile_ResizeEnd);
        }

        #region Form Events

        private void frmSelectTile_Load(object sender, EventArgs e)
        {            
            InitRenderer();
        }
        
        private void frmSelectTile_ResizeEnd(object sender, EventArgs e)
        {
            SetScrollbars();
        }
        
        private void frmSelectTile_MouseClick(object sender, MouseEventArgs e)
        {
            this.SelectedTileIndex = null;

            if (!_renderer.EnableSelection ||  null == TileSelectionChange) 
                return;

            Point selectedTileIndex = Point.Zero;
            if (_renderer.SelectTile(out selectedTileIndex))
            {         
                this.SelectedTileIndex = selectedTileIndex;

                TileSelectionChange(this, new TileSelectionEventArgs(this.TileSet, selectedTileIndex));
            }
        }

        #endregion Form Events

        #region Methods

        public void SetTileset(TilesetViewModel data) {
            InitRenderer();

            this.TileSet = data;

            _renderer.SetTileset(this.TileSet);

            SetScrollbars();
        }

        #endregion Methods

        #region Private Methods

        private void InitRenderer()
        {
            if (null != _renderer) return;
            _renderer = new ucTilesetRenderer();
            _renderer.EnableSelection = true;
            _renderer.MouseClick += new MouseEventHandler(frmSelectTile_MouseClick);

            this.ucRendererContainer.SetRenderer(_renderer);
        }

        private void SetScrollbars()
        {
            if (null == TileSet) return;

            var vMax = TileSet.Height - ucRendererContainer.Height;
            var hMax = TileSet.Width - ucRendererContainer.Width;

            this.ucRendererContainer.SetScrollbars(vMax, hMax);
        }

        #endregion Private Methods

        #region Properties

        public TilesetViewModel TileSet { get; private set; }

        public Point? SelectedTileIndex { get; private set; }

        #endregion Properties

        #region Custom Events

        public delegate void TileSelectionChangeHandler(object sender, TileSelectionEventArgs data);
        public event TileSelectionChangeHandler TileSelectionChange;

        #endregion Custom Events
    }

    public class TileSelectionEventArgs : EventArgs
    {
        public TileSelectionEventArgs(TilesetViewModel tileSet, Point coords)
        {
            this.TileSet = tileSet;
            this.TileIndices = coords;
        }

        public TilesetViewModel TileSet { get; private set; }
        public Point TileIndices { get; private set; }
    }
}
