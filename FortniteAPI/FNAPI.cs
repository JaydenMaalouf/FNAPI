using System;
using System.Net;
using System.Threading.Tasks;

using RestSharp;

using FortniteAPI.Enums;
using FortniteAPI.Classes;
using FortniteAPI.Interfaces;
using FortniteAPI.Managers.Interfaces;
using FortniteAPI.Endpoints.Status;
using FortniteAPI.Endpoints.Patchnotes;
using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI
{
    public class FNAPI : IFNAPI
    {
        private static string APIKey;

        private static WebClient webClient = new WebClient();
        private static RestClient restClient = new RestClient("https://fortnite-public-api.theapinetwork.com/prod09/");

        public IFNBRManager BR => new FNBRManager();
        public IFNSTWManager STW => new FNSTWManager();
        public IStatusEndpoint Status => new StatusEndpoint();
        public IPatchnotesEndpoint Patchnotes => new PatchnotesEndpoint();

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
            var status = BR.Challenges.GetChallengesAsync().Result;
            if (status != null)
            {
                return status.CurrentWeek;
            }
            return FNWeek.WEEK_UNKNOWN;
        }

        public string GetCurrentVersion()
        {
            var status = Status.GetStatusAsync().Result;
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
