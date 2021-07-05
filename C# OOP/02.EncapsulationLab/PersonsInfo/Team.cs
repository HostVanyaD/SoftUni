using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private readonly string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        public string Name { get; private set; }
        public IReadOnlyList<Person> FirstTeam { get => firstTeam; }
        public IReadOnlyList<Person> ReserveTeam { get => reserveTeam; }

        public Team(string name)
        {
            Name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }

        }
    }
}
