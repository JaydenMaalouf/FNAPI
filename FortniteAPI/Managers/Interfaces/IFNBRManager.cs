using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Managers.Interfaces
{
    public interface IFNBRManager
    {
        IChallengesEndpoint Challenges { get; }
        ILeaderboardEndpoint Leaderboard { get; }
        INewsEndpoint News { get; }
        IStoreEndpoint Store { get; }
    }
}
