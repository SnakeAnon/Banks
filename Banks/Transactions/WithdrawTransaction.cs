using Banks.Interfaces;

namespace Banks.Transactions;

public class WithdrawTransaction : ITransaction
{
    public WithdrawTransaction(decimal money, IAccount account)
    {
        Money = money;
        Account = account;
    }

    public decimal Money { get; }
    public IAccount Account { get; }

    public void Undo()
    {
        Account.PutMoney(Money);
    }
}