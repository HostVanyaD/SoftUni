namespace _01.Logger
{    
    using System.Collections.Generic;
    using Core;
    using Layouts;
    using Core.Factories;

    public class StartUp
    {
        static void Main(string[] args)
        {

            Dictionary<string, ILayout> layoutsByType = new Dictionary<string, ILayout>
            {
                {nameof(SimpleLayout), new SimpleLayout() },
                {nameof(XmlLayout), new XmlLayout() },
                {nameof(JsonLayout), new JsonLayout() }
            };

            IAppenderFactory appenderFactory = new AppenderFactory();

            Engine engine = new Engine(layoutsByType, appenderFactory);
            engine.Run();
        }
    }
}
