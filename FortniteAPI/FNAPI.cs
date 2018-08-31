using System;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

using RestSharp;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Every;

using FortniteAPI.Enums;
using FortniteAPI.Classes;
using FortniteAPI.Classes.Items;
using FortniteAPI.Interfaces;

namespace FortniteAPI
{
    public class BRManager
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

        public async Task<FNNews> GetNewsAsync()
        {
            var request = new RestRequest("br_motd/get", Method.POST);
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNNews>(response.Content);            
        }

        public async Task<FNChallenges> GetChallengesAsync(FNSeason? season = FNSeason.SEASON5)
        {
            var request = new RestRequest("challenges/get", Method.POST);
            request.AddParameter("language", "en");
            request.AddParameter("season", season.ToString().ToLower());
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNChallenges>(response.Content);
        }
        
        public async Task<FNBRStore> GetStoreAsync()
        {
            var request = new RestRequest("store/get", Method.POST);
            request.AddParameter("language", "en");
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNBRStore>(response.Content);
        }

        public async Task<List<FNBRLeaderboardItem>> GetLeaderboardAsync(FNLeaderboardType type = FNLeaderboardType.TOP_10_WINS)
        {
            var request = new RestRequest("leaderboards/get", Method.POST);
            request.AddParameter("window", type.ToString().ToLower());
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JObject.Parse(response.Content)["entries"].ToObject<List<FNBRLeaderboardItem>>();
        }
        
        public async Task<FNBRItem> GetItemAsync(UID UID)
        {
            var request = new RestRequest("item/get", Method.POST);
            request.AddParameter("ids", UID.GetUID());
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNBRItem>(response.Content);
        }
    }

    public class STWManager
    {
        public async Task<FNNews> GetNewsAsync()
        {
            var request = new RestRequest("stw_motd/get", Method.POST);
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNNews>(response.Content);
        }
    }
    
    public class FNAPI
    {
        public static string APIKey;
        public BRManager BR = new BRManager();
        public STWManager STW = new STWManager();

        private static WebClient webClient = new WebClient();
        private static RestClient restClient = new RestClient("https://fortnite-public-api.theapinetwork.com/prod09/");

        public FNAPI(string _APIKey)
        {
            APIKey = _APIKey;
        }

        //Use custom BaseURL
        public FNAPI(string _APIKey, string _BaseURL)
        {
            APIKey = _APIKey;
            restClient.BaseUrl = new Uri(_BaseURL);
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
            var status = GetStatusAsync().Result;
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
        
        public async Task<FNStatus> GetStatusAsync()
        {
            var request = new RestRequest("status/fortnite_server_status", Method.POST);
            IRestResponse response = await SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNStatus>(response.Content);
        }
        
        public async Task<List<FNPatchnoteItem>> GetPatchnotesAsync()
        {
            var request = new RestRequest("patchnotes/get", Method.POST);
            IRestResponse response = await SendRestRequestAsync(request).ConfigureAwait(false);
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

        public T GetUser<T>(string username) where T : IFNUser
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { username });
        }

        public T GetUser<T>(UID userID) where T : IFNUser
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { userID });
        }

        internal static async Task<string> SendWebRequestAsync(string request)
        {
            return await webClient.DownloadStringTaskAsync(request).ConfigureAwait(false);
        }

        internal static async Task<IRestResponse> SendRestRequestAsync(RestRequest request)
        {
            request.AddHeader("Authorization", APIKey);
            return await restClient.ExecuteTaskAsync(request).ConfigureAwait(false);
        }
    }
}
