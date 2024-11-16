using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian.Processing
{
    public unsafe class GKernel
    {
        public sbyte[] Kernel { get; }
        public int Radius { get; }

        private sbyte[] extendedKernel;

        public GKernel(int radius)
        {
            Kernel = new sbyte[(int)Math.Pow(2 * radius + 1, 2)];
            Radius = radius;

            int alignedSize = 16 * (int)Math.Ceiling(
                Kernel.Length / 16.0
            );

            extendedKernel = new sbyte[alignedSize];
        }

        public sbyte* Ptr()
        {
            fixed (sbyte* ptr = extendedKernel)
            {
                return ptr;
            }
        }

        public void Unlock()
        {
            for (int i = 0; i < Kernel.Length; i++)
                Kernel[i] = extendedKernel[i];
        }
    }
}
