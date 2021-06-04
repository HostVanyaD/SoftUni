using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("text.txt"))
            {
                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    if (counter % 2 == 0)
                    {
                        Regex pattern = new Regex(@"[-.,!?]");
                        line = pattern.Replace(line, "@");
                        var reversed = line.Split().ToArray().Reverse();
                        Console.WriteLine(string.Join(" ", reversed));
                    }
                    counter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}
