using RonnieProjects_HomeTask.DTOs;
using RonnieProjects_HomeTask.Entities;
using RonnieProjects_HomeTask.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace RonnieProjects_HomeTask.Providers
{
    internal class RandomUserProvider : IUserDataProvider
    {
        private const string ApiUrl = "https://randomuser.me/api/?results=500";

        private readonly HttpClient _httpClient;

        public RandomUserProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<User>> GetUsersDataAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<RandomUserResponse>(ApiUrl);

            return response?.Results.Select(r => new User
            {
                FirstName = r.Name.First,
                LastName = r.Name.Last,
                Email = r.Email,
                SourceId = ApiUrl
            }) ?? Enumerable.Empty<User>();
        }

        private class RandomUserResponse
        {
            public List<RandomUser> Results { get; set; } = new List<RandomUser>();
        }

        private class RandomUser
        {
            public RandomUserName Name { get; set; }
            public string Email { get; set; } = String.Empty;
        }

        private class RandomUserName
        {
            public string First { get; set; } = String.Empty;
            public string Last { get; set; } = String.Empty;
        }

    }
}
