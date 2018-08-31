using Newtonsoft.Json;

namespace FortniteAPI.Classes.Items
{
    public class FNError
    {
        internal FNError() { }

        [JsonProperty]
        public string Error { get; internal set; }
        [JsonProperty]
        public string MSG { get;  internal set; }
    }
}
