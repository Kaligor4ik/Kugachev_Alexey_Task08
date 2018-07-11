using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<Unit> iArr = new List<Unit> { new Unit(), new Unit(), new Unit(), new Unit(), new Unit() };
            DinamicArray<Unit> arr = new DinamicArray<Unit>(iArr);
            Console.WriteLine(arr.ToString());
            arr.Add(new Unit());
            Console.WriteLine(arr.ToString());

            Console.WriteLine(arr.GetEnumerator().Current);
            Console.WriteLine(arr.GetEnumerator().MoveNext());
            Console.WriteLine(arr.GetEnumerator().Current);
            Console.WriteLine(arr.GetEnumerator().MoveNext());
            Console.WriteLine(arr.GetEnumerator().Current);
            Console.ReadKey();
        }
    }

    class Unit
    {
        public static int count = 1;
        public int num;

        public Unit()
        {
            num = count;
            count++;
        }

        public override string ToString()
        {
            return "Unit №" + num;
        }
    }
}
