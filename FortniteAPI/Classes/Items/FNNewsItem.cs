using Newtonsoft.Json;

namespace FortniteAPI.Classes.Items
{
    public class FNNewsItem
    {
        [JsonProperty]
        public string Title { get; internal set; }
        [JsonProperty]
        public string Body { get; internal set; }
        [JsonProperty]
        public string Image { get; internal set; }
    }
}
