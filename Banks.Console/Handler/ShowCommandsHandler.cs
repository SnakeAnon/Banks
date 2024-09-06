using Banks.Facades;
using Banks.Interfaces;
using Banks.InternalModels;
using Banks.Models;

namespace Banks.Console.Handler;

public class ShowCommandsHandler : IHandler
{
    public ShowCommandsHandler(CentralBank centralBank, TimeProvider timeProvider)
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
                foreach (Bank centralBankBank in CentralBank.Banks)
                {
                    System.Console.WriteLine(centralBankBank.ToString());
                }

                break;

            case "customers":
                foreach (Customer customer in CentralBank.Customers)
                {
                    System.Console.WriteLine(customer.ToString());
                }

                break;
            case "accs":
                foreach (IAccount centralBankAccount in CentralBank.Accounts)
                {
                    System.Console.WriteLine(centralBankAccount.ToString());
                }

                break;
        }
    }
}