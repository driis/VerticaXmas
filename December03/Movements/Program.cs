using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elasticsearch.Net;
using Nest;
using Nest.JsonNetSerializer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Dec03
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var apiClient = new ApiClient();
            var id = await apiClient.Participate();
            Console.WriteLine($"Got participant id {id}");
            var response = await GetMovementsFromElastic(id);
            Console.WriteLine("Movements:\n");
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
            Console.WriteLine("Sending position ...");
            await apiClient.SubmitPosition(response);
        }

        private static async Task<SantaPath> GetMovementsFromElastic(Guid id)
        {
            var connPool = new CloudConnectionPool(
                "xmas2019:ZXUtY2VudHJhbC0xLmF3cy5jbG91ZC5lcy5pbyRlZWJjNmYyNzcxM2Q0NTE5OTcwZDc1Yzg2MDUwZTM2MyQyNDFmMzQ3OWNkNzg0ZTUyOTRkODk5OTViMjg0MjAyYg==",
                new BasicAuthenticationCredentials("Participant", "fr5ZS6NT2gQE1VL0hLZmB1X8HhGAW4"));
            var cli = new ElasticClient(new ConnectionSettings(connPool, JsonNetSerializer.Default));

            var response =
                await cli.GetAsync<SantaPath>(new GetRequest("santa-trackings", id.ToString()), CancellationToken.None);
            return response.Source;
        }
    }
}
