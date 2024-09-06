using System.Text.Json;

namespace Banks.InternalModels;

public class Config
{
    internal Config(decimal debitPercent, decimal depositPercent, decimal creditPercent, decimal limitForTransactions)
    {
        DebitPercent = debitPercent;
        DepositPercent = depositPercent;
        CreditPercent = creditPercent;
        LimitForTransactions = limitForTransactions;
    }

    public decimal DebitPercent { get; }
    public decimal DepositPercent { get; }
    public decimal CreditPercent { get; }
    public decimal LimitForTransactions { get; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}