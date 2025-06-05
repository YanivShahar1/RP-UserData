using RonnieProjects_HomeTask.DTOs;
using RonnieProjects_HomeTask.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask.Interfaces
{
    internal interface IUserDataService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
    }
}
