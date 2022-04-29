using System.Diagnostics;

namespace Øvelse2
{
    public class ThreadPoolDemo
    {
        // Q: Hvad sker der med eksekveringstiden?
        // A: For ThreadPool bliver den ikke meget større, men for separate Thread's gør den
        static void Process(object? obj)
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                for (int j = 0; j < int.MaxValue; j++)
                {
                }
            }
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
