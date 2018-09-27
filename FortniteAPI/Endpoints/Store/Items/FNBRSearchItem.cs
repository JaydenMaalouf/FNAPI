using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRSearchItem : FNBRItem
    {
        internal FNBRSearchItem() { }

        [JsonProperty]
        public FNBRItemObtained Obtained { get; internal set; }
    }
}
