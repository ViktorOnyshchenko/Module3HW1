using System;
using System.Collections;
using System.IO;
using System.Linq;

namespace Homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>(new int[5] { 5, 4, 3, 2, 1 });
            
            Console.WriteLine("Add:");
            list.Add(6);
            PrintList(list);
            int[] array = { 7, 8, 9, 10, 11 };
            Console.Write($"\nAddRange: ");
            array.ToList().ForEach(number => Console.Write($"{number} "));
            Console.WriteLine();
            list.AddRange(array);
            PrintList(list);
            int value = 6;
            Console.WriteLine($"\nRemove {value}:");
            list.Remove(value);
            PrintList(list);
            int index = 3;
            Console.WriteLine($"\nRemoveAt {index}:");
            try
            {
                list.RemoveAt(index);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            PrintList(list);
            Console.WriteLine("\nSort:");
            list.Sort();
            PrintList(list);

            MyList<string> listStr = new MyList<string>(new string[5] { "Max", "Ilita", "Yarik", "Serega", "Mykola" });
            Console.WriteLine("\nSort:");
            PrintList(list);
            listStr.Sort();
            Console.WriteLine();
            PrintList(listStr);

            Console.ReadKey();
        }
        public static void PrintList(MyList<int> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nCount: {list.Count} Capacity: {list.Capacity}");
        }
        public static void PrintList(MyList<string> list)
        {
            foreach (var item in list)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine($"\nCount: {list.Count} Capacity: {list.Capacity}");
        }
    }
}
