using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodStrings
{
    public class Box<T>
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
    }
}
