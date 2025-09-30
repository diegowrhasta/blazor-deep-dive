namespace ServerManagement.StateStore;

public class TorontoOnlineServersStore : Observer
{
    private int _numberOfOnlineServers;

    public int GetNumberOfOnlineServers() => _numberOfOnlineServers;

    public void SetNumberOfOnlineServers(int number)
    {
        _numberOfOnlineServers = number;
        base.BroadcastStateChange();
    }
}