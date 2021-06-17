namespace _07.Tuple
{
    public class Tuple<TFirst, TSecond>
    {
        public TFirst Item1 { get; set; }
        public TSecond Item2 { get; set; }

        public Tuple(TFirst firstItem, TSecond secondItem)
        {
            this.Item1 = firstItem;
            this.Item2 = secondItem;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }
    }
}
