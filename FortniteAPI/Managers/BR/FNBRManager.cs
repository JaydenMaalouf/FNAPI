using FortniteAPI.Endpoints.News;
using FortniteAPI.Endpoints.Store;
using FortniteAPI.Endpoints.Challenges;
using FortniteAPI.Endpoints.Leaderboard;
using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Managers.Interfaces
{
    class FNBRManager : IFNBRManager
    {
        internal FNBRManager() {}

        public IChallengesEndpoint Challenges => new ChallengesEndpoint();
        public ILeaderboardEndpoint Leaderboard => new LeaderboardEndpoint();
        public INewsEndpoint News => new BRNewsEndpoint();
        public IStoreEndpoint Store => new StoreEndpoint();
    }
}
