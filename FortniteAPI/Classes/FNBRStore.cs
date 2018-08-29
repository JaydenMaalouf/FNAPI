using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

using RestSharp;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using FortniteAPI.Enums;
using FortniteAPI.Classes.Items;

namespace FortniteAPI.Classes
{
    public class FNBRStore
    {
        [JsonProperty]
        public List<FNBRStoreItem> Items { get; internal set; }

        public List<FNBRStoreItem> GetFeaturedStore()
        {
            return Items.FindAll(x => x.Featured == true);
        }

        public List<FNBRStoreItem> GetDailyStore()
        {
            return Items.FindAll(x => x.Featured == false);
        }

        public async Task<List<FNBRItem>> SearchAsync(string name, FNBRItemRarity? rarity = null) => await Task.FromResult(Search(name, rarity));
        private List<FNBRItem> Search(string name, FNBRItemRarity? rarity = null)
        {
            var client = new WebClient();
            var content = client.DownloadString("https://fortnite-public-files.theapinetwork.com/search?query=name:" + name + (rarity != null ? ";rarity:" + rarity.ToString().ToLower() : ""));

            try
            {
                return JsonConvert.DeserializeObject<List<FNBRItem>>(content);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<FNBRStoreItem>> GetUpcomingItemsAsync() => await Task.FromResult(GetUpcomingItems());
        private List<FNBRStoreItem> GetUpcomingItems()
        {
            var request = new RestRequest("upcoming/get", Method.POST);
            request.AddParameter("language", "en");

            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JObject.Parse(response.Content)["items"].ToObject<List<FNBRStoreItem>>();
        }
    }
}
