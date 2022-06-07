namespace P01_StudentSystem
{
    using P01_StudentSystem.Data;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.EnsureCreated();
        }
    }
}
