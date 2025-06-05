// Yaniv Shahar
using RonnieProjects_HomeTask.Services;

namespace RonnieProjects_HomeTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ronnie Projects Home Task - Yaniv Shahar");
            Console.WriteLine("User Data Aggregator:");

            var inputService = new UserInputService();

            var folderPath = inputService.GetFolderPath();
            var exportFormat = inputService.GetExportFormat();

            Console.WriteLine();
            Console.WriteLine($"Folder Path Selected: {folderPath}");
            Console.WriteLine($"Export Format Selected: {exportFormat}");

        }
    }
}
