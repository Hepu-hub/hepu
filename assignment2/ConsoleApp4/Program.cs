namespace ConsoleApp4;

using System;
using System.Collections.Generic;

class Program
{
    static void Cout_List(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] != 0)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        List<int> numbers = new List<int>();
        for (int i = 2; i <= 100; i++)
        {
            numbers.Add(i);
        }

        int size = 10;
        int index = 2;
        while (index <= size)
        {
            for (int j = 0; j < numbers.Count; j++)
            {
                if (numbers[j] != index && numbers[j] % index == 0)
                {
                    numbers[j] = 0;
                }
            }
            index++;
        }
        Cout_List(numbers);
    }
}