using System.Collections.Generic;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Classes.Items;

namespace FortniteAPI.Classes
{
    public class FNChallenges
    {
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
