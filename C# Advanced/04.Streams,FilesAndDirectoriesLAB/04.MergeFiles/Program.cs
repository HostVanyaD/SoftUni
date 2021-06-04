using System;
using System.IO;

namespace _04.MergeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader read1 = new StreamReader("FileOne.txt"))
            {
                using (StreamReader read2 = new StreamReader("FileTwo.txt"))
                {
                    string line1 = read1.ReadLine();
                    string line2 = read2.ReadLine();

                    using (StreamWriter writer = new StreamWriter("output.txt"))
                    {
                        while (line1 != null & line2 != null)
                        {
                            writer.WriteLine(line1);
                            writer.WriteLine(line2);
                            line1 = read1.ReadLine();
                            line2 = read2.ReadLine();
                        }
                    }
                }
            }
        }
    }
}
