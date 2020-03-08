using System;
using System.Collections.Generic;

namespace ReordenarListaEnlazada
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> list = new LinkedList<int>();
            int quantity;
            do
            {
                Console.Write("Inserte la cantidad de elementos: ");
                quantity = int.Parse(Console.ReadLine());
            } while (quantity <= 0);
            list = Create(quantity);
            Display(list, "Lista enlazada: ");
            Display(Reorder(list), "Lista reordenada: ");
        }
        private static LinkedList<int> Create(int quantity)
        {
            LinkedList<int> list = new LinkedList<int>();
            LinkedListNode<int> current;

            Console.Write("Elemento [1]: ");
            list.AddFirst(int.Parse(Console.ReadLine()));

            current = list.Last;

            for (int i = 1; i < quantity; i++)
            {
                Console.Write($"Elemento [{i + 1}]: ");
                var value = int.Parse(Console.ReadLine());
                list.AddAfter(current, value);
                current = list.Last;
            }
            return list;
        }
        private static LinkedList<int> Reorder(LinkedList<int> list)
        {
            LinkedList<int> orderedList = new LinkedList<int>();
            LinkedListNode<int> current;

            int limit = list.Count;
            orderedList.AddFirst(list.First.Value);
            current = orderedList.Last;
            list.RemoveFirst();
            Console.WriteLine();
            for (int i = 1; i < limit; i += 2)
            {
                orderedList.AddAfter(current, list.Last.Value);
                current = orderedList.Last;
                if (list.Count > 1)
                {
                    orderedList.AddAfter(current, list.First.Value);
                    current = orderedList.Last;
                }
                list = Remove(list);
            }

            return orderedList;
        }
        private static LinkedList<int> Remove(LinkedList<int> list)
        {
            if (list.Count > 0)
                list.RemoveFirst();
            if (list.Count > 0)
                list.RemoveLast();
            return list;
        }
        private static void Display(LinkedList<int> list, string tittle)
        {
            Console.WriteLine($"\n{tittle}");
            foreach (int value in list)
            {
                Console.Write(value + "->");
            }
        }

    }
}
