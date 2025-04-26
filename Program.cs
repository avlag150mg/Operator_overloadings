using System;

public class Shop
{
    private string _name;
    private string _address;
    private double _area; 

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Address
    {
        get => _address;
        set => _address = value;
    }

    public double Area
    {
        get => _area;
        set
        {
            if (value >= 0)
                _area = value;
            else
                throw new ArgumentException("Площа не може бути від'ємною!");
        }
    }

    public Shop(string name, string address, double area)
    {
        Name = name;
        Address = address;
        Area = area;
    }

    public static Shop operator +(Shop shop, double additionalArea)
    {
        return new Shop(shop.Name, shop.Address, shop.Area + additionalArea);
    }

    public static Shop operator -(Shop shop, double reductionArea)
    {
        double newArea = shop.Area - reductionArea;
        if (newArea < 0)
            newArea = 0; 
        return new Shop(shop.Name, shop.Address, newArea);
    }

    public static bool operator ==(Shop shop1, Shop shop2)
    {
        if (ReferenceEquals(shop1, shop2))
            return true;
        if (ReferenceEquals(shop1, null) || ReferenceEquals(shop2, null))
            return false;
        return shop1.Area == shop2.Area;
    }

    public static bool operator !=(Shop shop1, Shop shop2)
    {
        return !(shop1 == shop2);
    }
    
    public static bool operator >(Shop shop1, Shop shop2)
    {
        if (ReferenceEquals(shop1, null) || ReferenceEquals(shop2, null))
            throw new ArgumentNullException("Об'єкти не можуть бути null!");
        return shop1.Area > shop2.Area;
    }

    public static bool operator <(Shop shop1, Shop shop2)
    {
        if (ReferenceEquals(shop1, null) || ReferenceEquals(shop2, null))
            throw new ArgumentNullException("Об'єкти не можуть бути null!");
        return shop1.Area < shop2.Area;
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Shop other = (Shop)obj;
        return Area == other.Area;
    }

    public override int GetHashCode()
    {
        return Area.GetHashCode();
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Магазин: {Name}, Адреса: {Address}, Площа: {Area} кв.м");
    }
}
