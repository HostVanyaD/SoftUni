using _08.CollectionHierarchy.Models;
using System;
using System.Collections.Generic;

namespace _08.CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var addCollection = new AddRemoveCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                Console.Write($"{addCollection.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write($"{addRemoveCollection.Add(item)} ");
            }
            Console.WriteLine();

            foreach (var item in input)
            {
                Console.Write($"{myList.Add(item)} ");
            }
            Console.WriteLine();

            int countOfItemsToRemove = int.Parse(Console.ReadLine());
            List<string> removedItemsFromAddRemoveCollection = new List<string>();
            List<string> removedItemsFromMyList = new List<string>();

            for (int i = 0; i < countOfItemsToRemove; i++)
            {
                removedItemsFromAddRemoveCollection.Add(addRemoveCollection.Remove());
                removedItemsFromMyList.Add(myList.Remove());
            }

            Console.WriteLine(string.Join(" ", removedItemsFromAddRemoveCollection));
            Console.WriteLine(string.Join(" ", removedItemsFromMyList));
        }
    }
}
