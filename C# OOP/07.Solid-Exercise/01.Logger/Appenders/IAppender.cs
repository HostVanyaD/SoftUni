namespace _01.Logger.Appenders
{
    using Enumerations;

    public interface IAppender
    {
        public void Append(string date, ReportLevelEnum reportLevel, string message);
    }
}
