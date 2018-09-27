using System.Drawing;

using Newtonsoft.Json;

using FortniteAPI.Enums;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRItemProperties : IFNBRItemProperties
    {
        internal FNBRItemProperties() { }

        [JsonProperty("type")]
        public FNBRItemType ItemType { get; internal set; }
        [JsonProperty]
        public FNBRItemRarity Rarity { get; internal set; }

        [JsonProperty("image")]
        public string ImageURL { get; internal set; }
        [JsonProperty]
        public FNBRItemImages Images { get; internal set; }
        [JsonProperty("obtained_type")]
        public FNBRItemObtainedType ObtainType { get; internal set; }

        public Color GetRarityColor()
        {
            throw new System.NotImplementedException();
        }
    }
}
