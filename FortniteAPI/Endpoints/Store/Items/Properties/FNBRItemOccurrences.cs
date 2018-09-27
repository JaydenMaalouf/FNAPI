using System.Collections.Generic;

using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRItemOccurrences
    {
        internal FNBRItemOccurrences() { }

        [JsonProperty]
        public string First { get; internal set; }
        [JsonProperty]
        public string Last { get; internal set; }
        [JsonProperty]
        public int Occurrences { get; internal set; }
        [JsonProperty]
        public List<FNBRItemOccurrencesEntry> Entries { get; internal set; }
    }
}
