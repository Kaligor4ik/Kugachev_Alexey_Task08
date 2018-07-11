using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class RouletteByList<Man> : List<Man> where Man: new()
    {
        public RouletteByList(int num) : base(num)
        {
            for (int i = 0; i < num; i++)
            {
                Add(new Man());
            }
        }

        public void Print()
        {
            foreach(Man m in this)
            {
                Console.Write(m.ToString() + "\t");
            }                
            Console.WriteLine();
        }

        public void Go()
        {           
            int start = 0;
            int i = start;
            while (Count > 1)
            {
                if (i + 2 > Count)
                {
                    i = start;
                    Remove(this[i]);
                }
                else if(i + 2 == Count)
                {
                    Remove(this[i + 1]);
                    i = start;
                }
                else
                {
                    Remove(this[++i]);
                }
                Print();
            }
        }
    }
}
