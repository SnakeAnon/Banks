using Banks.Facades;
using Banks.Models;

namespace Banks.Console.Handler;

public class TimeCommandsHandler : IHandler
{
    public TimeCommandsHandler(CentralBank centralBank, TimeProvider timeProvider)
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
            case "day":
                TimeProvider.AddDays(Convert.ToInt32(System.Console.ReadLine()));

                break;

            case "month":
                TimeProvider.AddMonths(Convert.ToInt32(System.Console.ReadLine()));

                break;
            case "year":
                TimeProvider.AddYears(Convert.ToInt32(System.Console.ReadLine()));

                break;
        }
    }
}