using Banks.Facades;
using Banks.Models;

namespace Banks.Console.Handler;

public interface IHandler
{
    public CentralBank CentralBank { get; }

    public TimeProvider TimeProvider { get; }

    public abstract void Execute();
}