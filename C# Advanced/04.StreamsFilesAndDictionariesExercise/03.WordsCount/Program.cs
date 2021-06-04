using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace _03.WordsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = File.ReadAllLines("words.txt");
            Dictionary<string, int> countOfWords = new Dictionary<string, int>();

            foreach (var word in words)
            {
                countOfWords.Add(word.ToLower(), 0);
            }

            string text = File.ReadAllText("text.txt");

            foreach (Match m in Regex.Matches(text, @"[A-Za-z]+"))
            {
                string currentMatch = m.Value.ToLower();

                for (int i = 0; i < words.Length; i++)
                {
                    if (currentMatch == words[i])
                    {
                        countOfWords[currentMatch]++;
                    }
                }
            }
            string actualResultPath = "actualResults.txt";
            string expectedResultPath = "expectedResult.txt";

            foreach (var word in countOfWords)
            {
                File.AppendAllText(actualResultPath, $"{word.Key} - {word.Value}{Environment.NewLine}");
            }

            foreach (var kvp in countOfWords.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(expectedResultPath, $"{kvp.Key} - {kvp.Value}{Environment.NewLine}");
            }
        }
    }
}
