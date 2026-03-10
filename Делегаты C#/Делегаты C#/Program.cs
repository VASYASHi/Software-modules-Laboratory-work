using System;

struct Point
{
    public int X;
    public int Y;

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override string ToString() => $"({X}, {Y})";

    public static Point operator +(Point a, Point b) => new Point(a.X + b.X, a.Y + b.Y);
}

public delegate T BinaryOperation<T>(T a, T b);

class Program
{
 
    static int Add(int a, int b)
    {
        Console.WriteLine("Вызван Add(int, int)");
        return a + b;
    }


    static double Add(double a, double b)
    {
        Console.WriteLine("Вызван Add(double, double)");
        return a + b;
    }

 
    static Point Add(Point a, Point b)
    {
        Console.WriteLine("Вызван Add(Point, Point)");
        return a + b;   
    }

    
    static Point Add(int a, Point b)
    {
        Console.WriteLine("Вызван Add(int, Point)");
        return new Point(a + b.X, a + b.Y);
    }

    // Метод, принимающий делегат и два операнда
    static T ApplyOperation<T>(BinaryOperation<T> operation, T x, T y)
    {
        Console.WriteLine($"Применяем операцию к {x} и {y}");
        return operation(x, y);
    }

    static void Main()
    {
        // 1. Прямые вызовы перегруженных методов (как в исходном коде)
        Console.WriteLine("=== Прямые вызовы ===");
        int sumInt = Add(10, 20);
        Console.WriteLine($"Результат: {sumInt}\n");

        double sumDouble = Add(3.5, 2.7);
        Console.WriteLine($"Результат: {sumDouble}\n");

        Point p1 = new Point(1, 2);
        Point p2 = new Point(3, 4);
        Point sumPoint = Add(p1, p2);
        Console.WriteLine($"Результат: {sumPoint}\n");

        Point shifted = Add(5, p1);
        Console.WriteLine($"Результат: {shifted}\n");

        // 2. Использование делегатов
        Console.WriteLine("=== Использование делегатов ===");

        // Создание экземпляров делегата для разных типов
        BinaryOperation<int> intOp = Add;      // указывает на Add(int, int)
        BinaryOperation<double> doubleOp = Add; // указывает на Add(double, double)
        BinaryOperation<Point> pointOp = Add;   // указывает на Add(Point, Point)

        // Вызов через делегаты
        int resultInt = intOp(15, 25);
        Console.WriteLine($"Делегат int -> результат: {resultInt}\n");

        double resultDouble = doubleOp(1.2, 3.4);
        Console.WriteLine($"Делегат double -> результат: {resultDouble}\n");

        Point resultPoint = pointOp(new Point(2, 3), new Point(4, 5));
        Console.WriteLine($"Делегат Point -> результат: {resultPoint}\n");

        // 3. Передача делегата в метод ApplyOperation
        Console.WriteLine("=== Передача делегата в метод ===");
        int res = ApplyOperation(intOp, 100, 200);
        Console.WriteLine($"Результат ApplyOperation: {res}\n");

        Point resPoint = ApplyOperation(pointOp, new Point(1, 1), new Point(2, 2));
        Console.WriteLine($"Результат ApplyOperation: {resPoint}\n");

        // 4. Использование лямбда-выражения вместо явного метода
        BinaryOperation<int> multiply = (x, y) => x * y;
        int product = ApplyOperation(multiply, 6, 7);
        Console.WriteLine($"Умножение через делегат: {product}");
    }
}