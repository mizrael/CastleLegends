namespace CastleLegends.Editor
{
    partial class frmSpriteTool
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
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
            this.numUpDownNumCols = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.listBoxSprites = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblImgHeight = new System.Windows.Forms.Label();
            this.lblImgWidth = new System.Windows.Forms.Label();
            this.lblNumRows = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._btnPickAlpha = new System.Windows.Forms.CheckBox();
            this._pnlAlpha = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this._ucTileSetRenderer = new CastleLegends.Editor.UserControls.ucTilesetRenderer();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumCols)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numUpDownNumCols
            // 
            this.numUpDownNumCols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numUpDownNumCols.Location = new System.Drawing.Point(95, 19);
            this.numUpDownNumCols.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numUpDownNumCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownNumCols.Name = "numUpDownNumCols";
            this.numUpDownNumCols.Size = new System.Drawing.Size(57, 20);
            this.numUpDownNumCols.TabIndex = 7;
            this.numUpDownNumCols.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numUpDownNumCols.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownNumCols.ValueChanged += new System.EventHandler(this.numUpDownNumCols_ValueChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "# Columns:";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Location = new System.Drawing.Point(9, 250);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(62, 26);
            this.btnImport.TabIndex = 9;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(636, 493);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 26);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listBoxSprites
            // 
            this.listBoxSprites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxSprites.FormattingEnabled = true;
            this.listBoxSprites.Location = new System.Drawing.Point(9, 16);
            this.listBoxSprites.Name = "listBoxSprites";
            this.listBoxSprites.Size = new System.Drawing.Size(139, 212);
            this.listBoxSprites.Sorted = true;
            this.listBoxSprites.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "# Rows:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Image Width:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Image Height:";
            // 
            // lblImgHeight
            // 
            this.lblImgHeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImgHeight.AutoSize = true;
            this.lblImgHeight.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblImgHeight.Location = new System.Drawing.Point(92, 86);
            this.lblImgHeight.Name = "lblImgHeight";
            this.lblImgHeight.Size = new System.Drawing.Size(13, 13);
            this.lblImgHeight.TabIndex = 17;
            this.lblImgHeight.Text = "0";
            // 
            // lblImgWidth
            // 
            this.lblImgWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImgWidth.AutoSize = true;
            this.lblImgWidth.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblImgWidth.Location = new System.Drawing.Point(92, 73);
            this.lblImgWidth.Name = "lblImgWidth";
            this.lblImgWidth.Size = new System.Drawing.Size(13, 13);
            this.lblImgWidth.TabIndex = 16;
            this.lblImgWidth.Text = "0";
            // 
            // lblNumRows
            // 
            this.lblNumRows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNumRows.AutoSize = true;
            this.lblNumRows.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblNumRows.Location = new System.Drawing.Point(92, 60);
            this.lblNumRows.Name = "lblNumRows";
            this.lblNumRows.Size = new System.Drawing.Size(13, 13);
            this.lblNumRows.TabIndex = 15;
            this.lblNumRows.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this._btnPickAlpha);
            this.groupBox3.Controls.Add(this._pnlAlpha);
            this.groupBox3.Location = new System.Drawing.Point(540, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 58);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Alpha";
            // 
            // _btnPickAlpha
            // 
            this._btnPickAlpha.Appearance = System.Windows.Forms.Appearance.Button;
            this._btnPickAlpha.Enabled = false;
            this._btnPickAlpha.Location = new System.Drawing.Point(6, 19);
            this._btnPickAlpha.Name = "_btnPickAlpha";
            this._btnPickAlpha.Size = new System.Drawing.Size(52, 24);
            this._btnPickAlpha.TabIndex = 12;
            this._btnPickAlpha.Text = "Pick";
            this._btnPickAlpha.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._btnPickAlpha.UseVisualStyleBackColor = true;
            this._btnPickAlpha.CheckedChanged += new System.EventHandler(this._btnPickAlpha_CheckedChanged);
            // 
            // _pnlAlpha
            // 
            this._pnlAlpha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlAlpha.Location = new System.Drawing.Point(95, 19);
            this._pnlAlpha.Name = "_pnlAlpha";
            this._pnlAlpha.Size = new System.Drawing.Size(24, 24);
            this._pnlAlpha.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.listBoxSprites);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Location = new System.Drawing.Point(540, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 282);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sprites";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.numUpDownNumCols);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblImgHeight);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblImgWidth);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblNumRows);
            this.groupBox2.Location = new System.Drawing.Point(540, 364);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 112);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Properties";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(540, 493);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(62, 26);
            this.btnClear.TabIndex = 20;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // _ucTileSetRenderer
            // 
            this._ucTileSetRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._ucTileSetRenderer.EnableSelection = false;
            this._ucTileSetRenderer.GridColor = new Microsoft.Xna.Framework.Color(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._ucTileSetRenderer.Location = new System.Drawing.Point(12, 12);
            this._ucTileSetRenderer.Name = "_ucTileSetRenderer";
            this._ucTileSetRenderer.ShowGrid = false;
            this._ucTileSetRenderer.Size = new System.Drawing.Size(522, 507);
            this._ucTileSetRenderer.TabIndex = 21;
            this._ucTileSetRenderer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.renderControl_MouseClick);
            this._ucTileSetRenderer.MouseEnter += new System.EventHandler(this.renderControl_MouseEnter);
            this._ucTileSetRenderer.MouseLeave += new System.EventHandler(this.renderControl_MouseLeave);
            this._ucTileSetRenderer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.renderControl_MouseMove);
            // 
            // frmSpriteTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 531);
            this.Controls.Add(this._ucTileSetRenderer);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmSpriteTool";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SpriteViewModel Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownNumCols)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUpDownNumCols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox listBoxSprites;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblImgHeight;
        private System.Windows.Forms.Label lblImgWidth;
        private System.Windows.Forms.Label lblNumRows;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox _btnPickAlpha;
        private System.Windows.Forms.Panel _pnlAlpha;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClear;
        private UserControls.ucTilesetRenderer _ucTileSetRenderer;
    }
}