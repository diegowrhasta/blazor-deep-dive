namespace ServerManagement.StateStore;

public class Observer
{
    protected Action? _listeners { get; set; }

    public void AddStateChangeListeners(Action? listener)
    {
        _listeners += listener;
    }

    public void RemoveStateChangeListeners(Action? listener)
    {
        if (listener is not null)
        {
            _listeners -= listener;
        }
    }

    public void BroadcastStateChange()
    {
        _listeners?.Invoke();
    }
}