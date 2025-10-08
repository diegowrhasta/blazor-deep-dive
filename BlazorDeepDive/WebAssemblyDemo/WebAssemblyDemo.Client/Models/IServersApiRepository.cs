namespace WebAssemblyDemo.Client.Models;

public interface IServersApiRepository
{
    Task<List<Server>> GetServersAsync();
    Task<Server?> GetServerByIdAsync(int serverId);
    Task DeleteServerAsync(int serverId);
    Task AddServerAsync(Server server);
    Task UpdateServerAsync(Server server, int serverId);
}