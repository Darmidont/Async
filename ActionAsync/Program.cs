using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActionAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(AsyncTask);
            task.Start();
            //task.Wait();
            Console.WriteLine("End a program");
            Console.ReadLine();
        }

        public static async void AsyncTask()
        {
            Console.WriteLine("Moved to AsyncTask");
            Task<int> task = StartParametrisedAsync(5);
            Console.WriteLine("Prepare to start");
            //task.Start();
            Console.WriteLine(await task);
            Console.WriteLine("End async task");
        }


        public static async Task<int> StartParametrisedAsync(int nval)
        {
            Console.WriteLine("Get param {0}", nval);
            //Console.WriteLine("Start quick async process");
            //Thread.Sleep(2000);
            await Task.Delay(2000);
            Console.WriteLine("End quick async process");
            return nval + 1;
        }

    }
}
