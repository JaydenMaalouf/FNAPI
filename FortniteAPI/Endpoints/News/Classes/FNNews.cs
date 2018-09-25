using System.Collections.Generic;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.News.Items;

namespace FortniteAPI.Endpoints.News
{
    public class FNNews
    {
        internal FNNews() { }

        [JsonProperty("typesm")]
        public FNGameMode Gamemode { get; internal set; }
        [JsonProperty]
        public List<FNNewsItem> Entries { get; internal set; }
    }
}
