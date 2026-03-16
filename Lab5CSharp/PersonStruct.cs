using System;

namespace Lab5;

public struct PersonStruct
{
    public string FullName;
    public string Address;
    public string Phone;
    public int Age;

    public PersonStruct(string name, string addr, string phone, int age)
    {
        FullName = name;
        Address = addr;
        Phone = phone;
        Age = age;
    }

    public void Show() => Console.WriteLine($"{FullName}, {Age} років, тел: {Phone}, адреса: {Address}");
}