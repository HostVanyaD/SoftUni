using System;
using System.IO;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader text = new StreamReader("input.txt"))
            {
                string line = await text.ReadLineAsync();
                int currentLine = 0;

                while (line != null)
                {
                    if (currentLine % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                    currentLine++;
                    line = await text.ReadLineAsync();
                }
            }
        }
    }
}
