using Newtonsoft.Json;

namespace FortniteAPI.Classes.Items
{
    public class FNPatchnoteItem
    {
        [JsonProperty]
        public string Title { get; internal set; }
        [JsonProperty("short")]
        public string Description { get; internal set; }
        [JsonProperty]
        public string Link { get; private set; }
        [JsonProperty]
        public string Image { get; internal set; }
        [JsonProperty]
        public string TrendingImage { get; internal set; }

        [JsonProperty]
        private string ExternalLink { set { Link = "https://fortnite.com" + value; } }
    }
}
