using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private static int tileSize {  get { return (Settings.Zoom + 1) * 8; } }
        private Map _map = new Map();

        public Form1()
        {
            InitializeComponent();
            _map.Load(Settings.MapName);
            UpdateUIState();
            UpdateMapImage();

            //panel2.AutoScroll = false;
            //panel2.VerticalScroll.Visible = true;
            //panel2.AutoScrollMinSize = new Size(256 * TILESIZE, 256 * TILESIZE);
            //panel2.HorizontalScroll.Visible = true;
            //panel2.VerticalScroll.Maximum = 2048;
            //panel2.HorizontalScroll.Maximum = 2048;
            //panel2.VerticalScroll.Enabled = true;
            //panel2.HorizontalScroll.Enabled = true;
        }

        private void UpdateMapImage()
        {
            var gfx1 = panel2.CreateGraphics();

            using (mapPicture.Image) { }

            var img = new Bitmap(256 * tileSize, 256 * tileSize);
            using (var gfx = Graphics.FromImage(img))
            {
                for (var y = 0; y < 256; ++y)
                {
                    for (var x = 0; x < 256; ++x)
                    {
                        var tile = _map.GetTileData(x, y);
                        var tileIndex = ((tile & 0x07FF0000) >> 16);
                        var sheetIndex = tile & 0x0000000F;
                        var image = Spritesheet.GetTileImage((int)sheetIndex, (int)tileIndex);

                        //gfx.DrawImage(Spritesheet.GetTileImage((int)sheetIndex, (int)tileIndex), at);
                        gfx.DrawImage(image, x * tileSize, y * tileSize, tileSize, tileSize);

                        if (tileIndex >= 659)
                        {
                            gfx.DrawImage(Utils.OrangeBlock, x * tileSize, y * tileSize, tileSize, tileSize);
                        }

                        if (Settings.ShowPassableState && (tile & ((1 << 6) | (1 << 7))) > 0)
                        {
                            gfx.DrawImage(Utils.RedBlock, x * tileSize, y * tileSize, tileSize, tileSize);
                        }
                    }
                }
            }

            mapPicture.Image = img;
            mapPicture.Width = img.Width;
            mapPicture.Height = img.Height;
        }
        
        private void panel2_MouseClick(object sender, MouseEventArgs e)
        {
            var x = (e.X / tileSize);
            var y = (e.Y / tileSize);
            var i = _map.GetTileIndex(x, y);
            var tile = _map.GetTileData(x, y);
            var tileIndex = ((tile & 0x07FF0000) >> 16);
            var sheetIndex = tile & 0x0000000F;

            var text = $@"Tile {i}: X={x} Y={y}

Bits:
  Sprite sheet: {sheetIndex}
  ?           : {(tile & (1 << 4)) > 0}
  ?           : {(tile & (1 << 5)) > 0}
  PLR Impass 2: {(tile & (1 << 6)) > 0}
  PLR Impass 1: {(tile & (1 << 7)) > 0}
  ?           : {(tile & (1 << 8)) > 0}
  ?           : {(tile & (1 << 9)) > 0}
  ?           : {(tile & (1 << 10)) > 0}
  ?           : {(tile & (1 << 11)) > 0}
  NPC Pass 3  : {(tile & (1 << 12)) > 0}
  NPC Pass 2  : {(tile & (1 << 13)) > 0}
  NPC Pass 1  : {(tile & (1 << 14)) > 0}
  ?           : {(tile & (1 << 15)) > 0}
  Sprite tile : {tileIndex}
  Enemy Impass: {(tile & (1 << 27)) > 0}
  ?           : {(tile & (1 << 28)) > 0}
  ?           : {(tile & (1 << 29)) > 0}
  Door        : {(tile & (1 << 30)) > 0}
  Portal      : {(tile & (1 << 31)) > 0}
";
            textBox1.Text = text;



        }

        void UpdateUIState()
        {
            showPassableStateBtn.Checked = Settings.ShowPassableState;
            openTownMapBtn.Checked = Settings.MapName == "TOWN";
            openWorldMapBtn.Checked = Settings.MapName == "WORLD";
            openMineMapBtn.Checked = Settings.MapName == "MINE";

            zoom25Btn.Checked = Settings.Zoom == 0;
            zoom50Btn.Checked = Settings.Zoom == 1;
            zoom100Btn.Checked = Settings.Zoom == 3;
        }

        private void showPassableStateBtn_Click(object sender, EventArgs e)
        {
            Settings.ShowPassableState = !Settings.ShowPassableState;
            UpdateUIState();
            UpdateMapImage();
        }


        private void openTownMapBtn_Click(object sender, EventArgs e)
        {
            _map.Load(Settings.MapName = "TOWN");
            UpdateUIState();
            UpdateMapImage();
        }

        private void openWorldMapBtn_Click(object sender, EventArgs e)
        {
            _map.Load(Settings.MapName = "WORLD");
            UpdateUIState();
            UpdateMapImage();
        }

        private void openMineMapBtn_Click(object sender, EventArgs e)
        {
            _map.Load(Settings.MapName = "MINE");
            UpdateUIState();
            UpdateMapImage();
        }

        private void zoom25Btn_Click(object sender, EventArgs e)
        {
            Settings.Zoom = 0;
            UpdateUIState();
            UpdateMapImage();
        }

        private void zoom50Btn_Click(object sender, EventArgs e)
        {
            Settings.Zoom = 1;
            UpdateUIState();
            UpdateMapImage();
        }

        private void zoom100Btn_Click(object sender, EventArgs e)
        {
            Settings.Zoom = 3;
            UpdateUIState();
            UpdateMapImage();
        }
    }
}
