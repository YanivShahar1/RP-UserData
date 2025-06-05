using RonnieProjects_HomeTask.Exporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask.Interfaces
{
    internal interface IUserInputService
    {
        string GetFolderPath();
        ExportFormat GetExportFormat();
    }
}
