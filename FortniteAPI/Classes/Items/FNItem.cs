using Newtonsoft.Json;

namespace FortniteAPI.Classes.Items
{
    public class FNItem
    {
        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        public UID ItemID { get; internal set; }
        [JsonProperty]
        public string Name { get; internal set; }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID Identifier { set { ItemID = value; } }
    }
}
