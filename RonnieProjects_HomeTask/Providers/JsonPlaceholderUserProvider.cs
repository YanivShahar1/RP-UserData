using RonnieProjects_HomeTask.Entities;
using RonnieProjects_HomeTask.Interfaces;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using RonnieProjects_HomeTask.DTOs;

namespace RonnieProjects_HomeTask.Providers
{
    internal class JsonPlaceholderUserProvider : IUserDataProvider
    {
        private const string ApiUrl = "https://jsonplaceholder.typicode.com/users";
        private readonly HttpClient _httpClient;

        public JsonPlaceholderUserProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<User>> GetUsersDataAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<JsonPlaceholderUser>>(ApiUrl);

            return response?.Select(u => new User
            {
                FirstName = u.Name.Split(' ').First(),
                LastName = u.Name.Split(' ').Last(),
                Email = u.Email,
                SourceId = ApiUrl
            }) ?? Enumerable.Empty<User>();
        }

        private class JsonPlaceholderUser
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
        }
    }
}
