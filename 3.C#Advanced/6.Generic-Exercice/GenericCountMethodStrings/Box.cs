using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>: IComparable
    where T : IComparable
    {
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public override string ToString()
        {
            string typeFullName = Value.GetType().ToString();
            return $"{typeFullName}: {Value}";
        }

        public int CompareTo(object obj)
        {
            Box<T> box = obj as Box<T>;
            int compare = this.Value.CompareTo(box.Value);

            return compare;

        }
    }
}
