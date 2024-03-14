using System;

// Інтерфейс IFigure описує методи, які мають бути реалізовані у всіх фігурах.
interface IFigure
{
    double CalculateArea(); // Метод для обчислення площі фігури.
    double CalculatePerimeter();
    void DisplayInfo(); 
}

class Rectangle : IFigure
{
    public double Length { get; set; } 
    public double Width { get; set; } 

    // Конструктор класу Rectangle для ініціалізації довжини та ширини прямокутника.
    public Rectangle(double length, double width)
    {
        Length = length;
        Width = width;
    }

    public double CalculateArea()
    {
        return Length * Width;
    }

    public double CalculatePerimeter()
    {
        return 2 * (Length + Width);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Rectangle: Length = {Length}, Width = {Width}, Area = {CalculateArea()}, Perimeter = {CalculatePerimeter()}");
    }
}

class Circle : IFigure
{
    public double Radius { get; set; } 

    // Конструктор класу Circle для ініціалізації радіуса кола.
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double CalculateArea()
    {
        return Math.PI * Radius * Radius;
    }

    public double CalculatePerimeter()
    {
        return 2 * Math.PI * Radius;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Circle: Radius = {Radius}, Area = {CalculateArea()}, Circumference = {CalculatePerimeter()}");
    }
}

class Triangle : IFigure
{
    public double SideA { get; set; } 
    public double SideB { get; set; } 
    public double SideC { get; set; } 
    
    public Triangle(double sideA, double sideB, double sideC)
    {
        SideA = sideA;
        SideB = sideB;
        SideC = sideC;
    }

    public double CalculateArea()
    {
        double s = (SideA + SideB + SideC) / 2;
        return Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));
    }

    public double CalculatePerimeter()
    {
        return SideA + SideB + SideC;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Triangle: SideA = {SideA}, SideB = {SideB}, SideC = {SideC}, Area = {CalculateArea()}, Perimeter = {CalculatePerimeter()}");
    }
}

class Program2
{
    static void Main2(string[] args)
    {
        Console.WriteLine("Enter the number of figures:");
        int n = int.Parse(Console.ReadLine());

        IFigure[] figures = new IFigure[n]; // Масив фігур розміром n.

        for (int i = 0; i < n; i++) // 
        {
            Console.WriteLine($"\nEnter the number of the figure for Figure {i + 1}:");
            Console.WriteLine("1. Rectangle");
            Console.WriteLine("2. Circle");
            Console.WriteLine("3. Triangle");
            int figureChoice = int.Parse(Console.ReadLine());

            switch (figureChoice)
            {
                case 1:
                    Console.WriteLine("Enter length:");
                    double length = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter width:");
                    double width = double.Parse(Console.ReadLine());
                    figures[i] = new Rectangle(length, width); // Створення екземпляра прямокутника.
                    break;
                case 2: // Якщо вибрано коло.
                    Console.WriteLine("Enter radius:");
                    double radius = double.Parse(Console.ReadLine());
                    figures[i] = new Circle(radius);
                    break;
                case 3: // Якщо вибрано трикутник.
                    Console.WriteLine("Enter side A:");
                    double sideA = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter side B:");
                    double sideB = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter side C:");
                    double sideC = double.Parse(Console.ReadLine());
                    figures[i] = new Triangle(sideA, sideB, sideC);
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }

        Console.WriteLine("\nFigures Information:");
        foreach (var figure in figures) // Цикл для кожної фігури.
        {
            figure.DisplayInfo();
        }
    }
    }
