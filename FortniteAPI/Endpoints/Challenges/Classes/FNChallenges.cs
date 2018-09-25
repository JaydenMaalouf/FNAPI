using System.Collections.Generic;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Challenges.Items;

namespace FortniteAPI.Endpoints.Challenges
{
    public class FNChallenges
    {
        internal FNChallenges() { }

        [JsonProperty]
        public FNSeason Season { get; internal set; }
        [JsonProperty]
        public FNWeek CurrentWeek { get; internal set; }

        [JsonProperty("star")]
        public string Icon { get; internal set; }

        [JsonProperty]
        public Dictionary<string, List<FNChallengeItem>> Challenges { get; internal set; }
    }
}
