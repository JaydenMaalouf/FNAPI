using System.Threading.Tasks;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Challenges;

namespace FortniteAPI.Endpoints.Interfaces
{
    public interface IChallengesEndpoint
    {
        Task<FNChallenges> GetChallengesAsync(FNSeason season = FNSeason.CURRENT);
    }
}
