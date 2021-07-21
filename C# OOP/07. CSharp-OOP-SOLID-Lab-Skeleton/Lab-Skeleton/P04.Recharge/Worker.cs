namespace P04.Recharge
{
    public abstract class Worker
    {
        private string id;
        protected int workingHours;

        public Worker(string id)
        {
            this.id = id;
        }

        public abstract void Work(int hours);
    }
}