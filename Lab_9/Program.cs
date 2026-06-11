
OurLinkedList list = new OurLinkedList();
Random random = new Random();

// Заполняем список случайным количеством элементов (от 0 до 15 для теста)
int size = random.Next(0, 16);
for (int i = 0; i < size; i++)
{
    list.Add(random.Next(1, 100));
}

Console.WriteLine("Содержимое списка:");
list.Print();

double average = list.GetAverageFromFifth();
Console.WriteLine($"\nСреднее арифметическое (начиная с 5-го элемента): {average}");

public class Node
{
    public int Data { get; set; }
    public Node? Next { get; set; }

    public Node(int data)
    {
        Data = data;
    }
}

public class OurLinkedList
{
    Node? head;
    Node? tail;
    int count;

    public void Add(int data)
    {
        Node node = new Node(data);
        if (head == null)
            head = node;
        else
            tail!.Next = node;
        tail = node;
        count++;
    }

    public double GetAverageFromFifth()
    {
        // Если элементов меньше 5, по условию выдаем 0
        if (count < 5 || head == null)
        {
            return 0;
        }

        Node? current = head;
        // Пропускаем первые 4 элемента (индексы 0, 1, 2, 3)
        for (int i = 0; i < 4; i++)
        {
            current = current?.Next;
        }

        long sum = 0;
        int elementsToCount = 0;

        // Считаем сумму и количество, начиная с 5-го элемента
        while (current != null)
        {
            sum += current.Data;
            elementsToCount++;
            current = current.Next;
        }

        return (double)sum / elementsToCount;
    }

    public void Print()
    {
        if (head == null)
        {
            Console.WriteLine("Список пуст");
            return;
        }
        Node? current = head;
        while (current != null)
        {
            Console.Write(current.Data + " ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}