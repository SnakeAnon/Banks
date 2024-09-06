using Banks.Interfaces;

namespace Banks.Transactions;

public class PutTransaction : ITransaction
{
    public PutTransaction(decimal money, IAccount account)
    {
        Money = money;
        Account = account;
    }

    public decimal Money { get; }
    public IAccount Account { get; }

    public void Undo()
    {
        Account.WithdrawMoney(Money);
    }
}