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
            this.chkShowGrid = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tilesetProperties = new System.Windows.Forms.PropertyGrid();
            this.btnSetGridColor = new System.Windows.Forms.Button();
            this.ucRendererContainer = new CastleLegends.Editor.UserControls.ucRendererContainer();
            this.SuspendLayout();
            // 
            // chkShowGrid
            // 
            this.chkShowGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowGrid.AutoSize = true;
            this.chkShowGrid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShowGrid.Checked = true;
            this.chkShowGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowGrid.Enabled = false;
            this.chkShowGrid.Location = new System.Drawing.Point(583, 395);
            this.chkShowGrid.Name = "chkShowGrid";
            this.chkShowGrid.Size = new System.Drawing.Size(75, 17);
            this.chkShowGrid.TabIndex = 11;
            this.chkShowGrid.Text = "Show Grid";
            this.chkShowGrid.UseVisualStyleBackColor = true;
            this.chkShowGrid.CheckedChanged += new System.EventHandler(this.chkShowGrid_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(583, 462);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(49, 33);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(764, 462);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(49, 33);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // tilesetProperties
            // 
            this.tilesetProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tilesetProperties.Enabled = false;
            this.tilesetProperties.Location = new System.Drawing.Point(583, 10);
            this.tilesetProperties.Name = "tilesetProperties";
            this.tilesetProperties.Size = new System.Drawing.Size(230, 374);
            this.tilesetProperties.TabIndex = 12;
            this.tilesetProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.tilesetProperties_PropertyValueChanged);
            // 
            // btnSetGridColor
            // 
            this.btnSetGridColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetGridColor.Enabled = false;
            this.btnSetGridColor.Location = new System.Drawing.Point(739, 390);
            this.btnSetGridColor.Name = "btnSetGridColor";
            this.btnSetGridColor.Size = new System.Drawing.Size(74, 24);
            this.btnSetGridColor.TabIndex = 14;
            this.btnSetGridColor.Text = "Grid Color";
            this.btnSetGridColor.UseVisualStyleBackColor = true;
            this.btnSetGridColor.Click += new System.EventHandler(this.btnSetGridColor_Click);
            // 
            // ucRendererContainer
            // 
            this.ucRendererContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucRendererContainer.Location = new System.Drawing.Point(12, 12);
            this.ucRendererContainer.Name = "ucRendererContainer";
            this.ucRendererContainer.Size = new System.Drawing.Size(565, 483);
            this.ucRendererContainer.TabIndex = 0;
            // 
            // frmImportTileset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 507);
            this.Controls.Add(this.btnSetGridColor);
            this.Controls.Add(this.chkShowGrid);
            this.Controls.Add(this.tilesetProperties);
            this.Controls.Add(this.ucRendererContainer);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmImportTileset";
            this.ShowInTaskbar = false;
            this.Text = "Import Tile Set";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.ucRendererContainer ucRendererContainer;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkShowGrid;
        private System.Windows.Forms.PropertyGrid tilesetProperties;
        private System.Windows.Forms.Button btnSetGridColor;
    }
}