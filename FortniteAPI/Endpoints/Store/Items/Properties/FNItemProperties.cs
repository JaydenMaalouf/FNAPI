using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNItemProperties : IFNItemProperties
    {
        internal FNItemProperties() { }

        [JsonProperty("type")]
        public FNBRItemType ItemType { get; internal set; }
        [JsonProperty]
        public FNBRItemRarity Rarity { get; internal set; }

        [JsonProperty("image")]
        public string ImageURL { get; internal set; }
        [JsonProperty]
        public FNItemImages Images { get; internal set; }
        [JsonProperty("obtained_type")]
        public FNBRItemObtainedType ObtainType { get; internal set; }
    }
}
