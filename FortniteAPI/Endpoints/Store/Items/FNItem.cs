using Newtonsoft.Json;

using FortniteAPI.Interfaces;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNItem : IFNItem
    {
        internal FNItem() { }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        public UID ItemId { get; internal set; }
        [JsonProperty]
        public string Name { get; internal set; }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID Identifier { set { ItemId = value; } }
    }
}
