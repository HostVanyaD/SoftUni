namespace _01.Logger.Core
{
    using System;
    using System.Collections.Generic;
    using Appenders;
    using Layouts;
    using Enumerations;
    using Loggers;    
    using Core.Factories;    

    public class Engine
    {
        private readonly Dictionary<string, ILayout> layoutsByType;
        private readonly IAppenderFactory appenderFactory;

        public Engine(Dictionary<string, ILayout> layoutsByType, IAppenderFactory appenderFactory)
        {
            this.layoutsByType = layoutsByType;
            this.appenderFactory = appenderFactory;
        }

        public void Run()
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            IAppender[] appenders = ReadAllAppenders(numberOfAppenders);
            ILogger logger = new Logger(appenders);
            
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split('|');

                string reportLevelType = tokens[0];
                string date = tokens[1];
                string message = tokens[2];

                ReportLevelEnum reportLevel = Enum.Parse<ReportLevelEnum>(reportLevelType, true);

                switch (reportLevel)
                {
                    case ReportLevelEnum.Info: 
                        logger.Info(date, message);
                        break;

                    case ReportLevelEnum.Warning: 
                        logger.Warning(date, message);
                        break;

                    case ReportLevelEnum.Error: 
                        logger.Error(date, message);
                        break;

                    case ReportLevelEnum.Critical: 
                        logger.Critical(date, message);
                        break;

                    case ReportLevelEnum.Fatal:
                        logger.Fatal(date, message);
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine("Logger info");

            foreach (var appender in appenders)
            {
                Console.WriteLine(appender.ToString());
            }
        }

        private IAppender[] ReadAllAppenders(int numberOfAppenders)
        {
            IAppender[] appenders = new IAppender[numberOfAppenders];

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appeneders = Console.ReadLine().Split();

                string appenderType = appeneders[0];
                string layoutType = appeneders[1];
                ReportLevelEnum reportLevel = appeneders.Length == 3
                    ? Enum.Parse<ReportLevelEnum>(appeneders[2], true)
                    : ReportLevelEnum.Info;

                IAppender appender = appenderFactory.CreateAppender(appenderType, layoutsByType[layoutType], reportLevel);

                appenders[i] = appender;
            }

            return appenders;
        }
    }
}

