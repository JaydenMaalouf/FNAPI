using System;

using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.Patchnotes.Items
{
    public class FNPatchnoteItem
    {
        internal FNPatchnoteItem() { }
        
        [JsonProperty("_id")]
        [JsonConverter(typeof(UIDConverter))]
        public UID Id { get; internal set; }

        [JsonProperty]
        public string Title { get; internal set; }
        [JsonProperty("short")]
        public string Description { get; internal set; }
        [JsonIgnore]
        public string Link { get; private set; }
        [JsonProperty]
        public string Image { get; internal set; }
        [JsonProperty]
        public string TrendingImage { get; internal set; }

        [JsonProperty("date")]
        public DateTime DateTime { get; internal set; }

        [JsonProperty]
        private string ExternalLink { set { Link = "https://fortnite.com" + value; } }
    }
}
