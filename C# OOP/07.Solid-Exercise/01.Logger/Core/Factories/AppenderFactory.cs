
namespace _01.Logger.Core.Factories
{
    using System;
    using Appenders;
    using Layouts;
    using Loggers;
    using Enumerations;

    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevelEnum reportLevel)
        {
            IAppender appender;

            switch (type)
            {
                case nameof(ConsoleAppender):
                    appender = new ConsoleAppender(layout) { ReportLevel = reportLevel };
                    break;

                case nameof(FileAppender):
                    appender = new FileAppender(layout, new LogFile()) { ReportLevel = reportLevel };
                    break;

                default:
                    throw new ArgumentException($"{type} is invalid Appender type");
            }

            return appender;
        }
    }
}
