using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using RestSharp;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Every;

using FortniteAPI.Enums;
using FortniteAPI.Classes;
using FortniteAPI.Classes.Items;
using FortniteAPI.Extensions;

namespace FortniteAPI
{
    public class BRManager : FNExtensions
    {
        public delegate Task StoreUpdatedHandler(FNBRStore store);
        public event StoreUpdatedHandler StoreUpdated;

        public BRManager()
        {
            Ever.y().Day.At(DateTimeOffset.Now.Offset).Do(async () =>
            {
                var store = await GetStoreAsync();
                await StoreUpdated(store);
            });
        }

        public async Task<FNNews> GetNewsAsync() => await Task.FromResult(GetNews());
        private FNNews GetNews()
        {
            var request = new RestRequest("br_motd/get", Method.POST);
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNNews>(response.Content);            
        }

        public async Task<FNChallenges> GetChallengesAsync(FNSeason? season = FNSeason.SEASON5) => await Task.FromResult(GetChallenges(season));
        private FNChallenges GetChallenges(FNSeason? season = FNSeason.SEASON5)
        {
            var request = new RestRequest("challenges/get", Method.POST);
            request.AddParameter("language", "en");
            request.AddParameter("season", season.ToString().ToLower());
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNChallenges>(response.Content);
        }

        public async Task<FNBRStore> GetStoreAsync() => await Task.FromResult(GetStore());
        private FNBRStore GetStore()
        {
            var request = new RestRequest("store/get", Method.POST);
            request.AddParameter("language", "en");
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNBRStore>(response.Content);
        }

        public async Task<List<FNBRLeaderboardItem>> GetLeaderboardAsync(FNLeaderboardType type = FNLeaderboardType.TOP_10_WINS) => await Task.FromResult(GetLeaderboard(type));
        private List<FNBRLeaderboardItem> GetLeaderboard(FNLeaderboardType type = FNLeaderboardType.TOP_10_WINS)
        {
            var request = new RestRequest("leaderboards/get", Method.POST);
            request.AddParameter("window", type.ToString().ToLower());
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JObject.Parse(response.Content)["entries"].ToObject<List<FNBRLeaderboardItem>>();
        }

        public async Task<FNBRItem> GetItemAsync(UID UID) => await Task.FromResult(GetItem(UID));
        private FNBRItem GetItem(UID UID)
        {
            var request = new RestRequest("item/get", Method.POST);
            request.AddParameter("ids", UID.GetUID());
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNBRItem>(response.Content);
        }
    }

    public class STWManager
    {
        public async Task<FNNews> GetNewsAsync() => await Task.FromResult(GetNews());
        private FNNews GetNews()
        {
            var request = new RestRequest("stw_motd/get", Method.POST);
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNNews>(response.Content);
        }
    }
    
    public class FNAPI : FNExtensions
    {
        public static string APIKey;
        public BRManager BR = new BRManager();
        public STWManager STW = new STWManager();

        private static RestClient client = new RestClient("https://fortnite-public-api.theapinetwork.com/prod09/");

        public FNAPI(string _APIKey)
        {
            APIKey = _APIKey;
        }

        //Use custom BaseURL
        public FNAPI(string _APIKey, string _BaseURL)
        {
            APIKey = _APIKey;
            client.BaseUrl = new Uri(_BaseURL);
        }
        
        public FNWeek GetCurrentWeek()
        {
            var status = BR.GetChallengesAsync().Result;
            if (status != null)
            {
                return status.CurrentWeek;
            }
            return FNWeek.WEEK_UNKNOWN;
        }

        public string GetCurrentVersion()
        {
            var status = GetStatus();
            return status.Version;
        }

        public FNSeason GetCurrentSeason()
        {
            var version = GetCurrentVersion();
            int index = version.IndexOf(".");
            if (index > 0)
            {
                var seasonString = version.Substring(0, index);
                var seasonInt = Int32.Parse(seasonString);

                return (FNSeason)seasonInt;
            }
            return FNSeason.SEASON_UNKNOWN;
        }

        public async Task<FNStatus> GetStatusAsync() => await Task.FromResult(GetStatus());
        private FNStatus GetStatus()
        {
            var request = new RestRequest("status/fortnite_server_status", Method.POST);
            IRestResponse response = SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNStatus>(response.Content);
        }

        public async Task<List<FNPatchnoteItem>> GetPatchnotesAsync() => await Task.FromResult(GetPatchnotes());
        private List<FNPatchnoteItem> GetPatchnotes()
        {
            var request = new RestRequest("patchnotes/get", Method.POST);
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JObject.Parse(response.Content)["blogList"].ToObject<List<FNPatchnoteItem>>();
        }

        public FNUser GetUser(string username)
        {
            return GetUser<FNUser>(username);
        }

        public FNUser GetUser(UID userID)
        {
            return GetUser<FNUser>(userID);
        }

        internal static IRestResponse SendRequest(RestRequest request)
        {
            request.AddHeader("Authorization", APIKey);
            return client.Execute(request);
        }
    }
}
