namespace _01.Logger.Loggers
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string content);
    }
}
