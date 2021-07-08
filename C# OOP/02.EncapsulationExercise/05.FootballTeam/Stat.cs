using System;

namespace _05.FootballTeam
{
    public class Stat
    {
        private const int MinStatLevel = 0;
        private const int MaxStatLevel = 100;

        private string name;
        private int level;

        public Stat(string name, int level)
        {
            this.Name = name;
            this.Level = level;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int Level
        {
            get { return this.level; }
            set
            {
                if (value < MinStatLevel || value > MaxStatLevel)
                {
                    throw new ArgumentException($"{this.Name} should be between {MinStatLevel} and {MaxStatLevel}.");
                }
                this.level = value;
            }
        }
    }
}
