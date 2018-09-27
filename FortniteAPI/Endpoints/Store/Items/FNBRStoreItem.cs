using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRStoreItem : FNBRItem
    {
        internal FNBRStoreItem() { }

        [JsonProperty]
        public string Cost { get; internal set; }
        [JsonProperty]
        public bool Featured { get; internal set; }
        [JsonProperty]
        public bool Refundable { get; internal set; }

        [JsonProperty("item")]
        private FNBRItemProperties Properties
        {
            set
            {
                ItemType = value.ItemType;
                Rarity = value.Rarity;
                Images = value.Images;
            }
        }
    }
}
