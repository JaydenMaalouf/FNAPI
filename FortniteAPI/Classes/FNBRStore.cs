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
        internal FNBRStore() {}

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
        
        public async Task<List<FNBRSearchItem>> SearchAsync(string name, FNBRItemRarity? rarity = null)
        {
            var content = await FNAPI.SendWebRequestAsync("https://fortnite-public-files.theapinetwork.com/search?query=name:" + name + (rarity != null ? ";rarity:" + rarity.ToString().ToLower() : "")).ConfigureAwait(false);

            try
            {
                return JsonConvert.DeserializeObject<List<FNBRSearchItem>>(content);
            }
            catch
            {
                return null;
            }
        }

        public async Task<List<FNBRStoreItem>> GetUpcomingItemsAsync()
        {
            var request = new RestRequest("upcoming/get", Method.POST);
            request.AddParameter("language", "en");

            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JObject.Parse(response.Content)["items"].ToObject<List<FNBRStoreItem>>();
        }
    }
}
