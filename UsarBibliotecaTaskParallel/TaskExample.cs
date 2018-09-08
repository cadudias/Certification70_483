using System;
using System.Threading;
using System.Threading.Tasks;

namespace UsarBibliotecaTaskParallel
{
    public class TaskExample
    {
        public static void Run()
        {
            Task t1 = new Task(() => ThreadedMessage("Run Task 1"));
            t1.Start();

            Task t2 = Task.Run(() => ThreadedMessage("Run Task 2"));

            Task t3 = Task.Factory.StartNew(() => ThreadedMessage("Run Task 3"));

            ThreadedMessage("Run Task 4");

            // or
            Task[] tasks = new Task[] {
                t1, t2, t3
            };
            Task.WaitAll(tasks);
        }

        private static void ThreadedMessage(string msg, params object[] args)
        {
            Console.WriteLine("{0}({1}): {2}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId, String.Format(msg, args));
        }
    }
}
