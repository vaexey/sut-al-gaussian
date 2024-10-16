using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian
{
    public unsafe class GaussianDLL : DLL
    {
        public delegate void d_filter(
            byte* src,
            byte* dest,
            int width,
            int height,
            sbyte kernel
        );

        public delegate void d_gauss_kernel(
            byte* kernel,
            int radius
        );

        public delegate int d_gauss_kernel_size(
            int radius
        );

        public GaussianDLL(string path) : base(path)
        {
            filter =
                GetProc<d_filter>("filter");
            gauss_kernel =
                GetProc<d_gauss_kernel>("gauss_kernel");
            gauss_kernel_size = 
                GetProc<d_gauss_kernel_size>("gauss_kernel_size");
        }

        public d_filter filter;
        public d_gauss_kernel gauss_kernel;
        public d_gauss_kernel_size gauss_kernel_size;
    }
}
