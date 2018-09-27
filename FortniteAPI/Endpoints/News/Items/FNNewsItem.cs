using System;
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

        public DateTime DateTime { get; internal set; }

        [JsonProperty]
        private long Time { set { DateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(value); } }
    }
}
