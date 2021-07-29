using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields((BindingFlags)60);
            StringBuilder result = new StringBuilder();

            Object classInstance = Activator.CreateInstance(classType, new object[] { });

            result.AppendLine($"Class under investigation: {className}");

            foreach (var field in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return result.ToString().TrimEnd();
        }

        public string AnalyzeAccessModifiers(string className)
        {       
            Type classType = Type.GetType($"Stealer.{className}");

            var classFields = classType.GetFields((BindingFlags)24); //BindingFlags.Instance | BindingFlags.Public

            var classNonPublicMethods = classType
                .GetMethods((BindingFlags)36)      //BindingFlags.Instance | BindingFlags.NonPublic
                .Where(m => m.Name.StartsWith("get"));

            var classPublicMethods = classType
                .GetMethods((BindingFlags)24)
                .Where(m => m.Name.StartsWith("set"));

            StringBuilder result = new StringBuilder();

            foreach (var field in classFields)
            {
                result.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classNonPublicMethods)
            {
                result.AppendLine($"{method.Name} have to be public!");
            }

            foreach (var method in classPublicMethods)
            {
                result.AppendLine($"{method.Name} have to be private!");
            }

            return result.ToString().TrimEnd();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] classPrivateMethods = classType.GetMethods((BindingFlags)36);

            StringBuilder result = new StringBuilder();

            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var method in classPrivateMethods)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString().TrimEnd();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);

            MethodInfo[] classMethods = classType
                .GetMethods((BindingFlags)52);                

            StringBuilder result = new StringBuilder();

            foreach (var method in classMethods.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (var method in classMethods.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
