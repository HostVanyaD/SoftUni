using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                //Blue -> dress,jeans,hat
                string[] input = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] items = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (clothes.ContainsKey(color) == false)
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                AddClothes(clothes, color, items);
            }

            string[] outfit = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string outfitColor = outfit[0];
            string outfitClothing = outfit[1];

            PrintResult(clothes, outfitColor, outfitClothing);
        }

        private static void PrintResult(Dictionary<string, Dictionary<string, int>> clothes, string outfitColor, string outfitClothing)
        {
            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var item in color.Value)
                {
                    if (color.Key == outfitColor && item.Key == outfitClothing)
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {item.Key} - {item.Value}");
                    }
                }
            }
        }

        private static void AddClothes(Dictionary<string, Dictionary<string, int>> clothes, string color, string[] items)
        {
            foreach (string item in items)
            {
                if (clothes[color].ContainsKey(item))
                {
                    clothes[color][item]++;
                }
                else
                {
                    clothes[color].Add(item, 1);
                }
            }
        }
    }
}
