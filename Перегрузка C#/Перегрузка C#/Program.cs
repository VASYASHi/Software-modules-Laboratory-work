using System;

// Структура, представляющая точку на плоскости
struct Point
{
    public int X;
    public int Y;

    // Конструктор
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    // Переопределение ToString для удобного вывода
    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    // Перегрузка оператора + для сложения двух точек
    public static Point operator +(Point a, Point b)
    {
        return new Point(a.X + b.X, a.Y + b.Y);
    }
}

class Program
{
    // Перегрузка 1: сложение двух целых чисел
    static int Add(int a, int b)
    {
        Console.WriteLine("Вызван Add(int, int)");
        return a + b;
    }

    // Перегрузка 2: сложение двух чисел с плавающей точкой
    static double Add(double a, double b)
    {
        Console.WriteLine("Вызван Add(double, double)");
        return a + b;
    }

    // Перегрузка 3: сложение двух структур Point
    static Point Add(Point a, Point b)
    {
        Console.WriteLine("Вызван Add(Point, Point)");
        return a + b;   // использует перегруженный оператор +
    }

    // Перегрузка 4: сложение целого числа и Point (сдвиг точки)
    static Point Add(int a, Point b)
    {
        Console.WriteLine("Вызван Add(int, Point)");
        return new Point(a + b.X, a + b.Y);
    }

    static void Main()
    {
        // 1. Целые числа
        int sumInt = Add(10, 20);
        Console.WriteLine($"Результат: {sumInt}\n");

        // 2. Числа double
        double sumDouble = Add(3.5, 2.7);
        Console.WriteLine($"Результат: {sumDouble}\n");

        // 3. Точки (структуры)
        Point p1 = new Point(1, 2);
        Point p2 = new Point(3, 4);
        Point sumPoint = Add(p1, p2);
        Console.WriteLine($"Результат: {sumPoint}\n");

        // 4. Смешанный вариант: int + Point
        Point shifted = Add(5, p1);
        Console.WriteLine($"Результат: {shifted}\n");
    }
}