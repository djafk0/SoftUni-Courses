using System;

namespace GenericBoxOfStrings
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
            string typeName = Value.GetType().ToString();
            return $"{typeName}: {this.Value}";
        }
    }
}
