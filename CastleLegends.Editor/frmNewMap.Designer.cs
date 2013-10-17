namespace CastleLegends.Editor
{
    partial class frmNewMap
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

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this._tileCountX = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._tileCountY = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this._tileRadius = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbHexType = new System.Windows.Forms.ComboBox();
            this.cmbMapCoordsType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._tileCountX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._tileCountY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._tileRadius)).BeginInit();
            this.SuspendLayout();
            // 
            // _tileCountX
            // 
            this._tileCountX.Location = new System.Drawing.Point(131, 12);
            this._tileCountX.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this._tileCountX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._tileCountX.Name = "_tileCountX";
            this._tileCountX.Size = new System.Drawing.Size(104, 20);
            this._tileCountX.TabIndex = 0;
            this._tileCountX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._tileCountX.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Horizontal Tiles Count";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Vertical Tiles Count";
            // 
            // _tileCountY
            // 
            this._tileCountY.Location = new System.Drawing.Point(131, 51);
            this._tileCountY.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this._tileCountY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._tileCountY.Name = "_tileCountY";
            this._tileCountY.Size = new System.Drawing.Size(104, 20);
            this._tileCountY.TabIndex = 2;
            this._tileCountY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._tileCountY.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tile Radius";
            // 
            // _tileRadius
            // 
            this._tileRadius.Location = new System.Drawing.Point(131, 90);
            this._tileRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this._tileRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._tileRadius.Name = "_tileRadius";
            this._tileRadius.Size = new System.Drawing.Size(104, 20);
            this._tileRadius.TabIndex = 4;
            this._tileRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._tileRadius.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(87, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 31);
            this.button1.TabIndex = 6;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(166, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 31);
            this.button2.TabIndex = 7;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Hex Type";
            // 
            // cmbHexType
            // 
            this.cmbHexType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHexType.FormattingEnabled = true;
            this.cmbHexType.Location = new System.Drawing.Point(131, 126);
            this.cmbHexType.Name = "cmbHexType";
            this.cmbHexType.Size = new System.Drawing.Size(104, 21);
            this.cmbHexType.TabIndex = 10;
            // 
            // cmbMapCoordsType
            // 
            this.cmbMapCoordsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMapCoordsType.FormattingEnabled = true;
            this.cmbMapCoordsType.Location = new System.Drawing.Point(131, 159);
            this.cmbMapCoordsType.Name = "cmbMapCoordsType";
            this.cmbMapCoordsType.Size = new System.Drawing.Size(104, 21);
            this.cmbMapCoordsType.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 162);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Map Coords Type";
            // 
            // frmNewMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 265);
            this.Controls.Add(this.cmbMapCoordsType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbHexType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tileRadius);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._tileCountY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tileCountX);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNewMap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Map";
            ((System.ComponentModel.ISupportInitialize)(this._tileCountX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._tileCountY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._tileRadius)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown _tileCountX;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _tileCountY;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown _tileRadius;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbHexType;
        private System.Windows.Forms.ComboBox cmbMapCoordsType;
        private System.Windows.Forms.Label label5;
    }
}