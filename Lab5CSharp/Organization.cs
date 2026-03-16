using System;

namespace Lab5;

public class Organization : Client
{
    private string accountNumber;
    private double balance;

    public Organization(string orgName, DateTime openDate, string accNum, double balance)
        : base(orgName, openDate)
    {
        this.accountNumber = accNum;
        this.balance = balance;
    }

    public override void Show()
    {
        Console.WriteLine($"Організація: {name} | Дата: {serviceDate.ToShortDateString()} | Рахунок: {accountNumber} | Баланс: {balance}");
    }
}