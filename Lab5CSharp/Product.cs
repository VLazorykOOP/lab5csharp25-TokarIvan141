using System;

namespace Lab5;

public class Product : Mechanism
{
    protected double price;

    public Product() : base()
    {
        price = 0;
        Console.WriteLine("Constructor: Product (без параметрів)");
    }

    public Product(string name, double price) : base(name, "Побутовий")
    {
        this.price = price;
        Console.WriteLine("Constructor: Product (ім'я + ціна)");
    }

    public Product(string name, string material, int count, string type, double price)
        : base(name, material, count, type)
    {
        this.price = price;
        Console.WriteLine("Constructor: Product (повний)");
    }

    ~Product()
    {
        Console.WriteLine($"Destructor: Product ({name})");
    }

    public override void Show()
    {
        Console.WriteLine($"Виріб: {name}, Ціна: {price}, Тип: {type}");
    }
}