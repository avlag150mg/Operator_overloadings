using System;

public class TemperatureArray
{
    public double[] Temperatures { get; private set; } = new double[7];

    public double this[int dayIndex]
    {
        get
        {
            if (dayIndex < 0 || dayIndex >= Temperatures.Length)
                throw new IndexOutOfRangeException("Неправильний індекс дня тижня. Має бути від 0 до 6.");
            return Temperatures[dayIndex];
        }
        set
        {
            if (dayIndex < 0 || dayIndex >= Temperatures.Length)
                throw new IndexOutOfRangeException("Неправильний індекс дня тижня. Має бути від 0 до 6.");
            Temperatures[dayIndex] = value;
        }
    }

    public double GetAverageTemperature()
    {
        double sum = 0;
        foreach (var temp in Temperatures)
        {
            sum += temp;
        }
        return sum / Temperatures.Length;
    }
    public void PrintTemperatures()
    {
        string[] days = { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", "Неділя" };
        
        for (int i = 0; i < Temperatures.Length; i++)
        {
            Console.WriteLine($"{days[i]}: {Temperatures[i]} °C");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        TemperatureArray temps = new TemperatureArray();

        // Записуємо температури для тижня
        temps[0] = 15.5;
        temps[1] = 17.2;
        temps[2] = 16.0;
        temps[3] = 18.1;
        temps[4] = 19.3;
        temps[5] = 20.0;
        temps[6] = 18.5;

        Console.WriteLine("Температури за тиждень:");
        temps.PrintTemperatures();

        Console.WriteLine($"\nСередня температура за тиждень: {temps.GetAverageTemperature():F2} °C");
    }
}
