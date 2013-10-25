namespace CastleLegends.Editor
{
    partial class frmImportTileset
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this._btnOK = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            this.ucRendererContainer = new CastleLegends.Editor.UserControls.ucRendererContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.numTileWidth = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numTileHeight = new System.Windows.Forms.NumericUpDown();
            this.chkShowGrid = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTileWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkShowGrid);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numTileHeight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.numTileWidth);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this._btnOK);
            this.groupBox1.Controls.Add(this._btnCancel);
            this.groupBox1.Location = new System.Drawing.Point(579, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 510);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(6, 471);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(49, 33);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // _btnOK
            // 
            this._btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOK.Location = new System.Drawing.Point(175, 471);
            this._btnOK.Name = "_btnOK";
            this._btnOK.Size = new System.Drawing.Size(49, 33);
            this._btnOK.TabIndex = 5;
            this._btnOK.Text = "OK";
            this._btnOK.UseVisualStyleBackColor = true;
            // 
            // _btnCancel
            // 
            this._btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.Location = new System.Drawing.Point(120, 471);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(49, 33);
            this._btnCancel.TabIndex = 6;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // ucRendererContainer
            // 
            this.ucRendererContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRendererContainer.Location = new System.Drawing.Point(12, 12);
            this.ucRendererContainer.Name = "ucRendererContainer";
            this.ucRendererContainer.Size = new System.Drawing.Size(561, 510);
            this.ucRendererContainer.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Tile Width";
            // 
            // numTileWidth
            // 
            this.numTileWidth.Location = new System.Drawing.Point(122, 14);
            this.numTileWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTileWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTileWidth.Name = "numTileWidth";
            this.numTileWidth.Size = new System.Drawing.Size(104, 20);
            this.numTileWidth.TabIndex = 7;
            this.numTileWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTileWidth.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numTileWidth.ValueChanged += new System.EventHandler(this.numTileWidth_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tile Height";
            // 
            // numTileHeight
            // 
            this.numTileHeight.Location = new System.Drawing.Point(122, 42);
            this.numTileHeight.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numTileHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTileHeight.Name = "numTileHeight";
            this.numTileHeight.Size = new System.Drawing.Size(104, 20);
            this.numTileHeight.TabIndex = 9;
            this.numTileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numTileHeight.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.numTileHeight.ValueChanged += new System.EventHandler(this.numTileHeight_ValueChanged);
            // 
            // chkShowGrid
            // 
            this.chkShowGrid.AutoSize = true;
            this.chkShowGrid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowGrid.Checked = true;
            this.chkShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowGrid.Location = new System.Drawing.Point(9, 83);
            this.chkShowGrid.Name = "chkShowGrid";
            this.chkShowGrid.Size = new System.Drawing.Size(75, 17);
            this.chkShowGrid.TabIndex = 11;
            this.chkShowGrid.Text = "Show Grid";
            this.chkShowGrid.UseVisualStyleBackColor = true;
            this.chkShowGrid.CheckedChanged += new System.EventHandler(this.chkShowGrid_CheckedChanged);
            // 
            // frmImportTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 534);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ucRendererContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmImportTileset";
            this.Text = "Import Tileset";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTileWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTileHeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucRendererContainer ucRendererContainer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numTileHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numTileWidth;
        private System.Windows.Forms.CheckBox chkShowGrid;
    }
}