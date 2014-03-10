namespace CastleLegends.Editor
{
    partial class frmTools
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
            this.chkSetTileTexture = new System.Windows.Forms.CheckBox();
            this.chkRemoveTileTexture = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkSetTileTexture
            // 
            this.chkSetTileTexture.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSetTileTexture.AutoSize = true;
            this.chkSetTileTexture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSetTileTexture.Location = new System.Drawing.Point(7, 12);
            this.chkSetTileTexture.Name = "chkSetTileTexture";
            this.chkSetTileTexture.Size = new System.Drawing.Size(72, 23);
            this.chkSetTileTexture.TabIndex = 1;
            this.chkSetTileTexture.Text = "Set Texture";
            this.chkSetTileTexture.UseVisualStyleBackColor = true;
            this.chkSetTileTexture.CheckedChanged += new System.EventHandler(this.chkSetTileTexture_CheckedChanged);
            // 
            // chkRemoveTileTexture
            // 
            this.chkRemoveTileTexture.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkRemoveTileTexture.AutoSize = true;
            this.chkRemoveTileTexture.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkRemoveTileTexture.Location = new System.Drawing.Point(7, 41);
            this.chkRemoveTileTexture.Name = "chkRemoveTileTexture";
            this.chkRemoveTileTexture.Size = new System.Drawing.Size(96, 23);
            this.chkRemoveTileTexture.TabIndex = 2;
            this.chkRemoveTileTexture.Text = "Remove Texture";
            this.chkRemoveTileTexture.UseVisualStyleBackColor = true;
            this.chkRemoveTileTexture.CheckedChanged += new System.EventHandler(this.chkRemoveTileTexture_CheckedChanged);
            // 
            // frmTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(106, 122);
            this.ControlBox = false;
            this.Controls.Add(this.chkRemoveTileTexture);
            this.Controls.Add(this.chkSetTileTexture);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTools";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Tools";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkSetTileTexture;
        private System.Windows.Forms.CheckBox chkRemoveTileTexture;

    }
}