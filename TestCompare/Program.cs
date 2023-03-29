// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

public class Person : IEquatable<Person>
{
    public bool Equals(Person? other)
    {
        throw new NotImplementedException();
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((Person)obj);
    }

    public override int GetHashCode()
    {
        throw new NotImplementedException();
    }
}