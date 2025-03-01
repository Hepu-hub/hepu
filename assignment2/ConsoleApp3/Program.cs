namespace ConsoleApp3;

class Program
{
    static int[] Read_Data(out int x)
    {
        Console.Write("Enter the size of array: ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        Console.Write("Enter the number of elements: ");
        x = size;
        for (int i = 0; i < size; i++)
        {
            int element = int.Parse(Console.ReadLine());
            array[i] = element;
        }
        return array;
    }
    static void Output(int Max, int Min, int Sum, int average)
    {
        Console.WriteLine($"Max: {Max}, Min: {Min}, Sum: {Sum}, average: {average}");
    }

    static int SumOfElements(int[] array,int size)
    {
        int sum = 0;
        for (int i = 0; i < size; i++)
        {
            sum += array[i];
        }
        return sum;
    }
    static int AverageOfElements(int size, int sum)
    {
        return sum / size;
    }

    static int MinOfElements(int[] array, int size)
    {
        int min = Int32.MaxValue;
        for (int i = 0; i < size; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;
    }

    static int MaxOfElements(int[] array, int size)
    {
        int max = Int32.MinValue;
        for (int i = 0; i < size; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }
    static void Main(string[] args)
    {
        int size;
        int[] array = Read_Data(out size);
        int sum = SumOfElements(array, size);
        int min = MinOfElements(array, size);
        int max = MaxOfElements(array, size);
        int average = AverageOfElements(size, sum);
        Output(max, min, sum, average);
    }
}