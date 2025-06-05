using RonnieProjects_HomeTask.Entities;
using RonnieProjects_HomeTask.Interfaces;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RonnieProjects_HomeTask.Providers
{
    internal class DummyJsonUserProvider : IUserDataProvider
    {
        private const string ApiUrl = "https://dummyjson.com/users";

        private readonly HttpClient _httpClient;

        public DummyJsonUserProvider(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<User>> GetUsersDataAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<DummyJsonResponse>(ApiUrl);

            return response?.Users.Select(u => new User
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                SourceId = ApiUrl
            }) ?? Enumerable.Empty<User>();
        }

        private class DummyJsonResponse
        {
            public List<DummyJsonUser> Users { get; set; } = new List<DummyJsonUser> { };
        }

        private class DummyJsonUser
        {
            public int Id { get; set; }
            public string FirstName { get; set; } = String.Empty;
            public string LastName { get; set; } = String.Empty;
            public string Email { get; set; } = String.Empty;
        }
    }
}
