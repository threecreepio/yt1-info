using System;
using System.IO;

namespace WindowsFormsApplication1
{
    public class Map
    {
        public string Name { get; set; }
        private byte[] _data = new byte[256 * 256 * 4];

        public void Load(string name)
        {
            Name = name;
            _data = File.ReadAllBytes("C:\\dev\\dosbox\\Yendor\\" + name + ".DAT");
        }

        public int GetTileIndex(int x, int y)
        {
            return (y * 256 + x) * 4;
        }

        public uint GetTileData(int x, int y)
        {
            if (x > 256 || y > 256) return 0;
            return BitConverter.ToUInt32(_data, GetTileIndex(x, y));
        }

    }
}
