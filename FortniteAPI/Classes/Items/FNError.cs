using Newtonsoft.Json;

namespace FortniteAPI.Classes.Items
{
    public class FNError
    {
        [JsonProperty]
        public string Error { get; internal set; }
        [JsonProperty]
        public string MSG { get;  internal set; }
    }
}
