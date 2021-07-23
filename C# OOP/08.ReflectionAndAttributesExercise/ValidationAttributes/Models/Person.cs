namespace ValidationAttributes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private const int _minAge = 12;
        private const int _maxAge = 90;

        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; private set; }

        [MyRange(_minAge, _maxAge)]
        public int Age { get; private set; }
    }
}
