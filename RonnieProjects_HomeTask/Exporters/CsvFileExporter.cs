using RonnieProjects_HomeTask.Interfaces;
using System.Text;
using System.Reflection;

namespace RonnieProjects_HomeTask.Exporters
{
    internal class CsvFileExporter : IFileExporter
    {
        public async Task ExportAsync<T>(IEnumerable<T> data, string filePath)
        {
            if (data == null || !data.Any())
                throw new ArgumentException("No data to export.");

            var stringBuilder = new StringBuilder();

            // Write header
            var properties = typeof(T).GetProperties();
            stringBuilder.AppendLine(string.Join(",", properties.Select(p => p.Name)));

            // Write rows
            foreach (var item in data)
            {
                var values = properties.Select(p => p.GetValue(item)?.ToString()?.Replace(",", " ") ?? string.Empty);
                stringBuilder.AppendLine(string.Join(",", values));
            }

            await File.WriteAllTextAsync(filePath, stringBuilder.ToString());
        }
    }
}
