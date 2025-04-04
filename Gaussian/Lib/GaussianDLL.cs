﻿//#define DEBUG_EXTERNS_ASM
//#define DEBUG_EXTERNS_HLL

#if DEBUG_EXTERNS_ASM
#define DEBUG_EXTERNS
#endif

#if DEBUG_EXTERNS_HLL
#define DEBUG_EXTERNS
#endif

#if DEBUG_EXTERNS_ASM
#if DEBUG_EXTERNS_HLL
#error GaussianDLLDebugExterns configuration is incorrect
#endif
#endif

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Gaussian.Processing;

namespace Gaussian.Lib
{

#if DEBUG_EXTERNS
#if !DEBUG
#error GaussianDLLDebugExterns should only be used for Debug configuration
#endif
    /**
     * Externs provided to allow native code debugging
     * for development purposes.
     * Not meant for production.
     */
    internal unsafe static class GaussianDLLDebugExterns
    {
#if DEBUG_EXTERNS_ASM
        internal const string LIB_NAME = "ASM";
#endif

#if DEBUG_EXTERNS_HLL
        internal const string LIB_NAME = "HLL";
#endif
        internal const string LIB_PATH = @$"..\..\..\..\x64\Debug\Gaussian{LIB_NAME}.dll";


        [DllImport(LIB_PATH)]
        internal static extern void gauss_kernel(
            byte* kernel,
            int radius
        );

        [DllImport(LIB_PATH)]
        internal static extern int gauss_kernel_size(
            int radius
        );

        [DllImport(LIB_PATH)]
        internal static extern void filter_uniform(
            byte* kernel,
            int radius,
            byte* src,
            byte* dest,
            int startIndex,
            int endIndex,
            int width,
            int height,
            int stride
        );
    }
#endif

    public unsafe class GaussianDLL : DLL
    {

        public delegate void d_gauss_kernel(
            byte* kernel,
            int radius
        );

        public delegate int d_gauss_kernel_size(
            int radius
        );

        public delegate void d_filter_uniform(
            byte* kernel,
            int radius,
            byte* src,
            byte* dest,
            int startIndex,
            int endIndex,
            int width,
            int height,
            int stride
        );

        protected d_gauss_kernel gauss_kernel;
        protected d_gauss_kernel_size gauss_kernel_size;
        protected d_filter_uniform filter_uniform;

        public GaussianDLL(string path) : base(path)
        {
#if DEBUG_EXTERNS
            gauss_kernel = GaussianDLLDebugExterns.gauss_kernel;
            gauss_kernel_size = GaussianDLLDebugExterns.gauss_kernel_size;
            filter_uniform = GaussianDLLDebugExterns.filter_uniform;
#else
            gauss_kernel =
                GetProc<d_gauss_kernel>("gauss_kernel");
            gauss_kernel_size =
                GetProc<d_gauss_kernel_size>("gauss_kernel_size");
            filter_uniform =
                GetProc<d_filter_uniform>("filter_uniform");
#endif
        }

        public void FilterUniformRaw(
            byte* kernel,
            int radius,
            byte* src,
            byte* dest,
            int startIndex,
            int endIndex,
            int width,
            int height,
            int stride
        )
        {
            filter_uniform(
                kernel,
                radius,
                src,
                dest,
                startIndex,
                endIndex,
                width,
                height,
                stride
            );
        }

        public void GaussKernel(GKernel kernel)
        {
            gauss_kernel((byte*)kernel.Ptr(), kernel.Radius);
            kernel.Unlock();
        }
    }
}
