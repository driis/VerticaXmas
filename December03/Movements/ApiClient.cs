using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Dec03
{
    public class ApiClient
    {
        private static readonly HttpClient Client = new HttpClient() {BaseAddress = new Uri("https://vertica-xmas2019.azurewebsites.net")};

        public async Task<Guid> Participate()
        {
            var response = await Client.PostAsJsonAsync("api/participate",
                new {fullName = "Dennis Riis", emailAddress = "dr@driis.dk", subscribeToNewsletter = true});

            dynamic data = await response.Content.ReadAsAsync<JObject>();
            Guid id = data.id;
            return id;
        }

        public async Task SubmitPosition(SantaPath path)
        {
            var position = path.CalculateNewPosition();

            var result = new {id = path.Id, position = new {lat = position.Lat, lon = position.Lon}};

            var response = await Client.PostAsJsonAsync("api/santarescue", result);
            Console.WriteLine("api/santarescue - got result:");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            response.EnsureSuccessStatusCode();
        }
    }
}