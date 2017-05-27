using System;
/*
*    Base tasks: +
*    SortedSet: +
*    IComparer: +
*    *, - operators: +
*/

namespace second
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Set<int> set = new Set<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(2);
            Console.WriteLine("Test add: " + set);
            set.Remove(2);
            Console.WriteLine("Test remove: " + set);
            Console.WriteLine("Test contains: " + set.Contains(2));
            Set<int> set1 = set.Where(x => x < 2);
            Console.WriteLine("Test predicate: " + set1);
            set.Remove(1);
            set.Add(5);
            Console.WriteLine("New set: " + set);
            Set<int> set2 = set1 + set;
            Console.WriteLine("Test +(set2): " + set2);
            Set<int> set3 = set2 - set;
            Console.WriteLine("Test -(set3): " + set3);
            Console.WriteLine("Test1 *: " + set3 * set);
            Set<int> set4 = new Set<int>();
            set4.Add(5);
            set4.Add(3);
            set4.Add(2);
            Console.WriteLine("Test2 *: " + set4 * set);
        }
    }
}