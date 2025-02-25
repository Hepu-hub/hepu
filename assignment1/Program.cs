<<<<<<< HEAD
namespace WinFormsApp1;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
=======
﻿namespace ConsoleApp1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a number:");
        double number =double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter a number:");
        double number2 = double.Parse(Console.ReadLine());
        Console.WriteLine("Please enter a op:");
        char op = char.Parse(Console.ReadLine());
        double result=0.0;
        switch (op)
        {
            case '+': result = number + number2;
                break;
            case '-': result = number - number2;
                break;
            case '*': result = number * number2;
                break;
            case '/': result = number / number2;
                break;
        }
        Console.WriteLine("the result is");
        Console.WriteLine(result);
>>>>>>> 0f25dcc6f426592262e21d23661e9bbd127bcfd2
    }
}