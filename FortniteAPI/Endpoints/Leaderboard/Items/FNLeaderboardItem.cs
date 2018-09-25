using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Classes;

namespace FortniteAPI.Endpoints.Leaderboard.Items
{
    public class FNBRLeaderboardItem
    {
        internal FNBRLeaderboardItem() { }

        [JsonProperty]
        public double Kills { get; internal set; }
        [JsonProperty]
        public double Wins { get; internal set; }
        [JsonProperty("matches")]
        public double MatchesPlayed { get; internal set; }
        [JsonProperty("minutes")]
        public double MinutesPlayed { get; internal set; }
        [JsonProperty]
        public double Score { get; internal set; }
        [JsonProperty]
        public double KD { get; internal set; }
        [JsonProperty]
        public FNPlatform Platform { get; internal set; }
        [JsonProperty]
        public int Rank { get; internal set; }

        [JsonProperty]
        private FNBRUser User { get; set; }

        public FNBRUser GetUser()
        {
            return User;
        }
    }
}
