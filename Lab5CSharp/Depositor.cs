using System;

namespace Lab5;

public class Depositor : Client
{
    private double amount;
    private double interestRate;

    public Depositor(string lastName, DateTime openDate, double amount, double rate)
        : base(lastName, openDate)
    {
        this.amount = amount;
        this.interestRate = rate;
    }

    public override void Show()
    {
        Console.WriteLine($"Вкладник: {name} | Дата: {serviceDate.ToShortDateString()} | Сума: {amount} | Відсоток: {interestRate}%");
    }
}