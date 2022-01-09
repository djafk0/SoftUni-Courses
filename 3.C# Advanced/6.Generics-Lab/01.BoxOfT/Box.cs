using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly List<T> elements;
        public int Count
        {
            get
            {
                return elements.Count;
            }
        }

        public Box()
        {
            elements = new List<T>();
        }
        public void Add(T element)
        {
            elements.Add(element);
        }

        public T Remove()
        {
            T result = elements.LastOrDefault();
            elements.Remove(result);

            return result;
        }
    }
}
