using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : IEmployee
    {
        public Manager(string name, ICollection<string> documents)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }
        public string Name { get; set; }

        public void GetDetails()
        {
            Console.WriteLine(this.Name);
            Console.WriteLine(string.Join(Environment.NewLine, this.Documents));
        }
    }
}
