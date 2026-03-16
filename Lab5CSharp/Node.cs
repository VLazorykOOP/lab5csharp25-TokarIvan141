using System;

namespace Lab5;

public class Node : Detail
{
    protected int partCount;

    public Node() : base()
    {
        partCount = 0;
        Console.WriteLine("Constructor: Node (без параметрів)");
    }

    public Node(string name, int count) : base(name)
    {
        this.partCount = count;
        Console.WriteLine("Constructor: Node (ім'я + кількість)");
    }

    public Node(string name, string material, int count) : base(name, material)
    {
        this.partCount = count;
        Console.WriteLine("Constructor: Node (повний)");
    }

    ~Node()
    {
        Console.WriteLine($"Destructor: Node ({name})");
    }

    public override void Show()
    {
        Console.WriteLine($"Вузол: {name}, Матеріал: {material}, Кількість деталей: {partCount}");
    }
}