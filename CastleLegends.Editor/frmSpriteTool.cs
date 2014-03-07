using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;

using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CastleLegends.Editor.RenderModels;
using CastleLegends.Editor.UserControls;

namespace CastleLegends.Editor
{
    public partial class frmSpriteTool : Form
    {
        private ucTilesetRenderer _ucTileSetRenderer = null;
        private RenderTarget2D _renderTarget = null;
        private int _numRows = 0;
        private int _imgWidth = 0;
        private int _imgHeight = 0;

        private System.Drawing.Color _oldAlpha;
        private Color _alpha = Color.Black;

        public frmSpriteTool()
        {
            InitializeComponent();

            InitRenderControl();
        }

        private void InitRenderControl()
        {
            try
            {
                _ucTileSetRenderer = new ucTilesetRenderer();
                _ucTileSetRenderer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                _ucTileSetRenderer.Location = new System.Drawing.Point(12, 12);               
                _ucTileSetRenderer.Size = new System.Drawing.Size(500, 500);
                _ucTileSetRenderer.TabIndex = 12;

                _ucTileSetRenderer.MouseLeave += new System.EventHandler(renderControl_MouseLeave);
                _ucTileSetRenderer.MouseMove += new System.Windows.Forms.MouseEventHandler(renderControl_MouseMove);
                _ucTileSetRenderer.MouseClick += new System.Windows.Forms.MouseEventHandler(renderControl_MouseClick);
                _ucTileSetRenderer.MouseEnter += new System.EventHandler(renderControl_MouseEnter);

                this.Controls.Add(_ucTileSetRenderer);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            _ucTileSetRenderer.ShowGrid = true;
            _ucTileSetRenderer.EnableSelection = false;
            numUpDownNumCols.Value = 1;           
        }

        private void LoadSprites()
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Images|*.bmp;*.jpg;*.png;*.tga";
                ofd.Multiselect = true;
                ofd.RestoreDirectory = true;

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                string[] filenames = new string[ofd.FileNames.Length];
                Array.Copy(ofd.FileNames, filenames, ofd.FileNames.Length);
                Array.Sort(filenames);

                foreach (string f in filenames)
                {
                    Sprite s = TilesetFactory.Load(f, _ucTileSetRenderer.GraphicsDevice);
                    listBoxSprites.Items.Add(s);
                }

                _btnPickAlpha.Enabled = true; 

                PaintSpriteSet();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PaintSpriteSet()
        {
            if (listBoxSprites.Items.Count == 0)
                return;

            int numCols = (int)numUpDownNumCols.Value;
            _numRows = (int)decimal.Ceiling(listBoxSprites.Items.Count / numUpDownNumCols.Value);
            _imgWidth = (listBoxSprites.Items[0] as Sprite).Texture.Width * numCols;
            _imgHeight = (listBoxSprites.Items[0] as Sprite).Texture.Height * _numRows;

            lblNumRows.Text  = _numRows.ToString();
            lblImgHeight.Text = _imgHeight.ToString();
            lblImgWidth.Text = _imgWidth.ToString();
            
            _renderTarget = new RenderTarget2D(_ucTileSetRenderer.GraphicsDevice, _imgWidth, _imgHeight);
            
            //_ucTileSetRenderer.GraphicsDevice.SetRenderTarget(_renderTarget);
          
            //_ucTileSetRenderer.GraphicsDevice.Clear(Color.Black);
            //_ucTileSetRenderer.SpriteBatch.Begin();

            //int spriteID = 0;
            //for (int r = 0; r != _numRows; ++r) 
            //{
            //    for (int c = 0; c != numCols; ++c)
            //    {
            //        if (spriteID >= listBoxSprites.Items.Count)
            //            break;
            //        var sprite = listBoxSprites.Items[spriteID++] as Sprite;
            //        var destRect = new Rectangle(c * sprite.Texture.Width, r * sprite.Texture.Height,
            //                                    sprite.Texture.Width, sprite.Texture.Height);
            //        _ucTileSetRenderer.SpriteBatch.Draw(sprite.Texture, destRect, Color.White);
            //    }
            //}
            //_ucTileSetRenderer.SpriteBatch.End();
            //_renderTarget.End();

            //_ucTileSetRenderer.Texture = _renderTarget.Texture;
            //_ucTileSetRenderer.SetAlpha(_alpha);
        }

        private void Save()
        {
            try
            {
                 SaveFileDialog sfd = new SaveFileDialog();
                sfd.AddExtension = true;
                sfd.Filter = "Bmp|*.bmp|Png|*.png|Jpg|*.jpg|Tga|*.tga";
                sfd.RestoreDirectory = true;

                //if (sfd.ShowDialog() != DialogResult.OK)
                //    return;

                //_ucTileSetRenderer.GraphicsDevice.Textures[0] = null;
                //var fileInfo = new FileInfo(sfd.FileName);
                //var format = ImageFileFormat.Bmp;
                
                //switch(fileInfo.Extension )
                //{
                //    case ".bmp":
                //        format = ImageFileFormat.Bmp;
                //        break;
                //    case ".jpg":
                //        format = ImageFileFormat.Jpg;
                //        break;
                //    case ".png":
                //        format = ImageFileFormat.Png;
                //        break;
                //    case ".tga":
                //        format = ImageFileFormat.Tga;
                //        break;
                //}

                //_ucTileSetRenderer.Texture.Save(sfd.FileName, format);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void PickAlpha()
        {
            try
            {
                if (!_btnPickAlpha.Checked)
                    return;

                var pickedPoint = _ucTileSetRenderer.PointToClient(Cursor.Position);

             //   _alpha = _ucTileSetRenderer.GetTextureData<Color>(pickedPoint.X, pickedPoint.Y);

                _pnlAlpha.BackColor = System.Drawing.Color.FromArgb(_alpha.R, _alpha.G, _alpha.B);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void numUpDownNumCols_ValueChanged(object sender, EventArgs e)
        {
            try
            {            
                PaintSpriteSet();
             //   _ucTileSetRenderer.TileSize = _renderTarget.Texture.Width / (int)numUpDownNumCols.Value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSprites();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void renderControl_MouseEnter(object sender, EventArgs e)
        {
            if (_btnPickAlpha.Checked)
                _oldAlpha = _pnlAlpha.BackColor;
        }

        private void renderControl_MouseLeave(object sender, EventArgs e)
        {
            if (_btnPickAlpha.Checked)
                _pnlAlpha.BackColor = _oldAlpha;
        }

        private void renderControl_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                PickAlpha();
                PaintSpriteSet();
                _btnPickAlpha.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void renderControl_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                PickAlpha();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void _btnPickAlpha_CheckedChanged(object sender, EventArgs e)
        {
            if (_btnPickAlpha.Checked)
                _ucTileSetRenderer.Cursor = Cursors.Cross;
            else
                _ucTileSetRenderer.Cursor = Cursors.Default;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
        //    _ucTileSetRenderer.Texture = null;

            listBoxSprites.Items.Clear();
            
            PaintSpriteSet();
        }
    }
}
