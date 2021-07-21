namespace _01.Logger.Appenders
{
    using System;
    using Layouts;
    using Enumerations;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) 
            : base(layout)
        {
        }

        public override void Append(string date, ReportLevelEnum reportLevel, string message)
        {
            if (CanAppend(reportLevel))
            {
                MessagesCount++;

                string content = string.Format(this.layout.Template, date, reportLevel, message);

                Console.WriteLine(content);
            }
        }
    }
}
