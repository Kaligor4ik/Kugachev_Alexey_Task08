using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    public class Man
    {
        public static int count = 1;
        public int num;
        public bool status;

        public Man()
        {
            status = true;
            num = count;
            count++;
        }

        public void Kill()
        {
            status = false;
        }

        public override string ToString()
        {
            if (status)
            {
                return string.Format("Игрок №{0} - в игре", num);
            }
            else
            {
                return string.Format("Игрок №{0} - провал", num);
            }
        }
    }
}
