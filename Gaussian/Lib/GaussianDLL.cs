using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gaussian.Processing;
using static Gaussian.Lib.GaussianDLL;

namespace Gaussian.Lib
{
    public unsafe class GaussianDLL : DLL
    {
        public delegate void d_filter(
            sbyte* kernel,
            int radius,
            byte* src,
            byte* dest,
            int width,
            int height,
            int stride,

            int y1,
            int y2
        );

        public delegate void d_gauss_kernel(
            byte* kernel,
            int radius
        );

        public delegate int d_gauss_kernel_size(
            int radius
        );

        public delegate void d_filter_24bpp_k3(
            byte* kernel,
            byte* src,
            byte* dest,
            int startIndex,
            int endIndex,
            int width,
            int stride
        );

        public delegate void d_filter_uniform(
            byte* kernel,
            int radius,
            byte* src,
            byte* dest,
            int startIndex,
            int endIndex,
            int width,
            int stride
        );

        public GaussianDLL(string path) : base(path)
        {
            //filter =
            //    GetProc<d_filter>("filter");
            gauss_kernel =
                GetProc<d_gauss_kernel>("gauss_kernel");
            gauss_kernel_size =
                GetProc<d_gauss_kernel_size>("gauss_kernel_size");
            filter_24bpp_k3 =
                GetProc<d_filter_24bpp_k3>("filter_24bpp_k3");

            filter_uniform =
                GetProc<d_filter_uniform>("filter_uniform");
        }

        public d_filter filter;
        public d_gauss_kernel gauss_kernel;
        public d_gauss_kernel_size gauss_kernel_size;
        public d_filter_24bpp_k3 filter_24bpp_k3;
        public d_filter_uniform filter_uniform;

        //public void Filter(Mat src, Mat dest, GKernel kernel, int y1, int y2)
        //{
        //    filter(
        //        kernel.Ptr(),
        //        kernel.Radius,
        //        src.Data,
        //        dest.Data,
        //        src.Width,
        //        src.Height,
        //        src.Stride,
        //        y1,
        //        y2
        //        );
        //}
    }
}
