using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRFeaturedItemImages
    {
        [JsonProperty]
        public string Background { get; internal set; }
        [JsonProperty]
        public string Transparent { get; internal set; }
    }
}
