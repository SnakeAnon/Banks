using System.Text.Json;
using Banks.Accounts;
using Banks.ForObserver;
using Banks.Interfaces;
using Banks.InternalModels;

namespace Banks.Facades;

public class Bank : IObservable<string>
{
    private readonly List<IObserver<string>> _listeners;

    private readonly Dictionary<Customer, List<IAccount>> _accountDictionary = new ();

    private readonly List<IAccount> _accounts = new ();

    public Bank(string name, Config config, Guid id)
    {
        Name = name;
        Config = config;
        Id = id;
        _listeners = new List<IObserver<string>>();
    }

    public string Name { get; }

    public Guid Id { get; }

    public IReadOnlyCollection<IAccount> Accounts => _accounts;
    public List<Customer> Customers => _accountDictionary.Keys.ToList();
    internal Config Config { get; set; }

    public void RegisterCustomer(Customer customer)
    {
        if (_accountDictionary.ContainsKey(customer))
        {
            throw new Exception("Customer already registered");
        }

        _accountDictionary.Add(customer, new List<IAccount>());
    }

    public void AddAccount(Customer customer, IAccount account)
    {
        if (!_accountDictionary.ContainsKey(customer))
        {
            throw new Exception("Customer is not registered in bank");
        }

        _accountDictionary[customer].Add(account);
        _accounts.Add(account);
    }

    public IDisposable Subscribe(IObserver<string> observer)
    {
        return new Unsubscriber(_listeners, observer);
    }

    public IDisposable Unsubscribe(IObserver<string> observer)
    {
        if (_listeners.Contains(observer))
        {
            _listeners.Remove(observer);
        }

        return new Unsubscriber(_listeners, observer);
    }

    public void Notify(string s)
    {
        foreach (IObserver<string> o in _listeners)
        {
            o.OnNext(s);
        }
    }

    public void DoDailyStuff()
    {
        foreach (IAccount a in _accounts)
        {
            switch (a)
            {
                case CreditAccount:
                    a.DoDailyStuff(Config.CreditPercent);
                    break;
                case DebitAccount:
                    a.DoDailyStuff(Config.DebitPercent);
                    break;
                default:
                    a.DoDailyStuff(Config.DepositPercent);
                    break;
            }
        }
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}