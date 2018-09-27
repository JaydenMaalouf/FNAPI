using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRLookupItem : FNBRItem
    {
        internal FNBRLookupItem() { }

        [JsonProperty("upcoming")]
        public bool IsUpcoming { get; internal set; }

        [JsonProperty("todaystore")]
        public bool InStoreCurrently { get; internal set; }

        [JsonProperty("set")]
        public FNBRItemSet ItemSet { get; internal set; }
    }
}
