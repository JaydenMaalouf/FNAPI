using System.Threading.Tasks;
using System.Collections.Generic;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Leaderboard.Items;

namespace FortniteAPI.Endpoints.Interfaces
{
    public interface ILeaderboardEndpoint
    {
        Task<List<FNBRLeaderboardItem>> GetLeaderboardAsync(FNLeaderboardType leaderboardType = FNLeaderboardType.KILLS, int userCount = 100);
    }
}
