namespace _01.Logger.Appenders
{
    using Layouts;
    using Enumerations;
    using Loggers;

    public class FileAppender : Appender
    {
        private ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (CanAppend(reportLevel))
            {
                MessagesCount++;

                string content = string.Format(this.layout.Template, date, reportLevel, message);

                this.logFile.Write(content);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $", {this.logFile.Size}";
        }
    }
}
