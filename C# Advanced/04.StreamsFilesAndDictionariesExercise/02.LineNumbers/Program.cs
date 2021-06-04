using System;
using System.IO;
using System.Linq;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("text.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];
                int lettersCount = CountOfLetters(currentLine);
                int punctuationMarksCount = CountOfMarks(currentLine);

                Console.WriteLine($"Line {i + 1}: {currentLine} ({lettersCount})({punctuationMarksCount})");
            }
        }

        private static int CountOfMarks(string line)
        {
            int count = 0;
            char[] puncMarks = { '-', ',', '.', '?', '!', '\'' };

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (puncMarks.Contains(currentChar))
                {
                    count++;
                }
            }
            return count;
        }

        private static int CountOfLetters(string line)
        {
            int count = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (char.IsLetter(currentChar))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
