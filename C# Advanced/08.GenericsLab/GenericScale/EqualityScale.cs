using System.Collections.Generic;

namespace GenericScale
{
    public class EqualityScale<T>
    {
        public T Right { get; set; }
        public T Left { get; set; }

        public EqualityScale(T right, T left)
        {
            this.Right = right;
            this.Left = left;
        }

        public bool AreEqual()
        {
            return Right.Equals(Left);
        }
    }
}
