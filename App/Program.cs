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
            string user = await clienttWrapper.GetUserAsync();
            Console.WriteLine("User string:");
            Console.WriteLine(user);

            Console.WriteLine();

            Console.WriteLine("GetUserAsyncJson");
            dynamic userJson = await clienttWrapper.GetUserAsyncJson();
            Console.WriteLine("User json:");
            Console.WriteLine(userJson.ToString());

            Console.ReadLine();
        }
    }
}