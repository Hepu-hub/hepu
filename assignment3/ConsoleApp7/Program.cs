using System.Linq.Expressions;

namespace ConsoleApp7;

using System;
using System.Collections.Generic;

abstract class Shape
{
    public abstract double Area();
    public abstract bool IfLeagal();
}

class Circle : Shape
{
    private double sideA;
    public override double Area()
    {
        if (IfLeagal())
        {
            return sideA * sideA*3.14159;
        }
        Console.WriteLine("Please, enter valid side");
        return 0;
    }
    public override bool IfLeagal()
    {
        if (sideA > 0 )
        {
            return true;
        }
        return false;
    }
    public Circle(double sideA)
    {
        this.sideA = sideA; 
    }
}

class Sqare:Shape
{
    private double sideA;
    public override double Area()
    {
        if (IfLeagal())
        {
            return sideA * sideA;
        }
        Console.WriteLine("please enter the rvalid sides");
        return 0;
    }

    public override bool IfLeagal()
    {
        if (sideA > 0)
        {
            return true;
        }
        return false;
    }

    public Sqare(double sideA)
    {
        this.sideA = sideA;
    }
}

class ShapeFactory
{
    private static int number;

    private static Random random = new Random();
    
    public static Shape CreateShape(int i)
    {
        number = random.Next(2);
        switch(number)
        {
            case 0:
                return new Circle(random.NextDouble()+1.0);break;
            case 1:
                return new Sqare(random.NextDouble()+1.0);break;
            default:
                Console.WriteLine("There is no such shape");
                return null;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
       List<Shape> shapes = new List<Shape>();
       double area = 0;
       for (int i = 0; i < 10; i++)
       {
           Shape shape=ShapeFactory.CreateShape(i);
           shapes.Add(shape);
           area =area+ shape.Area();
           Console.WriteLine($"shape{i} area: {shape.Area()}");
       }
       Console.WriteLine($"Total Area: {area}");
    }
}