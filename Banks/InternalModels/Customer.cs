using System.Text.Json;

namespace Banks.InternalModels;

public class Customer : IObserver<string>
{
    private const int InvalidPassport = -1;
    private const string InvalidAddress = "";

    internal Customer()
    {
    }

    public string Name { get; internal set; }
    public string Surname { get; internal set; }

    public Guid Id { get; internal set; }
    public int Passport { get; internal set; } = InvalidPassport;
    public string Address { get; internal set; } = InvalidAddress;
    public bool IsValid => Passport != InvalidPassport && Address != InvalidAddress;
    internal string Information { get; private set; } = string.Empty;

    public void OnCompleted()
    {
    }

    public void OnError(Exception error)
    {
    }

    public void OnNext(string value)
    {
        Information += value;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}