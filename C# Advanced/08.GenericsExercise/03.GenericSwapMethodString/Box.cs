using System.Collections.Generic;

namespace _03.GenericSwapMethodString
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
