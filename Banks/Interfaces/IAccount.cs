using Banks.Transactions;

namespace Banks.Interfaces;

public interface IAccount
{
    Guid Id { get; }
    DateTime GetCreationDate();

    decimal GetMoney();
    ITransaction PutMoney(decimal money);
    ITransaction WithdrawMoney(decimal money);
    ITransaction Transfer(IAccount account, decimal money);
    void DoDailyStuff(decimal percent);
}