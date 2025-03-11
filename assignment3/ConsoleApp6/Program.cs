namespace ConsoleApp6;

abstract class Shape
{
    public abstract double Area();
    public abstract bool IfLeagal();
}

class Rectangle : Shape
{
    private double sideA;
    private double sideB;
    public override double Area()
    {
        if (IfLeagal())
        {
            return sideA * sideB;
        }
        Console.WriteLine("Please, enter valid side");
        return 0;
    }
    public override bool IfLeagal()
    {
        if (sideA > 0 && sideB > 0)
        {
            return true;
        }
        return false;
    }
    public Rectangle(double sideA, double sideB)
    {
        this.sideA = sideA; 
        this.sideB = sideB;
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

class Triangle : Shape
{
    private double sideA;
    private double sideB;
    private double sideC;
    public override double Area()
    {
        if (IfLeagal())
        {
            double s = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
            return area;
        }
        Console.WriteLine("please enter a valid Triangle");
        return 0;
    }

    public override bool IfLeagal()
    {
        if (sideA > 0 && sideB > 0 && sideC > 0 && sideA + sideC >sideB && sideB + sideA > sideC &&
            sideB + sideC > sideA)
        {
            return true;
        }
        return false;
    }

    public Triangle(double sideA, double sideB, double sideC)
    {
        this.sideA = sideA;     
        this.sideB = sideB;
        this.sideC = sideC;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("please enter the shape");
        string input = Console.ReadLine();
        if (input == "rectangle")
        {
            Console.WriteLine("please enter the rectangle sides");
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            Rectangle rectangle = new Rectangle(sideA, sideB);
            double area = rectangle.Area();
            bool ifLeagal = rectangle.IfLeagal();
            if (ifLeagal)
            {
                Console.WriteLine("the rectangle is leagal");
                Console.WriteLine("The area of the rectangle is: {0}", area);
            }
            else
            {
                Console.WriteLine("the rectangle is not leagal");
            }
        }
        else if (input == "square")
        {
            Console.WriteLine("please enter the square sides");
            double sideA = double.Parse(Console.ReadLine());
            Sqare square = new Sqare(sideA);
            double area = square.Area();
            bool ifLeagal = square.IfLeagal();
            if (ifLeagal)
            {
                Console.WriteLine("the square is leagal");
                Console.WriteLine("The area of the square is: {0}", area);
            }
            else
            {
                Console.WriteLine("the square is not leagal");
            }
        }
        else if (input == "triangle")
        {
            Console.WriteLine("please enter the triangle sides");
            double sideA = double.Parse(Console.ReadLine());
            double sideB = double.Parse(Console.ReadLine());
            double sideC = double.Parse(Console.ReadLine());
            Triangle triangle = new Triangle(sideA, sideB, sideC);
            double area = triangle.Area();
            bool ifLeagal = triangle.IfLeagal();
            if (ifLeagal)
            {
                Console.WriteLine("the triangle is leagal");    
                Console.WriteLine("The area of the triangle is: {0}", area);
            }
            else
            {
                Console.WriteLine("the triangle is not leagal");
            }
        }
        else
        {
            Console.WriteLine("please enter a valid shape");
        }
    }
}