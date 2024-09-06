using Banks.Accounts;
using Banks.Facades;
using Banks.Interfaces;
using Banks.InternalModels;
using Banks.Models;

namespace Banks.Console.Handler;

public class CreateCommandsHandler : IHandler
{
    public CreateCommandsHandler(CentralBank centralBank, TimeProvider timeProvider)
    {
        CentralBank = centralBank;
        TimeProvider = timeProvider;
    }

    public CentralBank CentralBank { get; }

    public TimeProvider TimeProvider { get; }

    public void Execute()
    {
        string cmd = System.Console.ReadLine();

        switch (cmd)
        {
            case "bank":
                CentralBank.CreateBank(
                    System.Console.ReadLine(),
                    new ConfigBuilder()
                        .AddCreditPercent(Convert.ToDecimal(System.Console.ReadLine()))
                        .AddDebitPercent(Convert.ToDecimal(System.Console.ReadLine()))
                        .AddDepositPercent(Convert.ToDecimal(System.Console.ReadLine()))
                        .AddSpecialLimit(Convert.ToDecimal(System.Console.ReadLine()))
                        .Build());

                break;

            case "person":
                Bank bank = CentralBank.FindBank(Guid.Parse(System.Console.ReadLine()));

                bank.RegisterCustomer(new CustomerBuilder()
                    .SetAddress(System.Console.ReadLine())
                    .SetName(System.Console.ReadLine())
                    .SetPassport(Convert.ToInt32(System.Console.ReadLine()))
                    .SetSurname(System.Console.ReadLine())
                    .Build());
                break;

            case "account":
                Bank bank1 = CentralBank.FindBank(Guid.Parse(System.Console.ReadLine()));
                Customer customer = CentralBank.FindCustomer(Guid.Parse(System.Console.ReadLine()));
                switch (System.Console.ReadLine())
                {
                    case "debit":
                        bank1.AddAccount(customer, new DebitAccount(TimeProvider.Date));
                        break;
                    case "credit":
                        bank1.AddAccount(customer, new CreditAccount(TimeProvider.Date));
                        break;
                    case "deposit":
                        bank1.AddAccount(customer, new DepositAccount(TimeProvider.Date));
                        break;
                }

                break;
            case "replenishment":
                IAccount account1 = CentralBank.FindAccount(Guid.Parse(System.Console.ReadLine()));
                account1.PutMoney(Convert.ToDecimal(System.Console.ReadLine()));
                break;
            case "withdraw":
                IAccount account2 = CentralBank.FindAccount(Guid.Parse(System.Console.ReadLine()));
                account2.WithdrawMoney(Convert.ToDecimal(System.Console.ReadLine()));
                break;
            case "transfer":
                IAccount account3 = CentralBank.FindAccount(Guid.Parse(System.Console.ReadLine()));
                IAccount account4 = CentralBank.FindAccount(Guid.Parse(System.Console.ReadLine()));

                account3.Transfer(account4, Convert.ToDecimal(System.Console.ReadLine()));
                break;
        }
    }
}