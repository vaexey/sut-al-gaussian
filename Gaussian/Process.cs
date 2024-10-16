using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaussian
{
    public class Process
    {
        delegate void ThreadTask();

        GaussianDLL gauss;
        Queue queue = Queue.Synchronized(new Queue());

        List<Thread> threads = new();
        bool disposed = false;

        public Process(GaussianDLL gauss, int threadCount)
        {
            this.gauss = gauss;

            for (int i = 0; i < threadCount; i++)
                threads.Add(new Thread(ThreadSub));
        }

        public void Start()
        {
            foreach (var thread in threads)
                thread.Start();
        }

        public void ProcessImage(Bitmap srcBmp)
        {
            var destBmp = new Bitmap(srcBmp.Width, srcBmp.Height);

            using var src = new Mat(srcBmp);
            using var dest = new Mat(destBmp);

            var heightPerThread = src.Height / threads.Count;
            var y = 0;

            for(int i = 0; i < threads.Count; i++)
            {
                int y1 = y;
                int y2 = Math.Min(y + heightPerThread, src.Height - 1);

                queue.Enqueue(() =>{
                    Console.WriteLine($"{y1} -> {y2}");
                });

                if (y2 == src.Height)
                    break;
            }
        }

        private void ThreadSub()
        {
            while(!disposed)
            {
                foreach (ThreadTask task in queue)
                {
                    task();
                }

                Thread.Sleep(1);
            }
        }

        
    }
}
