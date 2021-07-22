namespace AuthorProblem
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {            
            Type[] allTypes = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t == typeof(StartUp))
                .ToArray();

            foreach (var type in allTypes)
            {
                var methods = type.GetMethods((BindingFlags)60);
                PrintMethodsAttribute(methods);
            }
        }

        private static void PrintMethodsAttribute(MethodInfo[] methods)
        {
            foreach (var method in methods)
            {
                if (method.GetCustomAttributes().Any(a => a.GetType() == typeof(AuthorAttribute)) == false)
                {
                    continue;
                }

                Attribute[] allAttributes = method.GetCustomAttributes().ToArray();

                foreach (var attribute in allAttributes)
                {
                    if (attribute is AuthorAttribute)
                    {
                        AuthorAttribute author = (AuthorAttribute)attribute;
                        Console.WriteLine($"{method.Name} is written by {author.Name}");
                    }
                }
            }
        }
    }
}
