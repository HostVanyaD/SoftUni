using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;

        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return data.Count;
            }
        }

        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }

        public void Add(Pet pet)
        {
            if (Capacity > data.Count)
            {
                data.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                var findPet = data.Find(x => x.Name == name);
                data.Remove(findPet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            return data.Find(p => p.Name == name && p.Owner == owner);
        }
       
        public Pet GetOldestPet()
        {
            return data.OrderByDescending(p => p.Age).FirstOrDefault();
        }
        
        public string GetStatistics()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("The clinic has the following patients:");
            foreach (var pet in data)
            {
                result.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
