namespace ConsoleApp2;

using System;
using System.Collections.Generic;

class Program
{
    static string Read_Cin()
    {
        Console.WriteLine("Enter number: ");
        string input = Console.ReadLine();
        return input;
    }

    static bool is_Prime_number(int number)
    {
        int num = 2;
        while (num < number)
        {
            if ((number!=num)&&(number % num == 0))
            {
                return false;
            }
            num++;
        }
        return true;
    }
    
    static void Output_String(List<int> input)
    {
        if (input.Count == 0)
        {
            Console.WriteLine("There are no Prime numbers");
        }
        foreach (var VARIABLE in input)
        {
            if (VARIABLE != 1)
            {
                Console.WriteLine(VARIABLE);
            }
        }
    }
    
    static void Main(string[] args)
    {
        string input = Read_Cin();
        int number = int.Parse(input);
        int size=(int)Math.Sqrt(number);
        int i = 2;
        List<int> list = new List<int>(size);
        while (i <= size)
        {
            if (number % i == 0)
            {
                list.Add(i);
            }
            i++;
        }

        for (int j = 0; j < list.Count; j++)
        {
            if (!is_Prime_number(list[j]))
            {
                list[j] = 1;
            }
        }
        Output_String(list);
    }
}