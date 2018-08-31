using System;

using Newtonsoft.Json;

namespace FortniteAPI.Classes.Items
{
    public class FNBRStatsItem
    {
        internal FNBRStatsItem() { }

        [JsonProperty]
        public int Kills { get; internal set; }
        [JsonProperty]
        public int Wins { get; internal set; }
        [JsonProperty]
        public double KD { get; internal set; }
        [JsonProperty]
        public int MatchesPlayed { get; internal set; }
        [JsonProperty]
        public int MinutesPlayed { get; internal set; }
        [JsonProperty]
        public double Score { get; internal set; }
        [JsonProperty]
        public double WinRate { get; internal set; }
        [JsonProperty("lastupdate")]
        public double LastUpdated { get; internal set; }

        public int Deaths => MatchesPlayed - Wins;
        public decimal KillsPerMinute => (Kills != 0 ? (MatchesPlayed != 0 ? TruncateDecimal(Decimal.Divide(Kills, MatchesPlayed)) : 0) : 0);
        public decimal TimePerMatch => (MinutesPlayed != 0 ? (MatchesPlayed != 0 ? TruncateDecimal(Decimal.Divide(MinutesPlayed, MatchesPlayed)) : 0) : 0);

        private decimal TruncateDecimal(decimal input)
        {
            return Math.Truncate(100 * input) / 100;
        }
    }
}
