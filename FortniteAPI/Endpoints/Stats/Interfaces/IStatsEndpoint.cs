using System.Threading.Tasks;

using FortniteAPI.Enums;
using FortniteAPI.Classes.Items;

namespace FortniteAPI.Endpoints.Interfaces
{
    public interface IStatsEndpoint
    {
        Task<FNBRStats> GetBRStatsAsync(FNPlatform platform = FNPlatform.PC, FNStatWindow window = FNStatWindow.ALLTIME);
        Task<FNBRStatsItem> GetBRStatsAsync(FNPlatform platform = FNPlatform.PC, FNStatWindow window = FNStatWindow.ALLTIME, FNBRGameMode gameMode = FNBRGameMode.ALL);
    }
}
