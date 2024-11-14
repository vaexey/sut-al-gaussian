using Gaussian.Lib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian.Processing
{
    public class Process(
        string libName,
        int radius,
        int threadCount,
        string sourcePath,
        string destPath
            ) : IDisposable
    {
        GaussianDLL lib = new($"./{libName}");

        int radius = radius;
        int threadCount = threadCount;
        string sourcePath = sourcePath;
        string destPath = destPath;

        List<Thread> threads = new();
        ConcurrentBag<int> done = new();

        Mat? source;
        Mat? dest;
        GKernel kernel = new(radius);

        IEnumerable<Thread> generateThreads(int count, int block)
        {
            int blockPerThread = (int)Math.Ceiling(1.0 * block / count);
            int index = 0;

            for (int i = 0; i < count; i++)
            {
                var id = i;
                int startIndex = index;

                index += blockPerThread;

                int endIndex = Math.Min(index, block);

                yield return new Thread(() =>
                {
                    threadSubroutine(id, startIndex, endIndex);
                });
            }
        }

        public unsafe void Load()
        {
            if (source is not null)
                throw new InvalidOperationException("Process has already been loaded");

            //for (int i = 0; i < kernel.Kernel.Length; i++)
            //{
            //    kernel.Kernel[i] = 1;
            //}
            //kernel.Kernel[1] = 2;
            //kernel.Kernel[3] = 2;
            //kernel.Kernel[5] = 2;
            //kernel.Kernel[7] = 2;

            //kernel.Kernel[4] = 3;
            lib.gauss_kernel((byte*)kernel.Ptr(), radius);

            var bitmap = new Bitmap(sourcePath);
            var cloned = new Bitmap(bitmap.Width,bitmap.Height,bitmap.PixelFormat);

            source = new Mat(bitmap);
            dest = new Mat(cloned);

            threads = generateThreads(threadCount, source.Height).ToList();

            Console.WriteLine($"Prepared {threads.Count} threads");
        }

        public void Start()
        {
            if (source is null)
                throw new InvalidOperationException("Source was not loaded prior to starting");

            foreach(var thread in threads)
            {
                thread.Start();
            }
        }

        unsafe void threadSubroutine(int id, int startIndex, int endIndex)
        {
            if(startIndex == 0)
            {
                startIndex = radius;
            }

            if(endIndex == source.Height)
            {
                endIndex -= 2* radius;
            }


            Console.WriteLine($"Started thread #{id} with range {startIndex}::{endIndex}");

            if (source is null)
                throw new InvalidOperationException("Source was not loaded prior to starting");

            //lib.filter_24bpp_k3((byte*)kernel.Ptr(), source.Data, source.Data, startIndex, endIndex, source.Width, source.Stride);
            lib.filter_uniform((byte*)kernel.Ptr(), radius, source.Data, dest.Data, startIndex, endIndex, source.Width, source.Stride);

            Console.WriteLine($"Thread #{id} completed");

            onThreadFinished(id);
        }

        void onThreadFinished(int id)
        {
            done.Add(id);

            if(done.Count >= threadCount)
            {
                Console.WriteLine("Finished processing");

                source.Dispose();
                dest.Dispose();

                var bmp = dest.Source;

                bmp.Save(destPath);
                bmp.Dispose();
            }
        }

        public void Dispose()
        {
            lib.Dispose();

            if(source is not null)
            {
                source.Dispose();
                source.Source.Dispose();
            }
        }
    }
}
