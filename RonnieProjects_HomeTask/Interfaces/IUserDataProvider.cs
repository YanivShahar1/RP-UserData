using RonnieProjects_HomeTask.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask.Interfaces
{
    internal interface IUserDataProvider
    {
        Task<List<UserDto>> GetUsersDataAsync();
    }
}
