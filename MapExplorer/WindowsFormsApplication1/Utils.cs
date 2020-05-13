using System.Drawing;

namespace WindowsFormsApplication1
{
    public static class Utils
    {

        public static uint ReadUInt32(byte[] data, uint offset)
        {
            return ((uint) (data[offset + 0]) << 24)
                | ((uint) (data[offset + 1]) << 16)
                | ((uint) (data[offset + 2]) << 8)
                | ((uint) (data[offset + 3]));
        }

        public static Bitmap OrangeBlock { get; private set; }
        public static Bitmap RedBlock { get; private set; }

        static Utils()
        {
            {
                var copy = new Bitmap(32, 32);
                for (var xx = 0; xx < copy.Width; ++xx)
                {
                    for (var yy = 0; yy < copy.Height; ++yy)
                    {
                        copy.SetPixel(xx, yy, Color.Orange);
                    }
                }
                OrangeBlock = copy;
            }
            {
                var copy = new Bitmap(32, 32);
                for (var xx = 0; xx < copy.Width; ++xx)
                {
                    for (var yy = 0; yy < copy.Height; ++yy)
                    {
                        copy.SetPixel(xx, yy, Color.FromArgb(180, Color.Red));
                    }
                }
                RedBlock = copy;
            }
        }


    }
}
