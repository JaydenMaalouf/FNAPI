using System.Threading.Tasks;

using Newtonsoft.Json;

using RestSharp;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Endpoints.Challenges
{
    public class ChallengesEndpoint : IChallengesEndpoint
    {
        internal ChallengesEndpoint() { }

        public async Task<FNChallenges> GetChallengesAsync(FNSeason? season = FNSeason.CURRENT)
        {
            var request = new RestRequest("challenges/get", Method.GET);
            request.AddParameter("language", "en");
            request.AddParameter("season", season.ToString().ToLower());
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNChallenges>(response.Content);
        }
    }
}
