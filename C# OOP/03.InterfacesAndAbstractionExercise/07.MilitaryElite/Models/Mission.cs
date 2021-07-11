using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string codeName, MissionStateEnum missionStatesEnum)
        {
            CodeName = codeName;
            MissionState = missionStatesEnum;
        }

        public string CodeName { get; }

        public MissionStateEnum MissionState { get; private set; }

        public void CompleteMission()
        {
            MissionState = MissionStateEnum.Finished;
        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {MissionState}";
        }
    }
}
