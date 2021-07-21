using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public interface IEmployee
    {
        public string Name { get; set; }
        public void GetDetails();
    }
}
