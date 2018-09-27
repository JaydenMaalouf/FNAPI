using Newtonsoft.Json;

using FortniteAPI.Enums;

namespace FortniteAPI.Endpoints.Store.Items
{
    public class FNBRItemObtained
    {
        internal FNBRItemObtained() { }

        [JsonProperty]
        public string Obtained { get; internal set; }
        [JsonProperty]
        public FNBRItemObtainedType Type { get; internal set; }
    }
}
