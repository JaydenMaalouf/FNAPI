using System.Drawing;

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

        public Color GetRarityColor()
        {
            if (Rarity == FNBRItemRarity.LEGENDARY)
            {
                return Color.FromArgb(211, 120, 65);
            }
            if (Rarity == FNBRItemRarity.EPIC)
            {
                return Color.FromArgb(177, 91, 226);
            }
            if (Rarity == FNBRItemRarity.RARE)
            {
                return Color.FromArgb(73, 172, 242);
            }
            if (Rarity == FNBRItemRarity.UNCOMMON)
            {
                return Color.FromArgb(96, 170, 58);
            }
            return Color.FromArgb(177, 177, 177);
        }
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
