using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class Family
    {
        List<Person> members { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            members.Add(member);
        }

        public Person GetOldestMember()
        {
            return members.OrderByDescending(m => m.Age).FirstOrDefault();
        }
    }
}
