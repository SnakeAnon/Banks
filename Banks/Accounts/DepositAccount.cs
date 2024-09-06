using System.Text.Json;
using Banks.Interfaces;
using Banks.Transactions;

namespace Banks.Accounts;

public class DepositAccount : IAccount
{
    private readonly List<ITransaction> _transactions = new List<ITransaction>();
    private readonly DateTime _dateTime;

    private int _daysCounter;

    public DepositAccount(DateTime dateTime)
    {
        _dateTime = dateTime;
        _daysCounter = 0;
    }

    public decimal Money { get; internal set; }
    public Guid Id { get; } = Guid.NewGuid();

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
        if (_daysCounter % DateTime.DaysInMonth(_dateTime.Year, _dateTime.Month) == 0)
        {
            Money -= money;
            var t = new WithdrawTransaction(money, this);
            _transactions.Add(t);
            return t;
        }
        else
        {
            throw new Exception("Can't withdraw money");
        }
    }

    public ITransaction Transfer(IAccount account, decimal money)
    {
        var t1 = account.WithdrawMoney(money);
        var t2 = PutMoney(money);
        return new TransferTransaction(t2, t1);
    }

    public void DoDailyStuff(decimal percent)
    {
        _daysCounter++;
        Money += percent * Money / 100;
    }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}