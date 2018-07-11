using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task02
{
    class DinamicArray<T> : IEnumerable where T : new()
    {
        private const int DefaultLength = 8;
        public T[] arr;

        public DinamicArray()
        {
            arr = new T[DefaultLength];
        }

        public DinamicArray(int capacity)
        {
            arr = new T[capacity];
        }
        
        public DinamicArray(T[] arr)
        {
            this.arr = new T[arr.Length];
            Clone(arr, this.arr);
        }

        public DinamicArray(IEnumerable<T> arr)
        {
            this.arr = new T[arr.Count<T>()];
            Clone(arr.ToArray(), this.arr);
        }

        public void Add(T t)
        {
            if (arr.Last() != null)
            {
                Expand(Capacity + DefaultLength);
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == null)
                {
                    arr[i] = t;
                    return;
                }
            }
        }

        public void AddRange(T[] t)
        {
            if (arr.Length - Length < t.Length)
            {
                Expand(Capacity + t.Length);
            }

            for (int i = 0; i < t.Length; i++)
            {
                Add(t[i]);
            }
        }

        public void Clone(T[] from, T[] to)
        {
            if (to.Length < from.Length) throw new Exception("Новый массив меньше клонируемого");
            for (int i = 0; i < from.Length; i++)
            {
                if (from[i] != null)
                {
                    to[i] = from[i];
                }
            }
        }

        public void Expand(int capacity)
        {
            T[] newArr = new T[capacity];
            Clone(arr, newArr);
            arr = new T[newArr.Length];
            Clone(newArr, arr);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Массив с общей длиной - {0}, количеством заполненных ячеек - {1}:\n", Capacity, Length);

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != null)
                {
                    sb.AppendFormat(arr[i].ToString() + "\n");
                }
                else
                {
                    sb.AppendFormat("[null] \n");
                }
            }
            return sb.ToString();
        }

        public int Length
        {
            get
            {
                int count = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] != null)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public int Capacity
        {
            get
            {
                return arr.Length;
            }
        }

        public bool Remove(int i)
        {
            if (i > arr.Length) return false;
            for (int j = i; j < Capacity - 1; j++)
            {
                arr[j] = arr[j + 1] == null ? default(T) : arr[j + 1];
                arr[Capacity - 1] = default(T);
            }
            return true;
        }

        public bool Insert(int i, T t)
        {
            int lastIndex = Capacity - 1;
            if (i > arr.Length) throw new ArgumentOutOfRangeException("Выход за пределы массива");
            if (arr.Last() != null)
            {
                Expand(Capacity + DefaultLength);
            }
            for (int j = lastIndex; j > i; j--)
            {
                arr[j] = arr[j - 1] == null ? default(T) : arr[j - 1];
            }
            arr[i] = t;
            return true;
        }

        public T Get(int i)
        {
            return arr[i];
        }

        public void Set(int i, T t)
        {
            arr[i] = t;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public UnitEnum<T> GetEnumerator()
        {
            return new UnitEnum<T>(arr);
        }
    }

    public class UnitEnum<T> : IEnumerator
    {
        public T[] arr;

        static int position = 0;

        public UnitEnum(T[] list)
        {
            arr = list;
        }

        public bool MoveNext()
        {
            position++;
            return (position < arr.Length);
        }

        public void Reset()
        {
            position = 0;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public T Current
        {
            get
            {
                try
                {
                    return arr[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }

}
