// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;

var result = FindItem(new List<int>(), 4);

Console.WriteLine(result.Value);


void Foo([DisallowNull]Person? input)
{
    Console.WriteLine(input.Name);
}

T? FindItem<T>(List<T> items, T id) where T : struct
{
    return null; // No compiler error
}

class Person
{
    public string? Name { get; set; }
}

