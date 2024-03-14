using System;

// Інтерфейс користувача
interface IUser
{
    string Name { get; set; }
    int Age { get; set; }
}

// Інтерфейс .NET
interface IDotNet
{
    void Show();
}

// Інтерфейс студента
interface IStudent : IUser
{
    int StudentID { get; set; }
    string Major { get; set; }
}

// Інтерфейс викладача
interface ITeacher : IUser
{
    string Department { get; set; }
    string Subject { get; set; }
}

// Інтерфейс завідувача кафедри
interface IDepartmentHead : ITeacher
{
    int YearsOfExperience { get; set; }
}

// Клас - Персона
class Person : IUser
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public Person()
    {
        Console.Write("Введіть ім'я: ");
        Name = Console.ReadLine();

        Console.Write("Введіть вік: ");
        int.TryParse(Console.ReadLine(), out int age);
        Age = age;
    }
}

// Клас - Студент
class Student : Person, IStudent, IDotNet
{
    public int StudentID { get; set; }
    public string Major { get; set; }

    public Student(string name, int age, int studentID, string major) : base(name, age)
    {
        StudentID = studentID;
        Major = major;
    }

    public Student() : base()
    {
        Console.Write("Введіть номер студентського: ");
        int.TryParse(Console.ReadLine(), out int studentID);
        StudentID = studentID;

        Console.Write("Введіть спеціальність: ");
        Major = Console.ReadLine();
    }

    public void Show()
    {
        Console.WriteLine($"Студент: {Name}, Вік: {Age}, Номер студентського: {StudentID}, Спеціальність: {Major}");
    }
}

// Клас - Викладач
class Teacher : Person, ITeacher, IDotNet
{
    public string Department { get; set; }
    public string Subject { get; set; }

    public Teacher(string name, int age, string department, string subject) : base(name, age)
    {
        Department = department;
        Subject = subject;
    }

    public Teacher() : base()
    {
        Console.Write("Введіть відділення: ");
        Department = Console.ReadLine();

        Console.Write("Введіть предмет: ");
        Subject = Console.ReadLine();
    }

    public void Show()
    {
        Console.WriteLine($"Викладач: {Name}, Вік: {Age}, Відділення: {Department}, Предмет: {Subject}");
    }
}

// Клас - Завідувач кафедри
class DepartmentHead : Teacher, IDepartmentHead, IDotNet
{
    public int YearsOfExperience { get; set; }

    public DepartmentHead(string name, int age, string department, string subject, int yearsOfExperience) : base(name, age, department, subject)
    {
        YearsOfExperience = yearsOfExperience;
    }

    public DepartmentHead() : base()
    {
        Console.Write("Введіть стаж роботи: ");
        int.TryParse(Console.ReadLine(), out int yearsOfExperience);
        YearsOfExperience = yearsOfExperience;
    }

    public new void Show()
    {
        Console.WriteLine($"Завідувач кафедри: {Name}, Вік: {Age}, Відділення: {Department}, Предмет: {Subject}, Стаж: {YearsOfExperience} років");
    }
}

class Program
{
    static void Main1(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("Введіть дані про студента:");
        Student student = new Student();
        student.Show();
        
        Console.WriteLine("\nВведіть дані про викладача:");
        Teacher teacher = new Teacher();
        teacher.Show();

        Console.WriteLine("\nВведіть дані про завідувача кафедри:");
        DepartmentHead head = new DepartmentHead();
        head.Show();
    }
}
