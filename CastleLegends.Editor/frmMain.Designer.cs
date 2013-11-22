namespace CastleLegends.Editor
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.rendererContainer = new CastleLegends.Editor.UserControls.ucRendererContainer();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectTileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawDebugLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabTools = new System.Windows.Forms.TabControl();
            this.tabTilesets = new System.Windows.Forms.TabPage();
            this.TilesetsList = new System.Windows.Forms.ListBox();
            this.btnAddTileset = new System.Windows.Forms.Button();
            this.tabInfo = new System.Windows.Forms.TabPage();
            this.tabInfoPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabTools.SuspendLayout();
            this.tabTilesets.SuspendLayout();
            this.tabInfo.SuspendLayout();
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
            this.optionsToolStripMenuItem});
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "Save...";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
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
            this.toolsToolStripMenuItem});
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
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drawDebugLinesToolStripMenuItem});
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
            // tabTools
            // 
            this.tabTools.Controls.Add(this.tabTilesets);
            this.tabTools.Controls.Add(this.tabInfo);
            this.tabTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabTools.Enabled = false;
            this.tabTools.Location = new System.Drawing.Point(0, 0);
            this.tabTools.Name = "tabTools";
            this.tabTools.SelectedIndex = 0;
            this.tabTools.Size = new System.Drawing.Size(235, 538);
            this.tabTools.TabIndex = 0;
            // 
            // tabTilesets
            // 
            this.tabTilesets.Controls.Add(this.TilesetsList);
            this.tabTilesets.Controls.Add(this.btnAddTileset);
            this.tabTilesets.Location = new System.Drawing.Point(4, 22);
            this.tabTilesets.Name = "tabTilesets";
            this.tabTilesets.Padding = new System.Windows.Forms.Padding(3);
            this.tabTilesets.Size = new System.Drawing.Size(227, 512);
            this.tabTilesets.TabIndex = 0;
            this.tabTilesets.Text = "Tilesets";
            this.tabTilesets.UseVisualStyleBackColor = true;
            // 
            // TilesetsList
            // 
            this.TilesetsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TilesetsList.FormattingEnabled = true;
            this.TilesetsList.Location = new System.Drawing.Point(6, 6);
            this.TilesetsList.Name = "TilesetsList";
            this.TilesetsList.Size = new System.Drawing.Size(213, 472);
            this.TilesetsList.TabIndex = 6;
            this.TilesetsList.SelectedIndexChanged += new System.EventHandler(this.TilesetsList_SelectedIndexChanged);
            this.TilesetsList.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TilesetsList_MouseDoubleClick);
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
            // tabInfo
            // 
            this.tabInfo.Controls.Add(this.tabInfoPropertyGrid);
            this.tabInfo.Location = new System.Drawing.Point(4, 22);
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabInfo.Size = new System.Drawing.Size(227, 512);
            this.tabInfo.TabIndex = 1;
            this.tabInfo.Text = "Info";
            this.tabInfo.UseVisualStyleBackColor = true;
            // 
            // tabInfoPropertyGrid
            // 
            this.tabInfoPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfoPropertyGrid.Enabled = false;
            this.tabInfoPropertyGrid.Location = new System.Drawing.Point(3, 3);
            this.tabInfoPropertyGrid.Name = "tabInfoPropertyGrid";
            this.tabInfoPropertyGrid.Size = new System.Drawing.Size(221, 506);
            this.tabInfoPropertyGrid.TabIndex = 0;
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
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
            this.tabTools.ResumeLayout(false);
            this.tabTilesets.ResumeLayout(false);
            this.tabInfo.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabTools;
        private System.Windows.Forms.TabPage tabTilesets;
        private UserControls.ucRendererContainer rendererContainer;
        private System.Windows.Forms.Button btnAddTileset;
        private System.Windows.Forms.ListBox TilesetsList;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectTileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.TabPage tabInfo;
        private System.Windows.Forms.PropertyGrid tabInfoPropertyGrid;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
    }
}

