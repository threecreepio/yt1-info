using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WindowsFormsApplication1
{
    public class Spritesheet
    {
        private static IDictionary<int, Spritesheet> _sheets = new Dictionary<int, Spritesheet>();
        
        public static Spritesheet GetSheet(int spritesheet)
        {
            if (!_sheets.ContainsKey(spritesheet))
            {
                var sheet = new Spritesheet(spritesheet);
                _sheets[spritesheet] = sheet;
            }
            return _sheets[spritesheet];
        }

        public static Image GetTileImage(int spritesheet, int tile)
        {
            return GetSheet(spritesheet).GetTileImage(tile);
        }

        private IDictionary<int, Image> _images = new Dictionary<int, Image>();
        private int _index;
        private byte[] _data;

        private Spritesheet(int index)
        {
            _data = System.IO.File.ReadAllBytes("C:\\dev\\dosbox\\Yendor\\FILE" + index.ToString().PadLeft(2, '0') + ".16");
        }

        public Image GetTileImage(int tile)
        {
            if (_images.ContainsKey(tile))
            {
                return _images[tile];
            }

            var bmp = new Bitmap(32, 32);

            var colors = new uint[32 * 32];
            for (uint clr = 0; clr < 4; ++clr)
            {
                for (uint pxy = 0; pxy < 32; ++pxy)
                {
                    uint mem = (((clr * 32) + pxy) * 4) + (uint) (tile * 512);
                    if (mem > _data.Length - 4) continue;


                    // var value = ((_data[mem + 0]) << 24) | ((_data[mem + 1]) << 16) | ((_data[mem + 2]) << 8) | ((_data[mem + 3]));
                    var value = Utils.ReadUInt32(_data, mem);

                    // var value = BitConverter.ToUInt32(_data, (int) mem);
                    for (var pxx = 0; pxx < 32; ++pxx)
                    {
                        var pxi = (pxy * 32) + (31 - pxx);
                        if (((value >> pxx) & 1) > 0)
                        {
                            colors[pxi] |= (1u << (int) clr);
                        }
                    }
                }
            }

            unchecked
            {
                for (var y = 0; y < 32; ++y)
                {
                    for (var x = 0; x < 32; ++x)
                    {
                        var color = colors[(y * 32) + x];
                        Color c;
                        switch (color)
                        {
                            case 0:
                                c = Color.FromArgb((int) 0xFF000000);
                                break;
                            case 1:
                                c = Color.FromArgb((int) 0xFF1b5503);
                                break;
                            case 2:
                                c = Color.FromArgb((int) 0xFF560c0b);
                                break;
                            case 3:
                                c = Color.FromArgb((int) 0xFFf66161);
                                break;
                            case 4:
                                c = Color.FromArgb((int) 0xFF9f9f9f);
                                break;
                            case 5:
                                c = Color.FromArgb((int) 0xFF84c60c);
                                break;
                            case 6:
                                c = Color.FromArgb((int) 0xFF3ba1d8); // alternates between 3ba1d8 and 0055a9
                                break;
                            case 7:
                                c = Color.FromArgb((int) 0xFF0056aa);
                                break;
                            case 8:
                                c = Color.FromArgb((int) 0xFF606060);
                                break;
                            case 9:
                                c = Color.FromArgb((int) 0xFF3e9929);
                                break;
                            case 10:
                                c = Color.FromArgb((int) 0xFFaa5606);
                                break;
                            case 11:
                                c = Color.FromArgb((int) 0xFF3ba1d8); // blinks between 3ba1d8 (1 frame) and 0055a9 (more frames)
                                break;
                            case 12:
                                c = Color.FromArgb((int) 0xFFb4b46b);
                                break;
                            case 13:
                                c = Color.FromArgb((int) 0xFFaa0000);
                                break;
                            case 14:
                                c = Color.FromArgb((int) 0xFFf6a14d);
                                break;
                            case 15:
                                c = Color.FromArgb((int) 0xFFffffff);
                                break;
                            default:
                                throw new InvalidOperationException("unexpected color");
                        }
                        bmp.SetPixel(x, y, c);
                    }
                }
            }

            _images[tile] = bmp;
            return bmp;
        }
    }
}
