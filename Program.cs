namespace ConsoleApp1;

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
    }
}