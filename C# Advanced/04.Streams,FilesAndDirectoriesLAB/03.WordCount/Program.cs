using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> output = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("words.txt"))
            {
                string[] words = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in words)
                {
                    output.Add(word.ToLower(), 0); //запазваме думата и брояч, който започва от 0
                }

                using (StreamReader readText = new StreamReader("text.txt"))
                {
                    string text = readText.ReadToEnd(); //четем текста докрай

                    foreach (Match m in Regex.Matches(text, @"[A-Za-z]+"))
                    {
                        string currentMatch = m.Value.ToLower();

                        for (int i = 0; i < words.Length; i++)
                        {
                            if (currentMatch == words[i])
                            {
                                output[currentMatch]++;
                            }
                        }
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (var word in output.OrderByDescending(x => x.Value))
                {
                    writer.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
