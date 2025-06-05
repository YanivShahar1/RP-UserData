using RonnieProjects_HomeTask.Entities;
using RonnieProjects_HomeTask.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json.Serialization;

namespace RonnieProjects_HomeTask.Providers
{
    internal class ReqResUserProvider : IUserDataProvider
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://reqres.in/api/users";

        public ReqResUserProvider(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            var apiKey = configuration["ReqResApi:ApiKey"];

            _httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        }

        public async Task<IEnumerable<User>> GetUsersDataAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<ReqResResponse>(ApiUrl);
            var rawResponse = await _httpClient.GetStringAsync(ApiUrl);
            Console.WriteLine("-----ReqResUserProvider------");
            Console.WriteLine(rawResponse);

            return response?.Data.Select(u => new User
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                SourceId = ApiUrl
            }) ?? Enumerable.Empty<User>();
        }

        private class ReqResResponse
        {
            public List<ReqResUser> Data { get; set; }
        }

        private class ReqResUser
        {
            public int Id { get; set; }
            public string Email { get; set; }

            [JsonPropertyName("first_name")]
            public string FirstName { get; set; }

            [JsonPropertyName("last_name")]
            public string LastName { get; set; }
        }
    }
}
