using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Endpoints.Challenges.Items
{
    public class FNChallengeItem : IFNItem
    {
        internal FNChallengeItem() { }

        [JsonProperty("Identifier")]
        [JsonConverter(typeof(UIDConverter))]
        public UID ItemId { get; internal set; }
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
