using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.IO;

using System.Windows.Forms;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using CastleLegends.Editor.RenderModels;
using CastleLegends.Editor.UserControls;
using GlyphEngine.Utils;
using CastleLegends.Common;

namespace CastleLegends.Editor
{
    public partial class frmSpriteTool : Form
    {
   //     private ucTilesetRenderer _ucTileSetRenderer = null;
        private RenderTarget2D _renderTarget = null;
        private SpriteBatch _spriteBatch = null;
        private int _numRows = 0;
        private int _imgWidth = 0;
        private int _imgHeight = 0;

        private Tileset _tileSet = null;

        private System.Drawing.Color _oldAlpha;
        
        public frmSpriteTool()
        {
            InitializeComponent();          
        }

        private void InitRenderer()
        {      
            _spriteBatch = new SpriteBatch(_ucTileSetRenderer.GraphicsDevice);
        }

        private void LoadSprites()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.bmp;*.jpg;*.png;*.tga";
            ofd.Multiselect = true;
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            var filenames = ofd.FileNames.OrderBy(f => f);

            foreach (string f in filenames)
            {
                var texture = TextureHelpers.LoadTexture(_ucTileSetRenderer.GraphicsDevice, f);
                var sprite = new SpriteViewModel(texture);
                listBoxSprites.Items.Add(sprite);
            }

            _btnPickAlpha.Enabled = true;

            PaintSpriteSet();

            lblNumRows.Text = _numRows.ToString();
            lblImgHeight.Text = _imgHeight.ToString();
            lblImgWidth.Text = _imgWidth.ToString();
        }

        private void PaintSpriteSet()
        {
            _numRows = _imgWidth = _imgHeight = 0;

            if (listBoxSprites.Items.Count == 0)
                return;
            
            int numCols = (int)numUpDownNumCols.Value;
            _numRows = (int)decimal.Ceiling(listBoxSprites.Items.Count / numUpDownNumCols.Value);

            var sprites = listBoxSprites.Items.Cast<SpriteViewModel>().ToArray();

            var maxTileWidth = sprites.Max(s => s.Texture.Width);
            var maxTileHeight = sprites.Max(s => s.Texture.Height);

            _imgWidth = maxTileWidth * numCols;
            _imgHeight = maxTileHeight * _numRows;
            
            _ucTileSetRenderer.SetTileset(null);

            _renderTarget = new RenderTarget2D(_ucTileSetRenderer.GraphicsDevice, _imgWidth, _imgHeight);            

            _ucTileSetRenderer.GraphicsDevice.SetRenderTarget(_renderTarget);

            _ucTileSetRenderer.GraphicsDevice.Clear(Color.Black);
            
            _spriteBatch.Begin();

            int spriteID = 0;
            for (int r = 0; r != _numRows; ++r)
            {
                for (int c = 0; c != numCols; ++c)
                {
                    if (spriteID >= sprites.Length)
                        break;
                    var sprite = sprites[spriteID++];

                    var sourceRec = new Rectangle(0, 0, sprite.Texture.Width, sprite.Texture.Height);
                    var destRec = new Rectangle(c * maxTileWidth, r * maxTileHeight, maxTileWidth, maxTileHeight);                    

                    _spriteBatch.Draw(sprite.Texture, destRec, sourceRec, Color.White);
                }
            }
            _spriteBatch.End();
            _ucTileSetRenderer.GraphicsDevice.SetRenderTarget(null);

            _tileSet = new Tileset("[Not Set]", maxTileWidth, maxTileHeight);
            var tileSetVm = new TilesetViewModel(_tileSet, _renderTarget);            

            _ucTileSetRenderer.SetTileset(tileSetVm);
            //_ucTileSetRenderer.SetAlpha(_alpha);
        }

        private void Save()
        {
            var sfd = new SaveFileDialog();
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

        private void PickAlpha()
        {
            if (!_btnPickAlpha.Checked || null == _renderTarget)
                return;

            var pickedPoint = _ucTileSetRenderer.PointToClient(Cursor.Position);

            if (pickedPoint.X > _renderTarget.Width || pickedPoint.Y > _renderTarget.Height)
                return;

            var sourceRectangle = new Rectangle(pickedPoint.X, pickedPoint.Y, 1, 1);

            var retrievedColor = new Color[1];
            _renderTarget.GetData<Color>(0, sourceRectangle, retrievedColor, 0, 1);            
            _tileSet.Alpha = retrievedColor[0];
            _pnlAlpha.BackColor = System.Drawing.Color.FromArgb(_tileSet.Alpha.R, _tileSet.Alpha.G, _tileSet.Alpha.B);
        }

        #region Form Events

        protected override void OnLoad(EventArgs e)
        {
            InitRenderer();
            _ucTileSetRenderer.ShowGrid = true;
            _ucTileSetRenderer.EnableSelection = false;
            numUpDownNumCols.Value = 1;
        }

        private void numUpDownNumCols_ValueChanged(object sender, EventArgs e)
        {
            PaintSpriteSet();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSprites();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
                _btnPickAlpha.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
                MessageBox.Show(ex.ToString());
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
            _ucTileSetRenderer.SetTileset(null);
        
            listBoxSprites.Items.Clear();
        }

        #endregion Form Events
    }
}
