using System;
using System.IO;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader text = new StreamReader("input.txt"))
            {
                string line = await text.ReadLineAsync();
                int currentLine = 1;

                using (StreamWriter wrt = new StreamWriter("output.txt"))
                {
                    while (line != null)
                    {
                        await wrt.WriteLineAsync($"{currentLine}. {line}");
                        currentLine++;
                        line = await text.ReadLineAsync();
                    }
                }
            }
        }
    }
}
