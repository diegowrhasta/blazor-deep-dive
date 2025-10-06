namespace ServerManagement.Models;

public interface IServersEfCoreRepository
{
    Task AddServerAsync(Server server);
    Task<List<Server>> GetServersAsync();
    Task<List<Server>> GetServersByCityAsync(string city);
    Task<Server?> GetServerByIdAsync(int id);
    Task UpdateServerAsync(int serverId, Server? server);
    Task DeleteServerAsync(int serverId);
    Task<List<Server>> SearchServersAsync(string serverFilter);
}