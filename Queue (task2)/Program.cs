using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        public class MyQueue<T>
        {
            private readonly List<T> items = new List<T>();

            public void Enqueue(T item)
            {
                items.Add(item);
            }

            public T Dequeue()
            {
                if (items.Count == 0)
                    throw new InvalidOperationException("Черга порожня!");

                T item = items[0];
                items.RemoveAt(0);
                return item;
            }

            public int Count => items.Count;

            public bool Contains(T item)
            {
                return items.Contains(item);
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            MyQueue<string> restaurantQueue = new MyQueue<string>();

            // Додаємо клієнтів в чергу
            restaurantQueue.Enqueue("клієнт A");
            restaurantQueue.Enqueue("клієнт B");
            restaurantQueue.Enqueue("клієнт C");
            restaurantQueue.Enqueue("клієнт D");

            // Довжина черги
            Console.WriteLine("Кількість клієнтів в черзі: {0}", restaurantQueue.Count);

            // Осблуговуємо клієнтів по черзі (FIFO) 
            Console.WriteLine("Черга обслуговування...");
            while (restaurantQueue.Count > 0)
            {
                string customer = restaurantQueue.Dequeue();
                Console.WriteLine($"Обслуговується {customer}...");
                // Як опція, перевіряємо, чи клієнт D в черзі
                Console.WriteLine($"Чи клієнт D ще в черзі? {(restaurantQueue.Contains("клієнт D") ? "так" : "ні")}");
            }
            Console.WriteLine("Кількість клієнтів в черзі: {0}", restaurantQueue.Count);
            Console.ReadKey();
        }
    }
}

