﻿namespace CastleLegends.Editor
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.rendererContainer = new CastleLegends.Editor.UserControls.ucRendererContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectTileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawDebugLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawHexagonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tilesetsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tilesetsContextMenu_View = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetsContextMenu_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.tabMapLayers = new System.Windows.Forms.TabPage();
            this.btnRemoveMapLayer = new System.Windows.Forms.Button();
            this.btnAddMapLayer = new System.Windows.Forms.Button();
            this.btnMapLayerUp = new System.Windows.Forms.Button();
            this.btnMapLayerDown = new System.Windows.Forms.Button();
            this.chklMapLayers = new System.Windows.Forms.CheckedListBox();
            this.tabTilesets = new System.Windows.Forms.TabPage();
            this.btnAddTileset = new System.Windows.Forms.Button();
            this.lbTilesets = new System.Windows.Forms.ListBox();
            this.tabTools = new System.Windows.Forms.TabControl();
            this.pnlMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tilesetsContextMenu.SuspendLayout();
            this.tabMapLayers.SuspendLayout();
            this.tabTilesets.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.rendererContainer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(800, 538);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.SizeChanged += new System.EventHandler(this.pnlMain_SizeChanged);
            // 
            // rendererContainer
            // 
            this.rendererContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rendererContainer.Location = new System.Drawing.Point(0, 0);
            this.rendererContainer.Name = "rendererContainer";
            this.rendererContainer.Size = new System.Drawing.Size(800, 538);
            this.rendererContainer.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1039, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(106, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Enabled = false;
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Enabled = false;
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectTileMenuItem,
            this.toolsToolStripMenuItem,
            this.propertiesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // selectTileMenuItem
            // 
            this.selectTileMenuItem.CheckOnClick = true;
            this.selectTileMenuItem.Enabled = false;
            this.selectTileMenuItem.Name = "selectTileMenuItem";
            this.selectTileMenuItem.Size = new System.Drawing.Size(138, 22);
            this.selectTileMenuItem.Text = "Tile Selector";
            this.selectTileMenuItem.CheckStateChanged += new System.EventHandler(this.SelectTileMenuItem_CheckStateChanged);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.CheckOnClick = true;
            this.toolsToolStripMenuItem.Enabled = false;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.Click += new System.EventHandler(this.toolsToolStripMenuItem_Click);
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.CheckOnClick = true;
            this.propertiesToolStripMenuItem.Enabled = false;
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            this.propertiesToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.propertiesToolStripMenuItem_CheckStateChanged);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawDebugLinesToolStripMenuItem,
            this.drawHexagonsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // drawDebugLinesToolStripMenuItem
            // 
            this.drawDebugLinesToolStripMenuItem.CheckOnClick = true;
            this.drawDebugLinesToolStripMenuItem.Enabled = false;
            this.drawDebugLinesToolStripMenuItem.Name = "drawDebugLinesToolStripMenuItem";
            this.drawDebugLinesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.drawDebugLinesToolStripMenuItem.Text = "Draw Debug Lines";
            this.drawDebugLinesToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.drawDebugLinesToolStripMenuItem_CheckStateChanged);
            // 
            // drawHexagonsToolStripMenuItem
            // 
            this.drawHexagonsToolStripMenuItem.Checked = true;
            this.drawHexagonsToolStripMenuItem.CheckOnClick = true;
            this.drawHexagonsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.drawHexagonsToolStripMenuItem.Enabled = false;
            this.drawHexagonsToolStripMenuItem.Name = "drawHexagonsToolStripMenuItem";
            this.drawHexagonsToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.drawHexagonsToolStripMenuItem.Text = "Draw Hexagons";
            this.drawHexagonsToolStripMenuItem.CheckStateChanged += new System.EventHandler(this.drawHexagonsToolStripMenuItem_CheckStateChanged);
            // 
            // toolsToolStripMenuItem1
            // 
            this.toolsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetCreatorToolStripMenuItem});
            this.toolsToolStripMenuItem1.Name = "toolsToolStripMenuItem1";
            this.toolsToolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem1.Text = "Tools";
            // 
            // tilesetCreatorToolStripMenuItem
            // 
            this.tilesetCreatorToolStripMenuItem.Name = "tilesetCreatorToolStripMenuItem";
            this.tilesetCreatorToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tilesetCreatorToolStripMenuItem.Text = "Tileset Creator ";
            this.tilesetCreatorToolStripMenuItem.Click += new System.EventHandler(this.tilesetCreatorToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlMain);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabTools);
            this.splitContainer1.Size = new System.Drawing.Size(1039, 538);
            this.splitContainer1.SplitterDistance = 800;
            this.splitContainer1.TabIndex = 4;
            // 
            // tilesetsContextMenu
            // 
            this.tilesetsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetsContextMenu_View,
            this.tilesetsContextMenu_Edit});
            this.tilesetsContextMenu.Name = "tilesetsContextMenu";
            this.tilesetsContextMenu.Size = new System.Drawing.Size(100, 48);
            this.tilesetsContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.tilesetsContextMenu_Opening);
            // 
            // tilesetsContextMenu_View
            // 
            this.tilesetsContextMenu_View.Name = "tilesetsContextMenu_View";
            this.tilesetsContextMenu_View.Size = new System.Drawing.Size(99, 22);
            this.tilesetsContextMenu_View.Text = "View";
            this.tilesetsContextMenu_View.Click += new System.EventHandler(this.tilesetsContextMenu_View_Click);
            // 
            // tilesetsContextMenu_Edit
            // 
            this.tilesetsContextMenu_Edit.Name = "tilesetsContextMenu_Edit";
            this.tilesetsContextMenu_Edit.Size = new System.Drawing.Size(99, 22);
            this.tilesetsContextMenu_Edit.Text = "Edit";
            this.tilesetsContextMenu_Edit.Click += new System.EventHandler(this.tilesetsContextMenu_Edit_Click);
            // 
            // tabMapLayers
            // 
            this.tabMapLayers.Controls.Add(this.chklMapLayers);
            this.tabMapLayers.Controls.Add(this.btnMapLayerDown);
            this.tabMapLayers.Controls.Add(this.btnMapLayerUp);
            this.tabMapLayers.Controls.Add(this.btnAddMapLayer);
            this.tabMapLayers.Controls.Add(this.btnRemoveMapLayer);
            this.tabMapLayers.Location = new System.Drawing.Point(4, 22);
            this.tabMapLayers.Name = "tabMapLayers";
            this.tabMapLayers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMapLayers.Size = new System.Drawing.Size(227, 512);
            this.tabMapLayers.TabIndex = 2;
            this.tabMapLayers.Text = "Layers";
            this.tabMapLayers.UseVisualStyleBackColor = true;
            // 
            // btnRemoveMapLayer
            // 
            this.btnRemoveMapLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveMapLayer.Enabled = false;
            this.btnRemoveMapLayer.Location = new System.Drawing.Point(192, 484);
            this.btnRemoveMapLayer.Name = "btnRemoveMapLayer";
            this.btnRemoveMapLayer.Size = new System.Drawing.Size(28, 21);
            this.btnRemoveMapLayer.TabIndex = 7;
            this.btnRemoveMapLayer.Text = "-";
            this.btnRemoveMapLayer.UseVisualStyleBackColor = true;
            this.btnRemoveMapLayer.Click += new System.EventHandler(this.btnRemoveMapLayer_Click);
            // 
            // btnAddMapLayer
            // 
            this.btnAddMapLayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddMapLayer.Location = new System.Drawing.Point(143, 484);
            this.btnAddMapLayer.Name = "btnAddMapLayer";
            this.btnAddMapLayer.Size = new System.Drawing.Size(28, 21);
            this.btnAddMapLayer.TabIndex = 9;
            this.btnAddMapLayer.Text = "+";
            this.btnAddMapLayer.UseVisualStyleBackColor = true;
            this.btnAddMapLayer.Click += new System.EventHandler(this.btnAddMapLayer_Click);
            // 
            // btnMapLayerUp
            // 
            this.btnMapLayerUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapLayerUp.Enabled = false;
            this.btnMapLayerUp.Location = new System.Drawing.Point(7, 484);
            this.btnMapLayerUp.Name = "btnMapLayerUp";
            this.btnMapLayerUp.Size = new System.Drawing.Size(28, 21);
            this.btnMapLayerUp.TabIndex = 10;
            this.btnMapLayerUp.Text = "Up";
            this.btnMapLayerUp.UseVisualStyleBackColor = true;
            this.btnMapLayerUp.Click += new System.EventHandler(this.btnMapLayerUp_Click);
            // 
            // btnMapLayerDown
            // 
            this.btnMapLayerDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapLayerDown.Enabled = false;
            this.btnMapLayerDown.Location = new System.Drawing.Point(41, 484);
            this.btnMapLayerDown.Name = "btnMapLayerDown";
            this.btnMapLayerDown.Size = new System.Drawing.Size(28, 21);
            this.btnMapLayerDown.TabIndex = 11;
            this.btnMapLayerDown.Text = "Down";
            this.btnMapLayerDown.UseVisualStyleBackColor = true;
            this.btnMapLayerDown.Click += new System.EventHandler(this.btnMapLayerDown_Click);
            // 
            // chklMapLayers
            // 
            this.chklMapLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chklMapLayers.FormattingEnabled = true;
            this.chklMapLayers.Location = new System.Drawing.Point(6, 6);
            this.chklMapLayers.Name = "chklMapLayers";
            this.chklMapLayers.Size = new System.Drawing.Size(213, 469);
            this.chklMapLayers.TabIndex = 12;
            this.chklMapLayers.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklMapLayers_ItemCheck);
            // 
            // tabTilesets
            // 
            this.tabTilesets.Controls.Add(this.lbTilesets);
            this.tabTilesets.Controls.Add(this.btnAddTileset);
            this.tabTilesets.Location = new System.Drawing.Point(4, 22);
            this.tabTilesets.Name = "tabTilesets";
            this.tabTilesets.Padding = new System.Windows.Forms.Padding(3);
            this.tabTilesets.Size = new System.Drawing.Size(227, 512);
            this.tabTilesets.TabIndex = 0;
            this.tabTilesets.Text = "Tilesets";
            this.tabTilesets.UseVisualStyleBackColor = true;
            // 
            // btnAddTileset
            // 
            this.btnAddTileset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTileset.Location = new System.Drawing.Point(191, 483);
            this.btnAddTileset.Name = "btnAddTileset";
            this.btnAddTileset.Size = new System.Drawing.Size(28, 21);
            this.btnAddTileset.TabIndex = 5;
            this.btnAddTileset.Text = "+";
            this.btnAddTileset.UseVisualStyleBackColor = true;
            this.btnAddTileset.Click += new System.EventHandler(this.btnAddTileset_Click);
            // 
            // lbTilesets
            // 
            this.lbTilesets.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTilesets.ContextMenuStrip = this.tilesetsContextMenu;
            this.lbTilesets.FormattingEnabled = true;
            this.lbTilesets.Location = new System.Drawing.Point(6, 6);
            this.lbTilesets.Name = "lbTilesets";
            this.lbTilesets.Size = new System.Drawing.Size(213, 472);
            this.lbTilesets.TabIndex = 6;
            this.lbTilesets.SelectedIndexChanged += new System.EventHandler(this.TilesetsList_SelectedIndexChanged);
            this.lbTilesets.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TilesetsList_MouseDoubleClick);
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.tabTilesets);
            this.tabTools.Controls.Add(this.tabMapLayers);
            this.tabTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTools.Enabled = false;
            this.tabTools.Location = new System.Drawing.Point(0, 0);
            this.tabTools.Name = "tabTools";
            this.tabTools.SelectedIndex = 0;
            this.tabTools.Size = new System.Drawing.Size(235, 538);
            this.tabTools.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 562);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmMain";
            this.Text = "Castle Legends Editor";
            this.pnlMain.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tilesetsContextMenu.ResumeLayout(false);
            this.tabMapLayers.ResumeLayout(false);
            this.tabTilesets.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawDebugLinesToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private UserControls.ucRendererContainer rendererContainer;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectTileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawHexagonsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip tilesetsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tilesetsContextMenu_View;
        private System.Windows.Forms.ToolStripMenuItem tilesetsContextMenu_Edit;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tilesetCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.TabControl tabTools;
        private System.Windows.Forms.TabPage tabTilesets;
        private System.Windows.Forms.ListBox lbTilesets;
        private System.Windows.Forms.Button btnAddTileset;
        private System.Windows.Forms.TabPage tabMapLayers;
        private System.Windows.Forms.CheckedListBox chklMapLayers;
        private System.Windows.Forms.Button btnMapLayerDown;
        private System.Windows.Forms.Button btnMapLayerUp;
        private System.Windows.Forms.Button btnAddMapLayer;
        private System.Windows.Forms.Button btnRemoveMapLayer;
    }
}

