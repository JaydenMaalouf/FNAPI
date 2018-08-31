using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Classes.Items
{
    public class FNChallengeItem : IFNItem
    {
        internal FNChallengeItem() { }

        [JsonProperty("Identifier")]
        [JsonConverter(typeof(UIDConverter))]
        public UID ItemID { get; internal set; }
        [JsonProperty("Challenge")]
        public string Name { get; internal set; }

        [JsonProperty]
        public int Total { get; internal set; }
        [JsonProperty]
        public int Stars { get; internal set; }
        [JsonProperty]
        public FNChallengeDifficulty Difficulty { get; internal set; }
    }
}
