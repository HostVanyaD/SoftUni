using System;
using System.Collections.Generic;

namespace _05.FootballTeam
{
    public class Program
    {
        private static Dictionary<string, Team> teams = new Dictionary<string, Team>();

        static void Main(string[] args)
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(';', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                string teamName = tokens[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            CreateNewTeam(teamName);
                            break;

                        case "Add":
                            AddNewPlayerToTeam(teamName, tokens);
                            break;

                        case "Remove":
                            var playerName = tokens[2];
                            RemovePlayerFromTeam(teamName, playerName);
                            break;

                        case "Rating":
                            ShowRating(teamName);
                            break;
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }                
            }
        }

        private static void CheckIfTeamExists(string teamName)
        {
            if (!teams.ContainsKey(teamName))
            {
                throw new InvalidOperationException($"Team {teamName} does not exist.");
            }
        }

        private static void ShowRating(string teamName)
        {
            CheckIfTeamExists(teamName);

            var team = teams[teamName];
            Console.WriteLine(team);
        }

        private static void RemovePlayerFromTeam(string teamName, string playerName)
        {
            CheckIfTeamExists(teamName);

            teams[teamName].RemovePlayer(playerName);
        }

        private static void AddNewPlayerToTeam(string teamName, string[] tokens)
        {
            CheckIfTeamExists(teamName);
            Player newPlayer = CreateNewPlayer(tokens);

            teams[teamName].AddPlayer(newPlayer);
        }

        private static Player CreateNewPlayer(string[] tokens)
        {
            return new Player
                                            (tokens[2],
                            new Stat("Endurance", int.Parse(tokens[3])),
                            new Stat("Sprint", int.Parse(tokens[4])),
                            new Stat("Dribble", int.Parse(tokens[5])),
                            new Stat("Passing", int.Parse(tokens[6])),
                            new Stat("Shooting", int.Parse(tokens[7])));
        }

        private static void CreateNewTeam(string name)
        {
            Team newTeam = new Team(name);
            teams.Add(name, newTeam);
        }
    }
}
