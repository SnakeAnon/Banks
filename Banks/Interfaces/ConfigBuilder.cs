using Banks.InternalModels;

namespace Banks.Interfaces;

public class ConfigBuilder
{
    private const decimal InvalidPercent = -1m;
    private decimal _debitPercent = InvalidPercent;
    private decimal _depositPercent = InvalidPercent;
    private decimal _creditPercent = InvalidPercent;
    private decimal _limitForTransactions = InvalidPercent;

    public ConfigBuilder AddDebitPercent(decimal debitPercent)
    {
        _debitPercent = debitPercent;
        return this;
    }

    public ConfigBuilder AddCreditPercent(decimal creditPercent)
    {
        _creditPercent = creditPercent;
        return this;
    }

    public ConfigBuilder AddDepositPercent(decimal depositPercent)
    {
        _depositPercent = depositPercent;
        return this;
    }

    public ConfigBuilder AddSpecialLimit(decimal specialLimit)
    {
        _limitForTransactions = specialLimit;
        return this;
    }

    public Config Build()
    {
        if (_debitPercent == InvalidPercent
            || _creditPercent == InvalidPercent
            || _depositPercent == InvalidPercent
            || _limitForTransactions == InvalidPercent)
        {
            throw new Exception("Can't build config");
        }

        return new Config(_debitPercent, _depositPercent, _creditPercent, _limitForTransactions);
    }
}