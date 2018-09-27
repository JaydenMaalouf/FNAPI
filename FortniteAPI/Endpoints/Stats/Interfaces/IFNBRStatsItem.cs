
namespace FortniteAPI.Endpoints.Stats.Interfaces
{
    public interface IFNBRStatsItem
    {
        int Kills { get; }
        int Wins { get; }
        double KD { get; }
        int MatchesPlayed { get; }
        int MinutesPlayed { get; }
        double Score { get; }
    }
}
