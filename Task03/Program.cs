using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task03
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "I like to move it, move it\nI like to move it, move it\nI like to move it, move it\nYa like to move it";
            String pattern = @"\s*\W*\s+";
            List<string> arr = Regex.Split(str.ToLower(), pattern).ToList();
            SortedSet<string> set = new SortedSet<string>(arr);
            Dictionary<string, string> dict = new Dictionary<string, string>();
            for(int i = 0; i < set.Count; i++)
            {
                string key = set.ElementAt(i);
                dict.Add(key, arr.Count(s => s.Equals(key)).ToString());
            }
            PrintArr(arr);
            PrintArr(set);            
            PrintArr(dict.OrderBy(pair => pair.Value));

            Console.ReadKey();
        }

        public static void PrintArr<T>(IEnumerable<T> arr)
        {
            foreach (T s in arr)
            {
                Console.WriteLine(s.ToString());
            }
            Console.WriteLine("_________________");
        }
    }
}
