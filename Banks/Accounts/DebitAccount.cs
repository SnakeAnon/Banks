using System.Text.Json;
using Banks.Interfaces;
using Banks.Transactions;

namespace Banks.Accounts;

public class DebitAccount : IAccount
{
    private readonly List<ITransaction> _transactions = new List<ITransaction>();
    private readonly DateTime _dateTime;

    public DebitAccount(DateTime dateTime)
    {
        _dateTime = dateTime;
    }

    public Guid Id { get; } = Guid.NewGuid();

    public decimal Money { get; internal set; }

    public DateTime GetCreationDate()
    {
        return _dateTime;
    }

    public decimal GetMoney()
    {
        return Money;
    }

    public ITransaction PutMoney(decimal money)
    {
        Money += money;
        var t = new PutTransaction(money, this);
        _transactions.Add(t);
        return t;
    }

    public ITransaction WithdrawMoney(decimal money)
    {
        if (Money - money < 0)
        {
            throw new Exception("can't do this operation");
        }

        Money -= money;
        var t = new WithdrawTransaction(money, this);
        _transactions.Add(t);
        return t;
    }

    public ITransaction Transfer(IAccount account, decimal money)
    {
        var t1 = account.WithdrawMoney(money);
        var t2 = PutMoney(money);
        return new TransferTransaction(t2, t1);
    }

    public void DoDailyStuff(decimal percent)
    {
        Money += percent * Money / 100;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}