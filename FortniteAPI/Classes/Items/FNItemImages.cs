using Newtonsoft.Json;

namespace FortniteAPI.Classes.Items
{
    public class FNItemImages
    {
        internal FNItemImages() { }

        [JsonProperty]
        public string Icon { get; internal set; }
        [JsonProperty]
        public string Full { get; internal set; }
        [JsonProperty]
        public string Background { get; internal set; }
        [JsonProperty]
        public string Transparent { get; internal set; }
    }
}
