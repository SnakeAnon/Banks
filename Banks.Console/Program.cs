using Banks.Console.Handler;
using Banks.Facades;
using Banks.Models;
using static System.Console;

namespace Banks.Console;

internal static class BankConsole
{
    public static void Main()
    {
        var centralBank = new CentralBank();
        var provider = new TimeProvider(centralBank);
        string cmd;
        while (true)
        {
            cmd = ReadLine();
            switch (cmd)
            {
                case "create":
                    new CreateCommandsHandler(centralBank, provider).Execute();
                    break;
                case "show":
                    new ShowCommandsHandler(centralBank, provider).Execute();
                    break;
                case "time":
                    new TimeCommandsHandler(centralBank, provider).Execute();
                    break;
                case "exit":
                    return;
            }
        }
    }
}