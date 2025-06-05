using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask.Interfaces
{
    public interface IFileExporter
    {
        Task ExportAsync<T>(IEnumerable<T> data, string filePath);
    }
}
