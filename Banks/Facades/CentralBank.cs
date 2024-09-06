using Banks.Interfaces;
using Banks.InternalModels;

namespace Banks.Facades;

public class CentralBank
{
    private readonly List<Bank> _banks;

    public CentralBank()
    {
        _banks = new List<Bank>();
    }

    public IReadOnlyCollection<Bank> Banks => _banks;

    public IReadOnlyCollection<Customer> Customers => _banks.SelectMany(x => x.Customers).ToList();
    public IReadOnlyCollection<IAccount> Accounts => _banks.SelectMany(x => x.Accounts).ToList();

    public Bank CreateBank(string name, Config config)
    {
        var bank = new Bank(name, config, Guid.NewGuid());
        _banks.Add(bank);
        return bank;
    }

    public void ChangeBankConfig(Bank bank, Config config)
    {
        bank.Config = config;
        bank.Notify("new config. check difference\n");
    }

    public Bank FindBank(Guid id)
    {
        return Banks.FirstOrDefault(x => x.Id.Equals(id));
    }

    public IAccount FindAccount(Guid id)
    {
        return Accounts.FirstOrDefault(x => x.Id.Equals(id));
    }

    public Customer FindCustomer(Guid id)
    {
        return Customers.FirstOrDefault(x => x.Id.Equals(id));
    }

    internal void DoDailyNotify()
    {
        foreach (Bank bank in _banks)
        {
            bank.DoDailyStuff();
        }
    }
}