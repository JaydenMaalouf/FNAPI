using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

using FluentScheduler;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Interfaces;
using FortniteAPI.Endpoints.Store.Items;

namespace FortniteAPI.Endpoints.Store
{
    public class StoreEndpoint : IStoreEndpoint
    {
        internal Registry StoreUpdatedScheduler = new Registry();

        internal StoreEndpoint()
        {
            var timeOfDay = DateTime.Today.AddDays(1).Add(DateTimeOffset.Now.Offset).TimeOfDay;
            StoreUpdatedScheduler.Schedule(async () =>
            {
                if (StoreUpdated != null && StoreUpdated.GetInvocationList().Length > 0)
                {
                    var store = await GetStoreAsync();
                    await StoreUpdated(store);
                }
            }).ToRunEvery(1).Days().At(timeOfDay.Hours, timeOfDay.Minutes);
            JobManager.Initialize(StoreUpdatedScheduler);
        }

        public event StoreUpdatedHandler StoreUpdated;

        public async Task<FNBRStore> GetStoreAsync()
        {
            var request = new RestRequest("store/get", Method.GET);
            request.AddParameter("language", "en");
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNBRStore>(response.Content);
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

        public async Task<FNBRItem> GetItemAsync(UID UniqueId)
        {
            var request = new RestRequest("item/get", Method.GET);
            request.AddParameter("ids", UniqueId.UIDToString());
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNBRItem>(response.Content);
        }

        public async Task<List<FNBRStoreItem>> GetUpcomingItemsAsync()
        {
            var request = new RestRequest("upcoming/get", Method.GET);
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
