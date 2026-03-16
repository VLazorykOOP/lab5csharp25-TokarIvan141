using System;

namespace Lab5;

public class Mechanism : Node
{
    protected string type;

    public Mechanism() : base()
    {
        type = "Загальний";
        Console.WriteLine("Constructor: Mechanism (без параметрів)");
    }

    public Mechanism(string name, string type) : base(name, 10)
    {
        this.type = type;
        Console.WriteLine("Constructor: Mechanism (ім'я + тип)");
    }

    public Mechanism(string name, string material, int count, string type) : base(name, material, count)
    {
        this.type = type;
        Console.WriteLine("Constructor: Mechanism (повний)");
    }

    ~Mechanism()
    {
        Console.WriteLine($"Destructor: Mechanism ({name})");
    }

    public override void Show()
    {
        Console.WriteLine($"Механізм: {name}, Тип: {type}, Деталей: {partCount}");
    }
}