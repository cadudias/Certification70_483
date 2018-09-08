using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace UsarBibliotecaTaskParallel
{
    class Program
    {
        public static void Main()
        {
            // usando a classe ThreadPool
            // Queue the task.
            //ThreadPool.QueueUserWorkItem(ThreadProc);
            //Console.WriteLine("Main thread does some work, then sleeps.");
            //Thread.Sleep(3000);

            //Console.WriteLine("Main thread exits.");
            //Console.ReadLine();

            // Parallel For
            //ParallelForExample.GetFilesTotalSizeFromDirectory();
            //MultiplyMatricesParalleForRegularForComparison();

            // Tasks
            TaskExample.Run();
        }

        private static void MultiplyMatricesParalleForRegularForComparison()
        {
            // Set up matrices. Use small values to better view 
            // result matrix. Increase the counts to see greater 
            // speedup in the parallel loop vs. the sequential loop.
            int colCount = 180;
            int rowCount = 2000;
            int colCount2 = 270;
            double[,] m1 = MultiplyMatricesParalleForComparison.InitializeMatrix(rowCount, colCount);
            double[,] m2 = MultiplyMatricesParalleForComparison.InitializeMatrix(colCount, colCount2);
            double[,] result = new double[rowCount, colCount2];

            // First do the sequential version.
            Console.Error.WriteLine("Executing sequential loop...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            MultiplyMatricesParalleForComparison.MultiplyMatricesSequential(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Sequential loop time in milliseconds: {0}",
                stopwatch.ElapsedMilliseconds);

            // For the skeptics.
            MultiplyMatricesParalleForComparison.OfferToPrint(rowCount, colCount2, result);

            // Reset timer and results matrix. 
            stopwatch.Reset();
            result = new double[rowCount, colCount2];

            // Do the parallel loop.
            Console.Error.WriteLine("Executing parallel loop...");
            stopwatch.Start();
            MultiplyMatricesParalleForComparison.MultiplyMatricesParallel(m1, m2, result);
            stopwatch.Stop();
            Console.Error.WriteLine("Parallel loop time in milliseconds: {0}",
                stopwatch.ElapsedMilliseconds);
            MultiplyMatricesParalleForComparison.OfferToPrint(rowCount, colCount2, result);

            // Keep the console window open in debug mode.
            Console.Error.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        // This thread procedure performs the task.
        static void ThreadProc(Object stateInfo) 
        {
            // No state object was passed to QueueUserWorkItem, so stateInfo is null.
            Console.WriteLine("Hello from the thread pool.");
        }
    }
}
