using System.Threading.Tasks;

using Newtonsoft.Json;

using RestSharp;

using FortniteAPI.Enums;
using FortniteAPI.Classes.Items;
using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Endpoints.Stats
{
    public class StatsEndpoint : IStatsEndpoint
    {
        internal UID UserId;

        internal StatsEndpoint(IFNUser _user)
        {
            UserId = _user.UserId;
        }

        public async Task<FNBRStats> GetBRStatsAsync(FNPlatform platform = FNPlatform.PC, FNStatWindow window = FNStatWindow.ALLTIME)
        {
            var request = new RestRequest("users/public/br_stats", Method.GET);
            request.AddParameter("user_id", UserId.ToString());
            request.AddParameter("platform", platform.ToString().ToLower());
            request.AddParameter("window", window.ToString().ToLower());

            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            var tempUser = JsonConvert.DeserializeObject<FNBRTempUser>(response.Content);
            if (tempUser == null)
            {
                return null;
            }

            return new FNBRStats(tempUser);
        }

        public async Task<FNBRStatsItem> GetBRStatsAsync(FNBRGameMode gameMode, FNPlatform platform = FNPlatform.PC, FNStatWindow window = FNStatWindow.ALLTIME)
        {
            var stats = await GetBRStatsAsync(platform, window);

            switch (gameMode)
            {
                case FNBRGameMode.SOLO:
                    return stats.Solo;
                case FNBRGameMode.DUO:
                    return stats.Duo;
                case FNBRGameMode.SQUAD:
                    return stats.Squad;
            }
            return stats.Overall;
        }
    }
}
