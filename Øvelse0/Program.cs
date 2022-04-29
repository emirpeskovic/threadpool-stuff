using Øvelse0;

// Create ThreadPoolDemo instance
ThreadPoolDemo demo = new();

// Queue demo tasks
for (int i = 0; i <= 2; i++)
{
    // Can be replaced with ThreadPool.QueueUserWorkItem(demo.Task1, i);
    ThreadPool.QueueUserWorkItem(new WaitCallback(demo.Task1), i);
    // Can be replaced with ThreadPool.QueueUserWorkItem(demo.Task2, i);
    ThreadPool.QueueUserWorkItem(new WaitCallback(demo.Task2), i);
}

// Read input to exit
Console.Read();

// Q: Hvad er forskellen?
// A: Ingen forskel på det kommenterede og det ikke kommenterede.