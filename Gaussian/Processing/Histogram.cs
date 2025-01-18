using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian.Processing
{
    public class Histogram
    {
        public Bitmap? Result { get; set; } = null;

        public Thread? Thread { get; protected set; }

        protected Bitmap source;

        public Histogram(Bitmap raw)
        {
            source = new Bitmap(raw);
        }

        public void Generate()
        {
            Thread = new Thread(threadSubroutine);
            Thread.Start();
        }

        private void threadSubroutine()
        {
            int width = source.Width;
            int height = source.Height;

            int total = width * height;

            var hr = new float[256];
            var hg = new float[256];
            var hb = new float[256];

            for (int y = 0; y < height; y++)
            {
                for(int x = 0; x < width; x++)
                {
                    var clr = source.GetPixel(x, y);

                    hr[clr.R]++;
                    hg[clr.G]++;
                    hb[clr.B]++;
                }
            }

            source.Dispose();

            normalize(hr, 255);
            normalize(hg, 255);
            normalize(hb, 255);

            var hist = new Bitmap(1024, 1024);

            using var g = Graphics.FromImage(hist);

            drawHistogram(g, hr, hg, hb);

            Result = hist;
        }

        static void normalize(float[] raw, float limit)
        {
            var max = raw.Max();

            for(int i = 0; i < raw.Length; i++)
            {
                raw[i] = (float)Math.Round(raw[i] / max * limit);
            }
        }

        static void drawHistogram(Graphics g, float[] hr, float[] hg, float[] hb)
        {
            var w = 1024;
            var h = 1024;

            var t = 1;
            var t2 = 2;

            using var br = new SolidBrush(Color.FromArgb(85, 255, 0, 0));
            using var bg = new SolidBrush(Color.FromArgb(85, 0, 255, 0));
            using var bb = new SolidBrush(Color.FromArgb(85, 0, 0, 255));

            using var pr = new Pen(br, t);
            using var pg = new Pen(bg, t);
            using var pb = new Pen(bb, t);

            using var pr2 = new Pen(br, t2);
            using var pg2 = new Pen(bg, t2);
            using var pb2 = new Pen(bb, t2);

            g.FillRectangle(Brushes.White, 0, 0, w, h);

            for (int i = 0; i < 254; i++)
            {
                g.DrawLine(pr, i * 4, h - 4 * hr[i], (i + 1) * 4, h - 4 * hr[i + 1]);
                g.DrawLine(pg, i * 4, h - 4 * hg[i], (i + 1) * 4, h - 4 * hg[i + 1]);
                g.DrawLine(pb, i * 4, h - 4 * hb[i], (i + 1) * 4, h - 4 * hb[i + 1]);

                g.DrawLine(pr2, i * 4, h - 4 * hr[i], (i + 1) * 4, h - 4 * hr[i + 1]);
                g.DrawLine(pg2, i * 4, h - 4 * hg[i], (i + 1) * 4, h - 4 * hg[i + 1]);
                g.DrawLine(pb2, i * 4, h - 4 * hb[i], (i + 1) * 4, h - 4 * hb[i + 1]);

            }
        }
    }
}
