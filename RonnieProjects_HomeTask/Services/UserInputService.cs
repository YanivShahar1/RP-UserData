using RonnieProjects_HomeTask.Exporters;
using RonnieProjects_HomeTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask.Services
{
    internal class UserInputService : IUserInputService
    {
        public string GetFolderPath()
        {
            string? folderPath;
            do
            {
                Console.WriteLine("Enter folder path to save the file:");
                folderPath = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid folder path. Please enter a valid existing path.");
                    folderPath = null;
                }

            } while (folderPath == null);

            return folderPath;
        }

        public ExportFormat GetExportFormat()
        {
            ExportFormat exportFormat;
            bool isValid;
            do
            {
                Console.WriteLine("Enter export format (json/csv):");
                var input = Console.ReadLine();

                isValid = Enum.TryParse(input, true, out exportFormat)
                          && Enum.IsDefined(typeof(ExportFormat), exportFormat);

                if (!isValid)
                {
                    Console.WriteLine("Invalid format. Please enter either 'json' or 'csv'.");
                }

            } while (!isValid);

            return exportFormat;
        }
    }
}
