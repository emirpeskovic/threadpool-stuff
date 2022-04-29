using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse3
{
    public class ThreadPoolDemo
    {
        static void PrintProperties(object? obj)
        {
            Console.WriteLine($"ManagedThreadId: {Thread.CurrentThread.ManagedThreadId} | IsAlive: {Thread.CurrentThread.IsAlive} | IsBackground: {Thread.CurrentThread.IsBackground} | IsThreadPoolThread: {Thread.CurrentThread.IsThreadPoolThread} | Priority {Thread.CurrentThread.Priority}");
        }

        static void ExampleMethod()
        {
            // Thread.Sleep() makes the thread sleep for the specified amount of time.
            Thread.Sleep(1000);

            // Thread.Suspend() suspends the thread.
            // Thread.Suspend() is also not supported by this platform
            //Thread.CurrentThread.Suspend(); // Suspend is Obsolete

            while (true)
            {
                Console.WriteLine("Hello from ExampleMethod thread!");
                Thread.Sleep(1000);
            }
        }

        static void ExampleMethod2()
        {
            for (int i = 0; i < 1000000; i++)
            {
                
            }

            Console.WriteLine("ExampleMethod2 finished!");
        }

        public static void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                ThreadPool.QueueUserWorkItem(PrintProperties, null);
            }

            Thread t1 = new(ExampleMethod);
            
            // Thread.Start() starts the thread
            t1.Start();
            
            Thread t2 = new(ExampleMethod2);
            t2.Start();

            // Thread.Join() makes the current thread wait until the thread t2 finishes.
            t2.Join();

            // Check if the thread is alive
            // If not, the thread is suspended and can be started again
            // If the thread didn't suspend in time for this to be called, it will skip resuming it
            if (!t1.IsAlive)
            {
                // Resume the thread if it is suspended
                // Thread.Resume() is not supported by this platform
                //t1.Resume(); // Resume is also obsolete
            }

            // We make the main thread wait for a second
            Thread.Sleep(1000);

            // Thread.Abort() aborts the thread
            // Thread.Abort() is not supported by this platform
            //t1.Abort(); // Abort is Obsolete
        }
    }
}
