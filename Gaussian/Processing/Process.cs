using Gaussian.Lib;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
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

        Bitmap? result;

        Stopwatch sw = new();

        IEnumerable<Thread> generateThreads(int count, int block)
        {
            int index = 0;

            // Remove dangerous Y regions from distribution
            index += radius;
            block -= radius;

            int blockPerThread = (int)Math.Floor(1.0 * block / count);

            for (int i = 0; i < count; i++)
            {
                var id = i;
                int startIndex = index;

                index += blockPerThread;

                int endIndex = index;

                if(i == count - 1)
                {
                    endIndex = block - 1;
                }

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

            Console.WriteLine($"Using lib '{lib.GetId()}'");
            lib.GaussKernel(kernel);

            var bitmap = new Bitmap(sourcePath);
            var cloned = new Bitmap(bitmap.Width,bitmap.Height,bitmap.PixelFormat);

            if((bitmap.Height - 2*radius) <= threadCount)
            {
                throw new InvalidOperationException("Image is too small for this operation. Select a bigger image or decrease the thread count.");
            }

            source = new Mat(bitmap);
            dest = new Mat(cloned);

            threads = generateThreads(threadCount, source.Height).ToList();

            Console.WriteLine($"Prepared {threads.Count} threads");
        }

        public void Start()
        {
            if (source is null)
                throw new InvalidOperationException("Source was not loaded prior to starting");

            sw.Start();

            foreach (var thread in threads)
            {
                thread.Start();
            }
        }

        unsafe void threadSubroutine(int id, int startIndex, int endIndex)
        {
            Console.WriteLine($"Started thread #{id} with range {startIndex}::{endIndex}");

            if (source is null)
                throw new InvalidOperationException("Source was not loaded prior to starting");

            lib.FilterUniformRaw((byte*)kernel.Ptr(), radius, source.Data, dest.Data, startIndex, endIndex, source.Width, source.Height, source.Stride);

            Console.WriteLine($"Thread #{id} completed");

            onThreadFinished(id);
        }

        void onThreadFinished(int id)
        {
            done.Add(id);

            if(done.Count >= threadCount)
            {
                sw.Stop();

                Console.WriteLine("Finished processing");

                source.Dispose();
                dest.Dispose();

                var temp = dest.Source;

                source = null;
                dest = null;

                temp.Save(destPath);

                result = temp;
            }
        }

        public void Dispose()
        {
            lib.Dispose();

            if (source is not null)
            {
                source.Dispose();
                source.Source.Dispose();
            }

            if(dest is not null)
            {
                dest.Dispose();
                dest.Source.Dispose();
            }

            if (result is not null)
            {
                result.Dispose();
            }

        }

        public Bitmap? GetSource()
        {
            return source?.Source;
        }

        public Bitmap? GetResult()
        {
            return result;
        }

        public double GetElapsed()
        {
            return sw.Elapsed.TotalMilliseconds;
        }
    }
}
