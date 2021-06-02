using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            Dictionary<string, List<string>> vloggerFollowers = new Dictionary<string, List<string>>(); // влогъра и неговите последователи
            Dictionary<string, List<string>> vloggerFollowings = new Dictionary<string, List<string>>();//влогъра и листа който той следва

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input.Contains("joined The V-Logger") && vloggerFollowers.ContainsKey(tokens[0]) == false)
                {
                    vloggerFollowers.Add(tokens[0], new List<string>());
                    vloggerFollowings.Add(tokens[0], new List<string>());
                }
                else if (input.Contains("followed"))
                {
                    string follower = tokens[0];
                    string vlogger = tokens[2];

                    if (vloggerFollowers.ContainsKey(vlogger) == false || vloggerFollowers.ContainsKey(follower) == false ||
                        vlogger == follower || vloggerFollowers[vlogger].Contains(follower))
                    {
                        continue;
                    }

                    vloggerFollowers[vlogger].Add(follower);
                    vloggerFollowings[follower].Add(vlogger);
                }
            }

            Console.WriteLine($"The V-Logger has a total of {vloggerFollowers.Count} vloggers in its logs.");

            vloggerFollowers = vloggerFollowers
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => vloggerFollowings[x.Key].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            int count = 1;

            Console.WriteLine($"{count}. {vloggerFollowers.First().Key} : {vloggerFollowers.First().Value.Count} followers, " +
                $"{vloggerFollowings[vloggerFollowers.First().Key].Count} following");

            foreach (var follower in vloggerFollowers.First().Value.OrderBy(x => x))
            {
                Console.WriteLine($"*  {follower}");
            }

            foreach (var vlogger in vloggerFollowers.Skip(1))
            {
                count++;
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value.Count} followers, {vloggerFollowings[vlogger.Key].Count} following");
            }
        }
    }
}
