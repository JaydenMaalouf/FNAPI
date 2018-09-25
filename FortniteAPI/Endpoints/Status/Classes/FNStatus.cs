using Newtonsoft.Json;

using FortniteAPI.Enums;

namespace FortniteAPI.Endpoints.Status
{
    public class FNStatus
    {
        internal FNStatus() { }

        [JsonProperty]
        public FNStatusType Status { get; internal set; }
        [JsonProperty]
        public string Message { get; internal set; }
        [JsonProperty]
        public string Version { get; internal set; }
    }
}
