namespace ServerManagement.Models;

public class ServersEfCoreRepository(IDbContextFactory<ServerManagementContext> contextFactory)
    : IServersEfCoreRepository
{
    public async Task AddServerAsync(Server server)
    {
        await using var db = await contextFactory.CreateDbContextAsync();
        db.Servers.Add(server);

        await db.SaveChangesAsync();
    }

    public async Task<List<Server>> GetServersAsync()
    {
        await using var db = await contextFactory.CreateDbContextAsync();
        return await db.Servers.ToListAsync();
    }

    public async Task<List<Server>> GetServersByCityAsync(string city)
    {
        await using var db = await contextFactory.CreateDbContextAsync();

        return await db.Servers
            .Where(x => x.City != null && x.City.ToLower() == city.ToLower())
            .ToListAsync();
    }

    public async Task<Server?> GetServerByIdAsync(int id)
    {
        await using var db = await contextFactory.CreateDbContextAsync();

        return await db.Servers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateServerAsync(int serverId, Server? server)
    {
        if (server is null)
        {
            throw new ArgumentNullException(nameof(server));
        }

        if (serverId != server.Id)
        {
            return;
        }

        await using var db = await contextFactory.CreateDbContextAsync();
        var serverToUpdate = await db.Servers.FindAsync(serverId);

        if (serverToUpdate is null)
        {
            return;
        }

        serverToUpdate.IsOnline = server.IsOnline;
        serverToUpdate.Name = server.Name;
        serverToUpdate.City = server.City;
        await db.SaveChangesAsync();
    }

    public async Task DeleteServerAsync(int serverId)
    {
        await using var db = await contextFactory.CreateDbContextAsync();
        var serverToDelete = await db.Servers.FindAsync(serverId);

        if (serverToDelete is null)
        {
            return;
        }

        db.Servers.Remove(serverToDelete);
        await db.SaveChangesAsync();
    }

    public async Task<List<Server>> SearchServersAsync(string serverFilter)
    {
        await using var db = await contextFactory.CreateDbContextAsync();

        return await db.Servers
            .Where(x => x.Name != null && x.Name.ToLower().StartsWith(serverFilter.ToLower()))
            .ToListAsync();
    }
}