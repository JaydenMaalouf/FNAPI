using System.Collections.Generic;

using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRItemSet
    {
        internal FNBRItemSet() { }

        [JsonProperty]
        public string Name { get; internal set; }

        [JsonProperty]
        public List<FNItem> Entries { get; internal set; }
    }
}
