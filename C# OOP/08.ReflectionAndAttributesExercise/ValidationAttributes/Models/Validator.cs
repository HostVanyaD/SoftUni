namespace ValidationAttributes
{
    using System.Linq;
    using System.Reflection;
    
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] objProperties = obj.GetType().GetProperties();

            foreach (var property in objProperties)
            {
                MyValidationAttribute[] allAttributes = property
                    .GetCustomAttributes(true)
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach (var attribute in allAttributes)
                {
                    if (attribute.IsValid(property.GetValue(obj)) == false)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
