using Newtonsoft.Json;

namespace FortniteAPI.Endpoints.News.Items
{
    public class FNNewsItem
    {
        internal FNNewsItem() { }

        [JsonProperty]
        public string Title { get; internal set; }
        [JsonProperty]
        public string Body { get; internal set; }
        [JsonProperty]
        public string Image { get; internal set; }
    }
}
