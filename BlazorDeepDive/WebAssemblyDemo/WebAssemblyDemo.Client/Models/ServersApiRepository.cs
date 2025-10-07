using System.Net.Http.Json;

namespace WebAssemblyDemo.Client.Models;

public class ServersApiRepository(IHttpClientFactory clientFactory) : IServersApiRepository
{
    private const string API_NAME = "ServersApi";

    public async Task<List<Server>> GetServersAsync()
    {
        var client = clientFactory.CreateClient(API_NAME);

        var response = await client.GetFromJsonAsync<List<Server>>("/servers.json");

        return response ?? [];
    }

    public async Task DeleteServerAsync(int serverId)
    {
        var client = clientFactory.CreateClient(API_NAME);

        var response = await client.DeleteAsync("/servers.json");
        response.EnsureSuccessStatusCode();
    }

    public async Task AddServerAsync(Server server)
    {
        var client = clientFactory.CreateClient(API_NAME);

        server.ServerId = await GetNextServerId();
        var response = await client.PutAsJsonAsync($"/servers/{server.ServerId}.json", server);
        response.EnsureSuccessStatusCode();
        
        return;

        async Task<int> GetNextServerId()
        {
            var servers = (await GetServersAsync())
                .Where(x => x is not null)
                .ToList();

            if (servers.Count == 0)
            {
                return 1;
            }
            
            return servers.Max(s => s.ServerId) + 1;
        }
    }
}