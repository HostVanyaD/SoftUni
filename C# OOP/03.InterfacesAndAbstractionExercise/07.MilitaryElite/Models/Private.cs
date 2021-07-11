using _07.MilitaryElite.Contracts;
using System;

namespace _07.MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        public Private(int id, string firstName, string lastName, decimal salary)
            :base(id, firstName, lastName)
        {
            Salary = salary;
        }

        public decimal Salary { get; }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {Math.Round(this.Salary, 2):F2}";
        }
    }
}
