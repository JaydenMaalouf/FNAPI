using System.Collections.Generic;

using Newtonsoft.Json;

using FortniteAPI.Endpoints.Store.Items;

namespace FortniteAPI.Endpoints.Store
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
    }
}
