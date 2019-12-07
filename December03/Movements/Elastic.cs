using System;
using System.Threading;
using System.Threading.Tasks;
using Dec03;
using Elasticsearch.Net;
using Nest;
using Nest.JsonNetSerializer;

internal static class Elastic
{
    public static async Task<SantaPath> GetMovements(Guid id)
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