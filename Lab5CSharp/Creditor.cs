using System;

namespace Lab5;

public class Creditor : Client
{
    private double loanAmount;
    private double interestRate;
    private double remainingDebt;

    public Creditor(string lastName, DateTime issueDate, double amount, double rate, double debt)
        : base(lastName, issueDate)
    {
        this.loanAmount = amount;
        this.interestRate = rate;
        this.remainingDebt = debt;
    }

    public override void Show()
    {
        Console.WriteLine($"Кредитор: {name} | Дата: {serviceDate.ToShortDateString()} | Кредит: {loanAmount} | Борг: {remainingDebt}");
    }
}