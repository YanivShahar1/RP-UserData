// Yaniv Shahar
using RonnieProjects_HomeTask.Services;

namespace RonnieProjects_HomeTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Ronnie Projects Home Task - Yaniv Shahar");
            Console.WriteLine("User Data Aggregator:\n");

            var app = new UserDataConsoleApp();
            await app.RunAsync();

        }
    }
}
