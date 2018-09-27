using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRItemOccurrencesEntry
    {
        internal FNBRItemOccurrencesEntry() { }

        [JsonProperty]
        public string Date { get; internal set; }
        [JsonProperty]
        public int Cost { get; internal set; }
        [JsonProperty]
        public bool Featured { get; internal set; }
    }
}
