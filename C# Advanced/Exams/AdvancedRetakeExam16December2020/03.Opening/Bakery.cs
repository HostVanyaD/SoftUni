using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        public List<Employee> data = new List<Employee>();
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
        }

        public void Add(Employee employee)
        {
            if (Capacity > data.Count)
            {
                data.Add(employee);
            }
        }

        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                Employee findEmployee = data.Find(x => x.Name == name);
                data.Remove(findEmployee);
                return true;
            }

            return false;
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(e => e.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            return data.FirstOrDefault(e => e.Name == name);
        }

        public string Report()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Employees working at Bakery {this.Name}:");
            foreach (var employee in data)
            {
                result.AppendLine(employee.ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
