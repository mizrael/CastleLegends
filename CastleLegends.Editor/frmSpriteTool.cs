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
            _ucTileSetRenderer.ShowGrid = true;
            _ucTileSetRenderer.EnableSelection = false;
            _ucTileSetRenderer.ClearColor = Color.CornflowerBlue;

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
                var sprite = new SpriteViewModel(texture, Path.GetFileName(f));
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
        }

        private void Save()
        {
            var sfd = new SaveFileDialog();
            sfd.AddExtension = true;
            sfd.Filter = "Png|*.png";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var stream = new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write))
                _renderTarget.SaveAsPng(stream, _renderTarget.Width, _renderTarget.Height);
        }

        private void PickAlpha()
        {
            if (!_btnPickAlpha.Checked || null == _renderTarget)
                return;

            var pickedPoint = _ucTileSetRenderer.PointToClient(Cursor.Position);

            if (pickedPoint.X >= _renderTarget.Width || pickedPoint.Y >= _renderTarget.Height)
                return;

            var sourceRectangle = new Rectangle(pickedPoint.X, pickedPoint.Y, 1, 1);

            var retrievedColor = new Color[1];
            _renderTarget.GetData<Color>(0, sourceRectangle, retrievedColor, 0, 1);

            var pickedAlpha = retrievedColor[0];
            _pnlAlpha.BackColor = System.Drawing.Color.FromArgb(pickedAlpha.R, pickedAlpha.G, pickedAlpha.B);
        }

        private void SetAlpha(Color alpha)
        {
            if (null == _renderTarget) 
                return;
            int size = _renderTarget.Width * _renderTarget.Height;
            var data = new Color[size];
            _renderTarget.GetData<Color>(data);
            for (int i = 0; i != size; ++i)
            {
                if (data[i].R == _oldAlpha.R &&
                    data[i].G == _oldAlpha.G &&
                    data[i].B == _oldAlpha.B)
                    data[i].A = 255;
                
                if (data[i].R == alpha.R &&
                    data[i].G == alpha.G &&
                    data[i].B == alpha.B)
                    data[i].A = 0;

            }
            _renderTarget.SetData<Color>(data);
        }

        #region Form Events

        protected override void OnLoad(EventArgs e)
        {
            InitRenderer();
            
            this.numUpDownNumCols.Value = 1;
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
                
                _tileSet.Alpha = new Color(_pnlAlpha.BackColor.R, _pnlAlpha.BackColor.G, _pnlAlpha.BackColor.B);

                SetAlpha(_tileSet.Alpha);

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
