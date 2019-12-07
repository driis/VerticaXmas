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
            
            var response = await Elastic.GetMovements(id);
            Console.WriteLine("Movements:\n");
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
            
            Console.WriteLine("Sending position ...");
            var pos = await apiClient.SubmitPosition(response);
            Console.WriteLine($"Got position:\n{pos}");
        }
    }
}
