using System.Collections.Generic;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Classes.Items;

namespace FortniteAPI.Classes
{
    public class FNNews
    {
        [JsonProperty("typesm")]
        public FNGameMode Gamemode { get; internal set; }
        [JsonProperty]
        public List<FNNewsItem> Entries { get; internal set; }
    }
}
