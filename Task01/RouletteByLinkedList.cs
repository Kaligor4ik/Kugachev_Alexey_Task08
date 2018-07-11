using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class RouletteByLinkedList<T> : LinkedList<T> where T: Man, new()
    {
        LinkedListNode<T> node;
       
        public RouletteByLinkedList(int number): base()
        {
            for (int i = 0; i < number; i++)
            {
                AddLast(new T());
            }
        }

        public void Print()
        {
            LinkedListNode<T> currentNode = node;
            for (node = First; node != null; node = node.Next)
                Console.Write(node.Value.ToString() + "\t");
            Console.WriteLine();
            node = currentNode;
        }
        
        public void Go()
        {
            node = First;
            GetNext().GetNext();
            while (Count > 1)
            {
                if(node.Previous is null)
                {
                    Remove(Last);
                }
                else
                {
                    Remove(node.Previous);
                }
                GetNext().GetNext();
                Print();
            }
        }

        public RouletteByLinkedList<T> GetNext()
        {
            node = node.Next;
            if (node == null)
            {
                node = First;
            }
            return this;
        }
    }
}
