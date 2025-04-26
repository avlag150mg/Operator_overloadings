using System;

public class TemperatureArray
{
    // Автоматична властивість для зберігання температури за днями тижня
    public double[] Temperatures { get; private set; } = new double[7];

    // Індексатор для доступу до температури за індексом дня
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

    // Метод для обчислення середньої температури за тиждень
    public double GetAverageTemperature()
    {
        double sum = 0;
        foreach (var temp in Temperatures)
        {
            sum += temp;
        }
        return sum / Temperatures.Length;
    }

    // Метод для виведення всіх температур
    public void PrintTemperatures()
    {
        string[] days = { "Понеділок", "Вівторок", "Середа", "Четвер", "П'ятниця", "Субота", "Неділя" };
        
        for (int i = 0; i < Temperatures.Length; i++)
        {
            Console.WriteLine($"{days[i]}: {Temperatures[i]} °C");
        }
    }
}