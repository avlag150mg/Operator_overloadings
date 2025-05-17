using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    public int Numerator
    {
        get => numerator;
        set => numerator = value;
    }

    public int Denominator
    {
        get => denominator;
        set
        {
            if (value == 0)
                throw new ArgumentException("Знаменник не може бути нулем.");
            denominator = value;
        }
    }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
        Reduce(); 
    }

    public void Reduce()
    {
        int gcd = GCD(Math.Abs(Numerator), Math.Abs(Denominator));
        Numerator /= gcd;
        Denominator /= gcd;

        if (Denominator < 0)
        {
            Numerator = -Numerator;
            Denominator = -Denominator;
        }
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(
            a.Numerator * b.Denominator + b.Numerator * a.Denominator,
            a.Denominator * b.Denominator
        );
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(
            a.Numerator * b.Denominator - b.Numerator * a.Denominator,
            a.Denominator * b.Denominator
        );
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(
            a.Numerator * b.Numerator,
            a.Denominator * b.Denominator
        );
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        if (b.Numerator == 0)
            throw new DivideByZeroException("Не можна ділити на дріб з чисельником 0.");
        return new Fraction(
            a.Numerator * b.Denominator,
            a.Denominator * b.Numerator
        );
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.Numerator * b.Denominator == b.Numerator * a.Denominator;
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is Fraction other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return (Numerator, Denominator).GetHashCode();
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}
class Program
{
    static void Main(string[] args)
    {
        Fraction a = new Fraction(1, 2);
        Fraction b = new Fraction(3, 4);

        Console.WriteLine($"a = {a}");
        Console.WriteLine($"b = {b}");

        Console.WriteLine($"a + b = {a + b}");
        Console.WriteLine($"a - b = {a - b}");
        Console.WriteLine($"a * b = {a * b}");
        Console.WriteLine($"a / b = {a / b}");

        Console.WriteLine($"a == b ? {a == b}");
        Console.WriteLine($"a != b ? {a != b}");
    }
}
