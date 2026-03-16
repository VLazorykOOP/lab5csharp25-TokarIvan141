using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Lab5;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("1. Порядок конструкторів та деструкторів (Деталь -> Виріб)");
            Console.WriteLine("2. Поліморфізм ієрархії (Show)");
            Console.WriteLine("3. База клієнтів банку (Повна інформація)");
            Console.WriteLine("4. Пошук клієнтів за датою");
            Console.WriteLine("5. Робота зі структурами (Завдання 4: Struct)");
            Console.WriteLine("6. Робота з кортежами (Завдання 4: Tuples)");
            Console.WriteLine("7. Робота із записами (Завдання 4: Records)");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateAndDestroy();
                    break;
                case "2":
                    ShowPolymorphism();
                    break;
                case "3":
                    ShowBankDatabase();
                    break;
                case "4":
                    SearchBankByDate();
                    break;
                case "5":
                    RunStructVariant();
                    break;
                case "6":
                    RunTupleVariant();
                    break;
                case "7":
                    RunRecordVariant();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір");
                    break;
            }
        }
    }

    static void CreateAndDestroy()
    {
        Console.WriteLine("\n=== Початок створення об'єкта ===");

        {
            Product p = new Product("Трактор", "Сталь", 1000, "Спецтехніка", 50000);
            p.Show();
        }

        Console.WriteLine("\n=== Об'єкт вийшов за межі видимості. Викликаємо GC ===");

        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("\n=== Очищення завершено ===");
    }

    static void ShowPolymorphism()
    {
        Console.WriteLine("\n=== Виклик методу Show() для ієрархії ===");

        Detail[] items = {
            new Detail("Шайба"),
            new Node("Колесо", 1),
            new Mechanism("Коробка передач", "Механічна"),
            new Product("Верстат", 15000)
        };

        foreach (var item in items)
        {
            item.Show();
            Console.WriteLine();
        }

        Console.WriteLine("=== Очищуємо масив об'єктів ===");
        items = null;

        GC.Collect();
        GC.WaitForPendingFinalizers();
    }

    static Client[] GetBankDB()
    {
        return [
            new Depositor("Іванов", new DateTime(2023, 5, 10), 15000, 12.5),
            new Creditor("Петров", new DateTime(2024, 3, 16), 50000, 24.0, 45000),
            new Organization("ТехноСвіт", new DateTime(2023, 5, 10), "UA123456", 1000000),
            new Depositor("Сидоренко", new DateTime(2025, 1, 20), 2000, 10.0)
        ];
    }

    static void ShowBankDatabase()
    {
        Console.WriteLine("\n=== Повна база клієнтів банку ===");
        Client[] db = GetBankDB();

        foreach (var c in db)
        {
            c.Show();
        }
    }

    static void SearchBankByDate()
    {
        Client[] db = GetBankDB();
        Console.Write("\nВведіть дату для пошуку (рррр-мм-дд): ");

        if (DateTime.TryParse(Console.ReadLine(), out DateTime searchDate))
        {
            bool found = false;
            Console.WriteLine($"\nКлієнти, що почали працювати {searchDate.ToShortDateString()}:");

            foreach (var c in db)
            {
                if (c.IsMatchDate(searchDate))
                {
                    c.Show();
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Клієнтів на цю дату не знайдено");
        }
        else
        {
            Console.WriteLine("Некоректний формат дати");
        }
    }

    static void RunStructVariant()
    {
        Console.WriteLine("\n=== Робота зі структурами (PersonStruct) ===");
        List<PersonStruct> list = new()
        {
            new PersonStruct("Іванов І.І.", "Київ", "111", 20),
            new PersonStruct("Петров П.П.", "Львів", "222", 25),
            new PersonStruct("Сидор С.С.", "Одеса", "333", 20)
        };

        Console.Write("Введіть вік для видалення: ");
        if (int.TryParse(Console.ReadLine(), out int age))
            list.RemoveAll(p => p.Age == age);

        Console.Write("Введіть номер телефону для вставки після: ");
        string phone = Console.ReadLine();
        int idx = list.FindIndex(p => p.Phone == phone);

        if (idx != -1)
            list.Insert(idx + 1, new PersonStruct("Новий Н.Н.", "Харків", "777", 30));

        foreach (var p in list) p.Show();
    }

    static void RunTupleVariant()
    {
        Console.WriteLine("\n=== Робота з кортежами (Tuples) ===");
        var list = new List<(string FullName, string Address, string Phone, int Age)>
        {
            ("Іванов І.І.", "Київ", "111", 20),
            ("Петров П.П.", "Львів", "222", 25)
        };

        Console.Write("Введіть вік для видалення: ");
        if (int.TryParse(Console.ReadLine(), out int age))
            list = list.Where(p => p.Age != age).ToList();

        Console.Write("Введіть номер телефону для вставки після: ");
        string phone = Console.ReadLine();
        int idx = list.FindIndex(p => p.Phone == phone);

        if (idx != -1)
            list.Insert(idx + 1, ("Антонов А.А.", "Дніпро", "888", 22));

        foreach (var p in list)
            Console.WriteLine($"{p.FullName}, {p.Age} років, тел: {p.Phone}, адреса: {p.Address}");
    }

    static void RunRecordVariant()
    {
        Console.WriteLine("\n=== Робота із записами (PersonRecord) ===");
        List<PersonRecord> list = new()
        {
            new PersonRecord("Іванов І.І.", "Київ", "111", 20),
            new PersonRecord("Петров П.П.", "Львів", "222", 25)
        };

        Console.Write("Введіть вік для видалення: ");
        if (int.TryParse(Console.ReadLine(), out int age))
            list.RemoveAll(p => p.Age == age);

        Console.Write("Введіть номер телефону для вставки після: ");
        string phone = Console.ReadLine();
        int idx = list.FindIndex(p => p.Phone == phone);

        if (idx != -1)
            list.Insert(idx + 1, new PersonRecord("Борис Б.Б.", "Суми", "999", 40));

        foreach (var p in list)
            Console.WriteLine(p);
    }
}