using _07.MilitaryElite.Enumerations;

namespace _07.MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        MissionStateEnum MissionState { get; }

        void CompleteMission();
    }
}
