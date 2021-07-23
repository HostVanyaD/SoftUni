namespace ValidationAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
