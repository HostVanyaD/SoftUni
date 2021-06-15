using System;
using System.Collections.Generic;

namespace _05.GenericCountMethodString
{
    public class Box<T> : IComparable<T>
    where T : IComparable<T>
    {
        public T Value { get; set; }

        public Box(T value)
        {
            this.Value = value;
        }

        public int CompareTo(T other)
        {
            return this.Value.CompareTo(other);
        }

        public override string ToString()
        {
            return $"{this.Value.GetType()}: {this.Value}";
        }


    }
}
