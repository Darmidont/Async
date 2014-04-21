using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMsdnSample
{
    class Program
    {
        static void Main(string[] args)
        {
            //var program = new Program();

            // default buffer size is 65,536.
            Task task = new Task(TestTask);
            task.Start();
            task.Wait();
            Console.WriteLine("End a program");
            Console.ReadLine();
        }

        static async void TestTask()
        {
            HttpClient client =
                new HttpClient() { MaxResponseContentBufferSize = 1000000 };

            // Create and start the tasks. As each task finishes, DisplayResults 
            // displays its length.
            Task<int> download1 =
                ProcessURLAsync("http://msdn.microsoft.com", client);
            Task<int> download2 =
                ProcessURLAsync("http://msdn.microsoft.com/en-us/library/hh156528(VS.110).aspx", client);
            Task<int> download3 =
                ProcessURLAsync("http://msdn.microsoft.com/en-us/library/67w7t67f.aspx", client);

            // Await each task.
            int length1 = await download1;
            int length2 = await download2;
            int length3 = await download3;

            int total = length1 + length2 + length3;
        }

        public string ResultProperty { get; set; }

        static async Task<int> ProcessURLAsync(string url, HttpClient client)
        {
            Console.WriteLine("start get bytes by url {0}", url);
            var byteArray = await client.GetByteArrayAsync(url);
            Console.WriteLine("end get bytes by url {0}", url);
            //DisplayResults(url, byteArray);
            return byteArray.Length;
        }

        private static void DisplayResults(string url, byte[] content)
        {
            // Display the length of each website. The string format 
            // is designed to be used with a monospaced font, such as
            // Lucida Console or Global Monospace.
            var bytes = content.Length;
            // Strip off the "http://".
            var displayURL = url.Replace("http://", "");
            //ResultProperty += string.Format("\n{0,-58} {1,8}", displayURL, bytes);
            //resultsTextBox.Text += string.Format("\n{0,-58} {1,8}", displayURL, bytes);
        }
    }
}
