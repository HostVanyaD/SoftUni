namespace _01.Logger.Appenders
{
    using Enumerations;
    using Layouts;
    
    public abstract class Appender : IAppender
    {
        protected readonly ILayout layout;

        public Appender(ILayout layout)
        {
            this.layout = layout;
        }

        public ReportLevelEnum ReportLevel { get; set; }

        protected int MessagesCount { get; set; }

        public abstract void Append(string date, ReportLevelEnum reportLevel, string message);

        protected bool CanAppend(ReportLevelEnum reportLevel)
        {
            return reportLevel >= ReportLevel;
        }

        public override string ToString()
        {
            return $"Appender type: {GetType().Name}, Layout type: {layout.GetType().Name}, " +
                $"Report level: {ReportLevel}, Messages appended: {MessagesCount}";
        }
    }
}
