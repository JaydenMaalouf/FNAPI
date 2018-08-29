namespace FortniteAPI.Classes.Items
{
    public class FNBRStats
    {
        public FNBRStatsItem Solo { get; internal set; } = new FNBRStatsItem();
        public FNBRStatsItem Duo { get; internal set; } = new FNBRStatsItem();
        public FNBRStatsItem Squad { get; internal set; } = new FNBRStatsItem();
        public FNBRStatsItem Overall { get; internal set; } = new FNBRStatsItem();

        public FNBRStats(FNBRTempUser user)
        {
            if (user.totals != null)
            {
                Overall = user.totals;
            }
            if (user.stats != null)
            {
                Solo.Kills = user.stats.kills_solo;
                Solo.Wins = user.stats.placetop1_solo;
                Solo.MatchesPlayed = user.stats.matchesplayed_solo;
                Solo.MinutesPlayed = user.stats.minutesplayed_solo;
                Solo.Score = user.stats.score_solo;
                Solo.WinRate = user.stats.winrate_solo;
                Solo.KD = user.stats.kd_solo;
                Solo.LastUpdated = user.stats.lastmodified_solo;

                Duo.Kills = user.stats.kills_duo;
                Duo.Wins = user.stats.placetop1_duo;
                Duo.MatchesPlayed = user.stats.matchesplayed_duo;
                Duo.MinutesPlayed = user.stats.minutesplayed_duo;
                Duo.Score = user.stats.score_duo;
                Duo.WinRate = user.stats.winrate_duo;
                Duo.KD = user.stats.kd_duo;
                Duo.LastUpdated = user.stats.lastmodified_duo;

                Squad.Kills = user.stats.kills_squad;
                Squad.Wins = user.stats.placetop1_squad;
                Squad.MatchesPlayed = user.stats.matchesplayed_squad;
                Squad.MinutesPlayed = user.stats.minutesplayed_squad;
                Squad.Score = user.stats.score_squad;
                Squad.WinRate = user.stats.winrate_squad;
                Squad.KD = user.stats.kd_squad;
                Squad.LastUpdated = user.stats.lastmodified_squad;
            }
        }
    }
}
