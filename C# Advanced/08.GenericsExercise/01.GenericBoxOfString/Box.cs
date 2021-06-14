using System.Collections.Generic;

namespace _01.GenericBoxOfString
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
            return $"{this.Value.GetType()}: {Value}";
        }
    }
}
