using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyTestThreads
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var task = new Task(TestProcessAsync);
            task.Start();

            var task1 = new Task(TestQuickProcessAsync);
            task1.Start();

            task.Wait();
            task1.Wait();
            Console.WriteLine("End a program");
            Console.ReadLine();
        }

        private static async void TestProcessAsync()
        {
            Console.WriteLine("Start async process");
            Thread.Sleep(2000);
            Console.WriteLine("End  async process");
        }

        private static async void TestQuickProcessAsync()
        {
            Console.WriteLine("Start quick async process");
            Thread.Sleep(1000);
            Console.WriteLine("End quick async process");
        }
    }
}