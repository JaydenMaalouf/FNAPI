using System;
using System.Net;
using System.Threading.Tasks;

using RestSharp;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;
using FortniteAPI.Endpoints.User;
using FortniteAPI.Endpoints.Status;
using FortniteAPI.Endpoints.Patchnotes;
using FortniteAPI.Endpoints.Interfaces;
using FortniteAPI.Managers.Interfaces;

namespace FortniteAPI
{
    public class FNAPI : IFNAPI
    {
        private static string APIKey;
        private static FNLanguage Language;

        private static WebClient webClient = new WebClient();
        private static RestClient restClient = new RestClient("https://fortnite-public-api.theapinetwork.com/prod09/");

        public IFNBRManager BR => new FNBRManager();
        public IFNSTWManager STW => new FNSTWManager();
        public IStatusEndpoint Status => new StatusEndpoint();
        public IPatchnotesEndpoint Patchnotes => new PatchnotesEndpoint();

        public FNAPI(string _APIKey, FNLanguage _Language = FNLanguage.EN)
        {
            APIKey = _APIKey;
            Language = _Language;
        }

        //Use custom BaseURL
        public FNAPI(string _APIKey, string _BaseURL, FNLanguage _Language = FNLanguage.EN)
        {
            APIKey = _APIKey;
            Language = _Language;
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
            return new FNUser(username);
        }

        public FNUser GetUser(UID UniqueId)
        {
            return new FNUser(UniqueId);
        }

        internal static async Task<string> SendWebRequestAsync(string request)
        {
            return await webClient.DownloadStringTaskAsync(request).ConfigureAwait(false);
        }

        internal static async Task<IRestResponse> SendRestRequestAsync(RestRequest request)
        {
            request.AddHeader("Authorization", APIKey);
            request.AddParameter("language", Language.ToString().ToLower());
            return await restClient.ExecuteTaskAsync(request).ConfigureAwait(false);
        }
    }
}
