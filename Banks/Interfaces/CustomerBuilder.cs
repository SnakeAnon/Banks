using Banks.InternalModels;

namespace Banks.Interfaces;

public class CustomerBuilder
{
    private const int InvalidPassport = -1;
    private const string InvalidAddress = "";
    private string _name;
    private string _surname;
    private string _address;
    private int _passport;

    public CustomerBuilder SetName(string name)
    {
        _name = name;
        return this;
    }

    public CustomerBuilder SetSurname(string surname)
    {
        _surname = surname;
        return this;
    }

    public CustomerBuilder SetAddress(string address)
    {
        _address = address;
        return this;
    }

    public CustomerBuilder SetPassport(int passport)
    {
        _passport = passport;
        return this;
    }

    public Customer Build()
    {
        var customer = new Customer
        {
            Name = _name,
            Surname = _surname,
            Id = Guid.NewGuid(),
        };

        if (_address != InvalidAddress)
        {
            customer.Address = _address;
        }

        if (_passport != InvalidPassport)
        {
            customer.Passport = _passport;
        }

        return customer;
    }
}