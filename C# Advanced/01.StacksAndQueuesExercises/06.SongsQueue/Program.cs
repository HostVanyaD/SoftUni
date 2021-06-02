using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _06.SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Queue<String> songs = new Queue<string>(input);

            while (songs.Count > 0)
            {
                string command = Console.ReadLine();

                if (command.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (command.Contains("Add"))
                {
                    string newSong = command;
                    newSong = newSong.Remove(0, 4);

                    if (!songs.Contains(newSong))
                    {
                        songs.Enqueue(newSong);
                    }
                    else
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                }
                else if (command.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }

            Console.WriteLine("No more songs!");
        }
    }
}
