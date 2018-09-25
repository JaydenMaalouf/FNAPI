using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using RestSharp;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Interfaces;
using FortniteAPI.Endpoints.Leaderboard.Items;

namespace FortniteAPI.Endpoints.Leaderboard
{
    public class LeaderboardEndpoint : ILeaderboardEndpoint
    {
        internal LeaderboardEndpoint() { }
        
        public async Task<List<FNBRLeaderboardItem>> GetLeaderboardAsync(FNLeaderboardType leaderboardType, int userCount)
        {
            if (userCount > 0 && userCount <= 100)
            {
                var request = new RestRequest("leaderboards/worldwide", Method.GET);
                request.AddParameter("window", leaderboardType.ToString().ToLower());
                request.AddParameter("users_per_page", userCount.ToString());
                IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    return null;
                }

                return JObject.Parse(response.Content)["entries"].ToObject<List<FNBRLeaderboardItem>>();
            }
            return null;
        }
    }
}
