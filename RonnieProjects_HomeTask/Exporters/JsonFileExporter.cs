using RonnieProjects_HomeTask.Interfaces;
using System.Text.Json;

namespace RonnieProjects_HomeTask.Exporters
{
    internal class JsonFileExporter : IFileExporter
    {
        public async Task ExportAsync<T>(IEnumerable<T> data, string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(data, options);
            await File.WriteAllTextAsync(filePath, jsonString);
        }
    }
}
