namespace _08.Threeuple
{
    public class Threeuple<TFirst, TSecond, TThird>
    {
        public TFirst Item1 { get; set; }
        public TSecond Item2 { get; set; }
        public TThird Item3 { get; set; }

        public Threeuple(TFirst firstItem, TSecond secondItem, TThird thirdItem)
        {
            this.Item1 = firstItem;
            this.Item2 = secondItem;
            this.Item3 = thirdItem;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }
    }
}
