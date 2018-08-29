using Newtonsoft.Json;

using FortniteAPI.Enums;

namespace FortniteAPI.Classes
{
    public class FNStatus
    {
        [JsonProperty]
        public FNStatusType Status { get; internal set; }
        [JsonProperty]
        public string Message { get; internal set; }
        [JsonProperty]
        public string Version { get; internal set; }
    }
}
