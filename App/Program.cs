using Lib;
using System;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            HttpClientWrapper clienttWrapper = new HttpClientWrapper();

            Console.WriteLine("GetUserAsync");
            string posts = await clienttWrapper.GetUserAsync();
            Console.WriteLine("User string:");
            Console.WriteLine(posts);

            Console.WriteLine();

            Console.WriteLine("GetUserAsyncJson");
            dynamic postsJson = await clienttWrapper.GetUserAsyncJson();
            Console.WriteLine("User json:");
            Console.WriteLine(postsJson.ToString());

            Console.ReadLine();
        }
    }
}