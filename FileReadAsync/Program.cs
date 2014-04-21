using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace FileReadAsync
{
    class Program
    {
        #region const

        private const string PathToDirectory = @"G:\Distrib\";
        #endregion
        static void Main(string[] args)
        {
            var task = new Task(GetDirectory);
            task.Start();
            task.Wait();
            Console.WriteLine("End a program");
            Console.ReadLine();
        }

        static async void GetDirectory()
        {
            var directoryInfo = new DirectoryInfo(PathToDirectory);
            var files = directoryInfo.GetFiles();
            
            if (!files.Any())
            {
                return;
            }

            var taskList = new List<Task>();
            for (int i = 0; i < files.Count(); i++)
            {
                var filePath = files[i].FullName;
                //var dd = string.Empty;
             //   Task task = ReadAllFile(filePath);
              //  taskList.Add(task);
                //await ReadAllFile(filePath);
                //var task = new Task(ReadAllFile(filePath));
                //await ReadAllFile(filePath);
                var task = ReadAllFile(filePath);
                taskList.Add(task);
            }

            await Task.WhenAll(taskList);
            foreach (var task in taskList)
            {
                Console.WriteLine();
            }

            Console.WriteLine("End GetDirectory task");
        }

        static  async Task<int> ReadAllFile(string filePath)
        {
            Console.WriteLine("Start get all bytes file = {0}", filePath);
            //await Task.Delay(100);
            //Thread.Sleep(1000);
            var fileBytes = File.ReadAllLines(filePath);
            //Console.WriteLine("End get all bytes file = {0}. Bytes = {1}", filePath, fileBytes.Length);
            return fileBytes.Length;
        }
    }
}
