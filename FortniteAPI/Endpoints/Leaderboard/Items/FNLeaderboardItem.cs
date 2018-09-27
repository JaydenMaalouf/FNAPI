using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.User;
using FortniteAPI.Endpoints.Stats.Interfaces;

namespace FortniteAPI.Endpoints.Leaderboard.Items
{
    public class FNBRLeaderboardItem : IFNBRStatsItem
    {
        internal FNBRLeaderboardItem() { }

        [JsonProperty]
        public int Kills { get; internal set; }
        [JsonProperty]
        public int Wins { get; internal set; }
        [JsonProperty("matches")]
        public int MatchesPlayed { get; internal set; }
        [JsonProperty("minutes")]
        public int MinutesPlayed { get; internal set; }
        [JsonProperty]
        public double Score { get; internal set; }
        [JsonProperty]
        public double KD { get; internal set; }
        [JsonProperty]
        public FNPlatform Platform { get; internal set; }
        [JsonProperty]
        public int Rank { get; internal set; }

        [JsonProperty]
        private FNUser User { get; set; }

        public FNUser GetUser()
        {
            return User;
        }
    }
}
