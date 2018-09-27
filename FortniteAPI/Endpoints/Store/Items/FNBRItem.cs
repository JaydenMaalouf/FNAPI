using System.Drawing;

using Newtonsoft.Json;

using FortniteAPI.Enums;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRItem : FNItem, IFNBRItemProperties
    {
        internal FNBRItem() { }

        [JsonProperty("type")]
        public FNBRItemType ItemType { get; internal set; }
        [JsonProperty]
        public FNBRItemRarity Rarity { get; internal set; }

        [JsonProperty]
        public FNBRItemImages Images { get; internal set; }

        [JsonProperty]
        public FNBRItemOccurrences Occurrences { get; internal set; }

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
}
