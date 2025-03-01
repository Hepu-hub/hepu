namespace ConsoleApp5;

using System;
using System.Collections.Generic;

class Program
{
    static List<List<int>> Cin_String()
    {
        Console.WriteLine("Cin the matrix size:");
        int M = int.Parse(Console.ReadLine());
        int N= int.Parse(Console.ReadLine());
        Console.WriteLine("Cin the matrix numbers:");
        List<List<int>> Cin = new List<List<int>>();
        for (int i = 0; i < M; i++)
        {
            List<int> temp = new List<int>();
            for (int j = 0; j < N; j++)
            {
                Console.Write($"Enter element at position [{i},{j}]: ");
                int number = int.Parse(Console.ReadLine());
                temp.Add(number);
            }
            Cin.Add(temp);
        }
        return Cin;
    }
    static void Main(string[] args)
    {
        List<List<int>> Cin = Cin_String();
        int x=Cin[0].Count;
        int y=Cin.Count;
        int size;
        if (x >= y)
        {
            size = y;
        }
        else
        {
            size = x;
        }
        List<int> result = new List<int>();
        for (int i = 0; i < size; i++)
        {
            result.Add(Cin[i][i]);
        }
        int num = result[0];
        bool flag = true;
        for (int i = 0; i < result.Count; i++)
        {
            if (num != result[i])
            {
                flag = false;
            }
        }
        Console.WriteLine(flag);
    }
}