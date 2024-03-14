using System;
using System.Collections;

class Point : IEnumerable
{
    private int x;
    private int y;
    private ConsoleColor color;

    // Конструктори
    public Point()
    {
        x = 0;
        y = 0;
        color = ConsoleColor.White; // Білий колір за замовчуванням
    }

    public Point(int x, int y, ConsoleColor color)
    {
        this.x = x;
        this.y = y;
        this.color = color;
    }

    // Методи
    public void PrintCoordinates()
    {
        Console.ForegroundColor = color;
        Console.WriteLine($"Координати точки: ({x}, {y})");
        Console.ResetColor();
    }

    public double DistanceToOrigin()
    {
        return Math.Sqrt(x * x + y * y);
    }

    public void Move(int x1, int y1)
    {
        x += x1;
        y += y1;
    }

    // Властивості
    public int X
    {
        get { return x; }
        set { x = value; }
    }

    public int Y
    {
        get { return y; }
        set { y = value; }
    }

    public ConsoleColor Color
    {
        get { return color; }
    }

    // Індексатор
    public object this[int index]
    {
        get
        {
            switch (index)
            {
                case 0: return x;
                case 1: return y;
                case 2: return color;
                default: throw new ArgumentOutOfRangeException("Неправильний індекс.");
            }
        }
        set
        {
            switch (index)
            {
                case 0: x = (int)value; break;
                case 1: y = (int)value; break;
                case 2: color = (ConsoleColor)value; break;
                default: throw new ArgumentOutOfRangeException("Неправильний індекс.");
            }
        }
    }

    // Перевантаження операторів
    public static Point operator ++(Point p)
    {
        p.x++;
        p.y++;
        return p;
    }

    public static Point operator --(Point p)
    {
        p.x--;
        p.y--;
        return p;
    }

    public static bool operator true(Point p)
    {
        return p.x == p.y;
    }

    public static bool operator false(Point p)
    {
        return p.x != p.y;
    }

    public static Point operator +(Point p, int scalar)
    {
        return new Point(p.x + scalar, p.y + scalar, p.color);
    }

    public static Point operator -(Point p, int scalar)
    {
        return new Point(p.x - scalar, p.y - scalar, p.color);
    }

    public static explicit operator string(Point p)
    {
        return $"({p.x}, {p.y}), Color: {p.color}";
    }

    public static explicit operator Point(string s)
    {
        string[] parts = s.Split(new char[] { '(', ',', ')', ':' }, StringSplitOptions.RemoveEmptyEntries);
        int x = int.Parse(parts[0]);
        int y = int.Parse(parts[1]);
        ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), parts[2].Trim());
        return new Point(x, y, color);
    }

    // Реалізація інтерфейсу IEnumerable
    public IEnumerator GetEnumerator()
    {
        yield return x;
        yield return y;
        yield return color;
    }
}

class Pointk
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // Введення координат точки
        Console.WriteLine("Введіть координати точки (x, y):");
        int x = Convert.ToInt32(Console.ReadLine());
        int y = Convert.ToInt32(Console.ReadLine());

        // Введення коліру точки
        Console.WriteLine("Введіть колір для точки (0 - Чорний, 1 - Білий, 2 - Червоний, 3 - Зелений, 4 - Синій):");
        int colorInput = Convert.ToInt32(Console.ReadLine());

        ConsoleColor color = ConsoleColor.White; // Білий колір за замовчуванням

        switch (colorInput)
        {
            case 0:
                color = ConsoleColor.Black;
                break;
            case 1:
                color = ConsoleColor.White;
                break;
            case 2:
                color = ConsoleColor.Red;
                break;
            case 3:
                color = ConsoleColor.Green;
                break;
            case 4:
                color = ConsoleColor.Blue;
                break;
            default:
                Console.WriteLine("Неправильний ввід. Встановлено білий колір за замовчуванням.");
                break;
        }

        // Створення екземпляру класу Point
        Point point = new Point(x, y, color);

        // Виведення інформації про точку та відстань до центра координат
        point.PrintCoordinates();
        Console.WriteLine($"Відстань до центра координат: {point.DistanceToOrigin()}");

        // Переміщення точки на заданий вектор
        Console.WriteLine("Введіть вектор для переміщення (x1, y1):");
        int x1 = Convert.ToInt32(Console.ReadLine());
        int y1 = Convert.ToInt32(Console.ReadLine());
        point.Move(x1, y1);

        // Виведення оновлених координат точки
        Console.WriteLine("Після переміщення:");
        point.PrintCoordinates();

        // Використання оператора foreach
        Console.WriteLine("Координати точки:");
        foreach (var item in point)
        {
            Console.WriteLine(item);
        }
    }
}
