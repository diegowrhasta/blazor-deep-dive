namespace WebAssemblyDemo.Client.Models;

public interface IServersApiRepository
{
    Task<List<Server>> GetServersAsync();
    Task DeleteServerAsync(int serverId);
    Task AddServerAsync(Server server);
}