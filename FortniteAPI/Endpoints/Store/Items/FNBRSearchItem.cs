using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRSearchItem : FNItem, IFNItemProperties
    {
        internal FNBRSearchItem() { }

        [JsonProperty("type")]
        public FNBRItemType ItemType { get; internal set; }
        [JsonProperty]
        public FNBRItemRarity Rarity { get; internal set; }

        [JsonProperty]
        public FNBRItemObtained Obtained { get; internal set; }

        [JsonProperty]
        public FNItemImages Images { get; internal set; }
    }

    public class FNBRItemObtained
    {
        internal FNBRItemObtained() { }

        [JsonProperty]
        public string Obtained { get; internal set; }
        [JsonProperty]
        public FNBRItemObtainedType Type { get; internal set; }
    }
}
