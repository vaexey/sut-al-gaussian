using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian
{
    public unsafe class GKernel
    {
        public sbyte[] Kernel { get; }
        public int Radius { get; }

        public GKernel(int radius) 
        {
            Kernel = new sbyte[2 * radius + 1];
            Radius = radius;
        }

        public sbyte* Ptr()
        {
            fixed(sbyte* ptr = Kernel)
            {
                return ptr;
            }
        }
    }
}
