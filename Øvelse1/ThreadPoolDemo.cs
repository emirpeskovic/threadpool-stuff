using System.Diagnostics;

namespace Øvelse1
{
    public class ThreadPoolDemo
    {

        // Q: Skal metoden Process() tage et object som argument, begrund dit svar?
        // A: Ja, for QueueUserWorkItem() metoden skal tage et object som argument.
        static void Process(object? obj)
        {
            
        }

        static void ProcessWithThreadMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                Thread thread = new(Process);
                thread.Start();
            }
        }

        static void ProcessWithThreadPoolMethod()
        {
            for (int i = 0; i <= 10; i++)
            {
                ThreadPool.QueueUserWorkItem(Process);
            }
        }

        public static void Run()
        {
            Stopwatch stopWatch = new();
            Console.WriteLine("Thread Pool Execution");
            
            stopWatch.Start();
            ProcessWithThreadPoolMethod();
            stopWatch.Stop();

            Console.WriteLine($"Time consumed by ProcessWithThreadPoolMethod: {stopWatch.ElapsedMilliseconds}");
            stopWatch.Reset();

            Console.WriteLine("Thread Execution");

            stopWatch.Start();
            ProcessWithThreadMethod();
            stopWatch.Stop();

            Console.WriteLine($"Time consumed by ProcessWithThreadMethod: {stopWatch.ElapsedMilliseconds}");
        }
    }
}
