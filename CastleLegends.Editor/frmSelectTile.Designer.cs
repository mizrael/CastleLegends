namespace CastleLegends.Editor
{
    partial class frmSelectTile
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
            this.ucRendererContainer = new CastleLegends.Editor.UserControls.ucRendererContainer();
            this.SuspendLayout();
            // 
            // ucRendererContainer
            // 
            this.ucRendererContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucRendererContainer.Location = new System.Drawing.Point(0, 0);
            this.ucRendererContainer.Name = "ucRendererContainer";
            this.ucRendererContainer.Size = new System.Drawing.Size(572, 431);
            this.ucRendererContainer.TabIndex = 0;
            // 
            // frmSelectTile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 431);
            this.ControlBox = false;
            this.Controls.Add(this.ucRendererContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmSelectTile";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Tile";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ucRendererContainer ucRendererContainer;
    }
}