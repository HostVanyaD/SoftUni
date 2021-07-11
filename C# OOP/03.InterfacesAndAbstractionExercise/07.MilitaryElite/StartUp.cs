using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumerations;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.MilitaryElite
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<ISoldier> allSoldiers = new List<ISoldier>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split(" ");

                string typeOfSoldier = command[0];
                int id = int.Parse(command[1]);
                string firstName = command[2];
                string lastName = command[3];
                decimal salary = decimal.Parse(command[4]);

                ISoldier soldier = default;

                if (typeOfSoldier is "Private")
                {
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (typeOfSoldier is "Spy")
                {
                    int codeNumber = int.Parse(command[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else if (typeOfSoldier is "LieutenantGeneral")
                {
                    ICollection<IPrivate> privates = new List<IPrivate>();

                    foreach (var privateId in command.Skip(5))
                    {
                        IPrivate currentPrivate = (IPrivate)allSoldiers
                            .First(p => p.Id == int.Parse(privateId));

                        privates.Add(currentPrivate);
                    }

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (typeOfSoldier is "Engineer")
                {
                    Enum.TryParse(command[5], false, out SoldierCorpEnum corp);
                    ICollection<IRepair> repairs = new List<IRepair>();

                    if (corp == default)
                    {
                        continue;
                    }

                    var repairTokens = command[6..];

                    for (int i = 0; i <= repairTokens.Length / 2; i += 2)
                    {
                        var partName = repairTokens[i];
                        var hoursWorked = int.Parse(repairTokens[i + 1]);
                        repairs.Add(new Repair(partName, hoursWorked));
                    }

                    soldier = new Engineer(id, firstName, lastName, salary, corp, repairs);
                }
                else if (typeOfSoldier is "Commando")
                {
                    Enum.TryParse(command[5], false, out SoldierCorpEnum corp);
                    ICollection<IMission> missions = new List<IMission>();

                    if (corp == default)
                    {
                        continue;
                    }

                    var missionTokens = command[6..];

                    for (int i = 0; i < missionTokens.Length - 1; i++)
                    {
                        var missionStateName = missionTokens[i + 1];
                        if (missionStateName != "inProgress" && missionStateName != "Finished")
                        {
                            continue;
                        }

                        var codeName = missionTokens[i];
                        Enum.TryParse(missionTokens[i + 1], false, out MissionStateEnum missionState);

                        if (missionState != default)
                        {
                            missions.Add(new Mission(codeName, missionState));
                        }
                    }

                    soldier = new Commando(id, firstName, lastName, salary, corp, missions);
                }

                allSoldiers.Add(soldier);
            }

            foreach (var soldier in allSoldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
