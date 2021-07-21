namespace _01.Logger.Core.Factories
{
    using Layouts;
    using Appenders;
    using Enumerations;

    public interface IAppenderFactory
    {
        IAppender CreateAppender(string type, ILayout layout, ReportLevelEnum reportLevel);
    }
}
