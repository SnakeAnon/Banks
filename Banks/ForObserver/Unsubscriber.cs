namespace Banks.ForObserver;
public class Unsubscriber : IDisposable
{
    private readonly List<IObserver<string>> _observers;
    private readonly IObserver<string> _observer;

    public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
    {
        _observers = observers;
        _observer = observer;
    }

    public void Dispose()
    {
        if (_observer != null && _observers.Contains(_observer))
        {
            _observers.Remove(_observer);
        }
    }
}