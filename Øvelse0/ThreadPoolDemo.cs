using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Øvelse0
{
    public class ThreadPoolDemo
    {
        public void Task1(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 1 is being executed");
            }
        }

        public void Task2(object obj)
        {
            for (int i = 0; i <= 2; i++)
            {
                Console.WriteLine("Task 2 is being executed");
            }
        }
    }
}
