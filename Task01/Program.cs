using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            RouletteByLinkedList<Man> linkedList = new RouletteByLinkedList<Man>(10);
            linkedList.Print();
            linkedList.Go();

            Console.WriteLine();

            RouletteByList<Man> list = new RouletteByList<Man>(10);
            list.Print();
            list.Go();

            Console.ReadKey();
        }
    }
}
