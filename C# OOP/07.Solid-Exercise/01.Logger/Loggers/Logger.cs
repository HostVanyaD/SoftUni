namespace _01.Logger.Loggers
{
    using Appenders;
    using Enumerations;

    public class Logger : ILogger
    {
        private readonly IAppender[] appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }
        public void Critical(string date, string message)
        {
            AppendToAppenders(date, ReportLevelEnum.Critical, message);
        }

        public void Error(string date, string message)
        {
            AppendToAppenders(date, ReportLevelEnum.Error, message);
        }

        public void Fatal(string date, string message)
        {
            AppendToAppenders(date, ReportLevelEnum.Fatal, message);
        }

        public void Info(string date, string message)
        {
            AppendToAppenders(date, ReportLevelEnum.Info, message);
        }

        public void Warning(string date, string message)
        {
            AppendToAppenders(date, ReportLevelEnum.Warning, message);
        }

        private void AppendToAppenders(string date, ReportLevelEnum reportLevel, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }
    }
}
