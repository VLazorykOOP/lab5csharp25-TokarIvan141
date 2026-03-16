using System;

namespace Lab5;

public abstract class Client
{
    protected string name;
    protected DateTime serviceDate;

    public Client(string name, DateTime serviceDate)
    {
        this.name = name;
        this.serviceDate = serviceDate;
    }

    public abstract void Show();

    public bool IsMatchDate(DateTime date)
    {
        return serviceDate.Date == date.Date;
    }

    public string GetName() => name;
}