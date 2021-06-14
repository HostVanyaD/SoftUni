using System.Collections.Generic;

namespace _04.GenericSwapMethodInteger
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
            return $"{this.Value.GetType()}: {this.Value}";
        }
    }
}
