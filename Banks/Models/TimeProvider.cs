using Banks.Facades;

namespace Banks.Models;

public class TimeProvider
{
    private readonly CentralBank _centralBank;
    public TimeProvider(CentralBank centralBank)
    {
        Date = DateTime.Today;
        _centralBank = centralBank;
    }

    public DateTime Date { get; internal set; }

    public void AddDays(int days)
    {
        for (int i = 0; i < days; i++)
        {
            _centralBank.DoDailyNotify();
        }

        Date += new TimeSpan(days, 0, 0, 0);
    }

    public void AddMonths(int months)
    {
        for (int i = 0; i < months * DateTime.DaysInMonth(Date.Year, Date.Month); i++)
        {
            _centralBank.DoDailyNotify();
        }

        Date += new TimeSpan(months * DateTime.DaysInMonth(Date.Year, Date.Month), 0, 0, 0);
    }

    public void AddYears(int years)
    {
        for (int i = 0; i < years * (DateTime.IsLeapYear(Date.Year) ? 366 : 365); i++)
        {
            _centralBank.DoDailyNotify();
        }

        Date += new TimeSpan(years * (DateTime.IsLeapYear(Date.Year) ? 366 : 365), 0, 0, 0);
    }
}