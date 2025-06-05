using Microsoft.Extensions.Configuration;
using RonnieProjects_HomeTask.Entities;
using RonnieProjects_HomeTask.Exporters;
using RonnieProjects_HomeTask.Interfaces;
using RonnieProjects_HomeTask.Providers;
using RonnieProjects_HomeTask.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask
{
    internal class UserDataConsoleApp
    {
        private readonly IUserInputService _inputService;
        private readonly UserDataService _userService;
        private readonly HttpClient _httpClient;

        public UserDataConsoleApp()
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            _httpClient = new HttpClient();

            var userProviders = new List<IUserDataProvider>
            {
                new RandomUserProvider(_httpClient),
                new JsonPlaceholderUserProvider(_httpClient),
                new DummyJsonUserProvider(_httpClient),
                new ReqResUserProvider(_httpClient, configuration) // Later should implement DI better
            };

            _userService = new UserDataService(userProviders);
            _inputService = new UserInputService();
        }

        public async Task RunAsync()
        {
            var folderPath = _inputService.GetFolderPath();
            var exportFormat = _inputService.GetExportFormat();

            var users = await _userService.GetAllUsersAsync();
            Console.WriteLine($"Total users fetched: {users.Count()}");

            IFileExporter exporter = exportFormat switch
            {
                ExportFormat.Json => new JsonFileExporter(),
                ExportFormat.Csv => new CsvFileExporter(),
                _ => throw new NotImplementedException()
            };

            var fileName = $"Users_{DateTime.Now:yyyyMMddHHmmss}.{exportFormat.ToString().ToLower()}";
            var filePath = Path.Combine(folderPath, fileName);

            await exporter.ExportAsync(users, filePath);
            Console.WriteLine($"\nUsers exported successfully to:\n{filePath}");
        }
    }
}
