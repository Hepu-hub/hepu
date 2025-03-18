namespace ConsoleApp8;

class Program
{
    public class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Next { get; set; }
        public Node (T t)
        {
            Next = null;
            Data = t;
        }
    }

    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head =  null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> node = new Node<T>(t);
            if (head == tail == null)
            {
                head=tail = node;
            }
            else
            {
                tail.Next = node;
                tail = node;
            }
        }

        public void MyForeach(Action<T> action)
        {
            Node<T> current = head;
            while (current != null)
            {
                action(current.Data);
                current = current.Next;
            }
        }
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine("please input the number of nodes: ");
        int number;
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.Add(6);
        list.ForEach(x=>Console.WriteLine(x));
        int min=int.MaxValue;
        list.ForEach(x=>{if (x < min) min=x;});
        Console.WriteLine(min);
        int max=int.MinValue;
        list.ForEach(x=>{if (x > max) max=x;});
        Console.WriteLine(max);
        int sum = 0;
        list.ForEach(x=>sum += x);
        Console.WriteLine(sum);
    }
}