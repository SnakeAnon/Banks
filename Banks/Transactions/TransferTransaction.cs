using Banks.Interfaces;

namespace Banks.Transactions;

public class TransferTransaction : ITransaction
{
    public TransferTransaction(ITransaction put, ITransaction withdraw)
    {
        if (put is PutTransaction && withdraw is WithdrawTransaction)
        {
            Put = put;
            Withdraw = withdraw;
        }
        else
        {
            throw new Exception("Wrong init types");
        }
    }

    public ITransaction Put { get; }
    public ITransaction Withdraw { get; }
    public void Undo()
    {
        Put.Undo();
        Withdraw.Undo();
    }
}