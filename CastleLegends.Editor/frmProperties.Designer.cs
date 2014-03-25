namespace CastleLegends.Editor
{
    partial class frmProperties
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
            this.tabInfoPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.SuspendLayout();
            // 
            // tabInfoPropertyGrid
            // 
            this.tabInfoPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabInfoPropertyGrid.Enabled = false;
            this.tabInfoPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.tabInfoPropertyGrid.Name = "tabInfoPropertyGrid";
            this.tabInfoPropertyGrid.Size = new System.Drawing.Size(284, 463);
            this.tabInfoPropertyGrid.TabIndex = 1;
            // 
            // frmProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 463);
            this.ControlBox = false;
            this.Controls.Add(this.tabInfoPropertyGrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid tabInfoPropertyGrid;
    }
}