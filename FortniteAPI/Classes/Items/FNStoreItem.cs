using System.Drawing;

using Newtonsoft.Json;

using FortniteAPI.Enums;

namespace FortniteAPI.Classes.Items
{
    public class FNBRStoreItem : FNItem
    {
        internal FNBRStoreItem() { }

        [JsonProperty]
        public string Cost { get; internal set; }
        [JsonProperty]
        public bool Featured { get; internal set; }
        [JsonProperty]
        public bool Refundable { get; internal set; }

        [JsonProperty("item")]
        public FNItemProperties Properties { get; internal set; }

        public Color GetRarityColor()
        {
            if (Properties.Rarity == FNBRItemRarity.LEGENDARY)
            {
                return Color.FromArgb(211, 120, 65);
            }
            if (Properties.Rarity == FNBRItemRarity.EPIC)
            {
                return Color.FromArgb(177, 91, 226);
            }
            if (Properties.Rarity == FNBRItemRarity.RARE)
            {
                return Color.FromArgb(73, 172, 242);
            }
            return Color.FromArgb(96, 170, 58);
        }
    }
}
