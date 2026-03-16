using System.Reflection;

namespace Lab5.Tests;

public class Lab5Tests
{
    [Fact]
    public void Hierarchy_ProductInheritance_ShouldSetCorrectValues()
    {
        var product = new Product("Трактор", "Сталь", 1000, "Спецтехніка", 50000);

        var field = typeof(Detail).GetField("name", BindingFlags.NonPublic | BindingFlags.Instance);
        var nameValue = field.GetValue(product) as string;

        Assert.Equal("Трактор", nameValue);
    }

    [Fact]
    public void BankSystem_SearchByDate_ShouldFindCorrectClients()
    {
        var searchDate = new DateTime(2023, 5, 10);
        Client[] db = {
            new Depositor("Іванов", new DateTime(2023, 5, 10), 100, 10),
            new Creditor("Петров", new DateTime(2024, 1, 1), 200, 20, 150)
        };

        var results = db.Where(c => c.IsMatchDate(searchDate)).ToList();

        Assert.Single(results);
        Assert.Equal("Іванов", results[0].GetName());
    }

    [Fact]
    public void Struct_DeleteByAge_ShouldRemoveCorrectEntries()
    {
        var list = new List<PersonStruct>
        {
            new PersonStruct("A", "Addr", "1", 20),
            new PersonStruct("B", "Addr", "2", 25)
        };

        list.RemoveAll(p => p.Age == 20);

        Assert.Single(list);
        Assert.Equal(25, list[0].Age);
    }

    [Fact]
    public void Struct_InsertAfterPhone_ShouldPlaceCorrectPosition()
    {
        var list = new List<PersonStruct>
        {
            new PersonStruct("A", "Addr", "111", 20),
            new PersonStruct("B", "Addr", "222", 25)
        };
        var targetPhone = "111";
        var idx = list.FindIndex(p => p.Phone == targetPhone);

        if (idx != -1)
            list.Insert(idx + 1, new PersonStruct("New", "Addr", "777", 30));

        Assert.Equal("New", list[1].FullName);
        Assert.Equal(3, list.Count);
    }

    [Fact]
    public void Tuple_DeleteByAge_ShouldFilterList()
    {
        var list = new List<(string FullName, string Address, string Phone, int Age)>
        {
            ("A", "Addr", "1", 20),
            ("B", "Addr", "2", 25)
        };

        list = list.Where(p => p.Age != 20).ToList();

        Assert.Single(list);
        Assert.Equal(25, list[0].Age);
    }

    [Fact]
    public void Record_EqualityByValue_ShouldBeTrueForSameData()
    {
        var r1 = new PersonRecord("Ivan", "Kyiv", "123", 20);
        var r2 = new PersonRecord("Ivan", "Kyiv", "123", 20);

        Assert.Equal(r1, r2);
        Assert.True(r1 == r2);
    }

    [Fact]
    public void Record_DeleteAndInsert_LogicCheck()
    {
        var list = new List<PersonRecord>
        {
            new ("A", "Addr", "111", 20),
            new ("B", "Addr", "222", 25)
        };

        list.RemoveAll(p => p.Age == 20);
        int idx = list.FindIndex(p => p.Phone == "222");
        list.Insert(idx + 1, new PersonRecord("C", "Addr", "333", 30));

        Assert.Equal(2, list.Count);
        Assert.Equal("333", list[1].Phone);
    }
}