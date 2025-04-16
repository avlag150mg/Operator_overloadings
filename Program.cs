using System;

class Journal
{
    public string Name { get; set; }
    public int YearFounded { get; set; }

    private int _employees;
    public int Employees
    {
        get => _employees;
        set => _employees = value >= 0 ? value : 0;
    }

    public Journal(string name, int year, int employees)
    {
        Name = name;
        YearFounded = year;
        Employees = employees;
    }

    public static Journal operator +(Journal j, int n)
    {
        return new Journal(j.Name, j.YearFounded, j.Employees + n);
    }

    public static Journal operator -(Journal j, int n)
    {
        return new Journal(j.Name, j.YearFounded, j.Employees - n);
    }

    public static bool operator ==(Journal j1, Journal j2)
    {
        return j1.Employees == j2.Employees;
    }

    public static bool operator !=(Journal j1, Journal j2)
    {
        return !(j1 == j2);
    }

    public static bool operator <(Journal j1, Journal j2)
    {
        return j1.Employees < j2.Employees;
    }

    public static bool operator >(Journal j1, Journal j2)
    {
        return j1.Employees > j2.Employees;
    }

    public override bool Equals(object obj)
    {
        if (obj is Journal j)
        {
            return this.Employees == j.Employees;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Employees.GetHashCode();
    }

    public override string ToString()
    {
        return $"Журнал: {Name}, Рік заснування: {YearFounded}, Співробітників: {Employees}";
    }
}