using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian.Processing
{
    public unsafe class Mat : IDisposable
    {
        public Bitmap Source { get; }
        public byte* Data { get; }
        public int Width { get; }
        public int Height { get; }
        public int BPP { get; }
        public int Stride { get; }

        private BitmapData bData;

        public Mat(Bitmap src)
        {
            Source = src;
            Width = src.Width;
            Height = src.Height;

            bData = src.LockBits(
                new Rectangle(0, 0, Width, Height),
                ImageLockMode.ReadWrite,
                src.PixelFormat
            );

            Stride = bData.Stride;
            BPP = Image.GetPixelFormatSize(bData.PixelFormat);
            Data = (byte*)bData.Scan0.ToPointer();
        }

        public void Dispose()
        {
            Source.UnlockBits(bData);
        }
    }
}
