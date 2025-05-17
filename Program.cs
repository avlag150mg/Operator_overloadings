using System;

public class Product
{
    private string _name;
    private int _quantity;
    private decimal _price;

    public string Name
    {
        get => _name;
        set => _name = value ?? "Без назви";
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentException("Кількість не може бути від'ємною!");
            _quantity = value;
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Ціна не може бути від'ємною!");
            _price = value;
        }
    }

    public Product(string name, int quantity, decimal price)
    {
        Name = name;
        Quantity = quantity;
        Price = price;
    }

    public static Product operator +(Product p, int amount)
    {
        return new Product(p.Name, p.Quantity + amount, p.Price);
    }

    public static Product operator -(Product p, int amount)
    {
        int newQty = p.Quantity - amount;
        if (newQty < 0) newQty = 0;
        return new Product(p.Name, newQty, p.Price);
    }

    public static bool operator ==(Product a, Product b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;
        return a.Price == b.Price;
    }

    public static bool operator !=(Product a, Product b) => !(a == b);

    public static bool operator >(Product a, Product b)
    {
        if (a is null || b is null)
            throw new ArgumentNullException("Об'єкти не можуть бути null.");
        return a.Quantity > b.Quantity;
    }

    public static bool operator <(Product a, Product b)
    {
        if (a is null || b is null)
            throw new ArgumentNullException("Об'єкти не можуть бути null.");
        return a.Quantity < b.Quantity;
    }

    public override bool Equals(object obj)
    {
        if (obj is Product other)
            return this == other;
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Quantity, Price);
    }

    public override string ToString()
    {
        return $"Товар: {Name}, Кількість: {Quantity}, Ціна: {Price:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Product p1 = new Product("Хліб", 10, 15.50m);
        Product p2 = new Product("Молоко", 5, 15.50m);

        Console.WriteLine("Початкові товари:");
        Console.WriteLine(p1);
        Console.WriteLine(p2);

        p1 = p1 + 5;
        p2 = p2 - 2;

        Console.WriteLine("\nПісля зміни кількості:");
        Console.WriteLine(p1);
        Console.WriteLine(p2);

        Console.WriteLine($"\nЦіни однакові? {p1 == p2}");
        Console.WriteLine($"Першого товару більше, ніж другого? {p1 > p2}");
    }
}

