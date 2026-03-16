using System;

namespace Lab5;

public class Detail
{
    protected string name;
    protected string material;

    public Detail()
    {
        name = "Невідомо";
        material = "Невідомо";
        Console.WriteLine("Constructor: Detail (без параметрів)");
    }

    public Detail(string name)
    {
        this.name = name;
        this.material = "Сталь";
        Console.WriteLine($"Constructor: Detail (ім'я: {name})");
    }

    public Detail(string name, string material)
    {
        this.name = name;
        this.material = material;
        Console.WriteLine($"Constructor: Detail (повний)");
    }

    ~Detail()
    {
        Console.WriteLine($"Destructor: Detail ({name})");
    }

    public virtual void Show()
    {
        Console.WriteLine($"Деталь: {name}, Матеріал: {material}");
    }
}