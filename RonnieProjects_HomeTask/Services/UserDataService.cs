using RonnieProjects_HomeTask.DTOs;
using RonnieProjects_HomeTask.Entities;
using RonnieProjects_HomeTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask.Services
{
    internal class UserDataService : IUserDataService
    {
        private readonly IEnumerable<IUserDataProvider> _userProviders;

        public UserDataService(IEnumerable<IUserDataProvider> userProviders)
        {
            _userProviders = userProviders;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var fetchTasks = _userProviders.Select(p => p.GetUsersDataAsync());
            var results = await Task.WhenAll(fetchTasks);
            var allUsers = results.SelectMany(users => users);
            return allUsers;
        }
    }
}
