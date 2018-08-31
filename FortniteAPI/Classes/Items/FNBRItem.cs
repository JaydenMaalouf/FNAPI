using System.Drawing;
using System.Collections.Generic;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Classes.Items
{
    public class FNBRItem : FNItem, IFNItemProperties
    {
        internal FNBRItem() { }

        [JsonProperty("type")]
        public FNBRItemType ItemType { get; internal set; }
        [JsonProperty]
        public FNBRItemRarity Rarity { get; internal set; }

        [JsonProperty]
        public FNItemImages Images { get; internal set; }
        [JsonProperty]
        public FNBRItemOccurrences Occurences { get; internal set; }

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
            return Color.FromArgb(96, 170, 58);
        }
    }
    
    public class FNBRItemOccurrences
    {
        internal FNBRItemOccurrences() { }

        [JsonProperty]
        public string First { get; internal set; }
        [JsonProperty]
        public string Last { get; internal set; }
        [JsonProperty]
        public int Occurrences { get; internal set; }
        [JsonProperty]
        public List<FNBRItemOccurrenceEntry> Entries {get; internal set;}
    }

    public class FNBRItemOccurrenceEntry
    {
        internal FNBRItemOccurrenceEntry() { }

        [JsonProperty]
        public string Date { get; internal set; }
        [JsonProperty]
        public int Cost { get; internal set; }
        [JsonProperty]
        public bool Featured { get; internal set; }
    }
}
