using System;
using System.Collections.Generic;

abstract class Employee
{
    public string Name { get; set; }
    public string Position { get; set; }

    public Employee(string name, string position)
    {
        Name = name;
        Position = position;
    }

    public abstract double CalculateSalary();

    public override string ToString()
    {
        return $"{Name} ({Position})";
    }
}

class Worker : Employee
{
    public double HourlyRate { get; set; }
    public int Hours { get; set; }

    public Worker(string name, double hourlyRate, int hours)
        : base(name, "Рабочий")
    {
        HourlyRate = hourlyRate;
        Hours = hours;
    }

    public override double CalculateSalary()
    {
        return HourlyRate * Hours;
    }
}

class Manager : Employee
{
    public double FixedSalary { get; set; }
    public double Bonus { get; set; }

    public Manager(string name, double fixedSalary, double bonus)
        : base(name, "Менеджер")
    {
        FixedSalary = fixedSalary;
        Bonus = bonus;
    }

    public override double CalculateSalary()
    {
        return FixedSalary + Bonus;
    }
}

class EmployeeSystem
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(Employee e)
    {
        employees.Add(e);
        Console.WriteLine("Сотрудник добавлен: " + e);
    }

    public void ShowEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("Сотрудников нет.");
        }
        else
        {
            foreach (var e in employees)
            {
                Console.WriteLine($"{e} | Зарплата: {e.CalculateSalary()}");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        EmployeeSystem system = new EmployeeSystem();

        while (true)
        {
            Console.WriteLine("\n1. Добавить рабочего");
            Console.WriteLine("2. Добавить менеджера");
            Console.WriteLine("3. Показать сотрудников");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Неверный ввод!");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Имя: ");
                    string nameWorker = Console.ReadLine();
                    Console.Write("Ставка за час: ");
                    double rate = double.Parse(Console.ReadLine());
                    Console.Write("Часы: ");
                    int hours = int.Parse(Console.ReadLine());
                    system.AddEmployee(new Worker(nameWorker, rate, hours));
                    break;

                case 2:
                    Console.Write("Имя: ");
                    string nameManager = Console.ReadLine();
                    Console.Write("Фиксированная зарплата: ");
                    double fixedSalary = double.Parse(Console.ReadLine());
                    Console.Write("Премия: ");
                    double bonus = double.Parse(Console.ReadLine());
                    system.AddEmployee(new Manager(nameManager, fixedSalary, bonus));
                    break;

                case 3:
                    system.ShowEmployees();
                    break;

                case 0:
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
}
