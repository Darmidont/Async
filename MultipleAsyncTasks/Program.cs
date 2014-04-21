using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultipleAsyncTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(ExecuteTasks);
            task.Start();
            task.Wait();
            Console.WriteLine("End a program");
            Console.ReadLine();
        }

        public static async void ExecuteTasks()
        {
            var tasks = new List<Task>();
            Task<int> task1 = GetAsyncTask(5);
            Task<int> task2 = GetAsyncTask(2);
            Task<int> task3 = GetAsyncTask(1);
            Task<int> task4 = GetAsyncTask(4);

            tasks.Add(task1);
            tasks.Add(task2);
            tasks.Add(task3);
            tasks.Add(task4);
            await Task.WhenAll(tasks);
        }

        public static async Task<int> GetAsyncTask(int value)
        {
            Console.WriteLine("Get param {0} as value", value);
            var result = value*1000;
            await Task.Delay(result);
            Console.WriteLine("returning ");
            return result;
        }
    }
}
