namespace FortniteAPI.Classes.Items
{
    internal class FNBRTempUser
    {
        public FNBRStatsItem Totals { get; set; }
        public FNBRTempUserStats Stats { get; set; }
    }

    internal class FNBRTempUserStats
    {
        public int Kills_solo { get; set; }
        public int Placetop1_solo { get; set; }
        public int Placetop10_solo { get; set; }
        public int Placetop25_solo { get; set; }
        public int Matchesplayed_solo { get; set; }
        public double Kd_solo { get; set; }
        public double Winrate_solo { get; set; }
        public int Score_solo { get; set; }
        public int Minutesplayed_solo { get; set; }
        public int Lastmodified_solo { get; set; }
        public int Kills_duo { get; set; }
        public int Placetop1_duo { get; set; }
        public int Placetop5_duo { get; set; }
        public int Placetop12_duo { get; set; }
        public int Matchesplayed_duo { get; set; }
        public double Kd_duo { get; set; }
        public double Winrate_duo { get; set; }
        public int Score_duo { get; set; }
        public int Minutesplayed_duo { get; set; }
        public int Lastmodified_duo { get; set; }
        public int Kills_squad { get; set; }
        public int Placetop1_squad { get; set; }
        public int Placetop3_squad { get; set; }
        public int Placetop6_squad { get; set; }
        public int Matchesplayed_squad { get; set; }
        public double Kd_squad { get; set; }
        public double Winrate_squad { get; set; }
        public int Score_squad { get; set; }
        public int Minutesplayed_squad { get; set; }
        public int Lastmodified_squad { get; set; }
    }

    public class FNBRStats
    {
        public FNBRStatsItem Solo { get; internal set; } = new FNBRStatsItem();
        public FNBRStatsItem Duo { get; internal set; } = new FNBRStatsItem();
        public FNBRStatsItem Squad { get; internal set; } = new FNBRStatsItem();
        public FNBRStatsItem Overall { get; internal set; } = new FNBRStatsItem();

        internal FNBRStats() { }

        internal FNBRStats(FNBRTempUser user)
        {
            if (user.Totals != null)
            {
                Overall = user.Totals;
            }
            if (user.Stats != null)
            {
                Solo.Kills = user.Stats.Kills_solo;
                Solo.Wins = user.Stats.Placetop1_solo;
                Solo.MatchesPlayed = user.Stats.Matchesplayed_solo;
                Solo.MinutesPlayed = user.Stats.Minutesplayed_solo;
                Solo.Score = user.Stats.Score_solo;
                Solo.WinRate = user.Stats.Winrate_solo;
                Solo.KD = user.Stats.Kd_solo;
                Solo.LastUpdated = user.Stats.Lastmodified_solo;

                Duo.Kills = user.Stats.Kills_duo;
                Duo.Wins = user.Stats.Placetop1_duo;
                Duo.MatchesPlayed = user.Stats.Matchesplayed_duo;
                Duo.MinutesPlayed = user.Stats.Minutesplayed_duo;
                Duo.Score = user.Stats.Score_duo;
                Duo.WinRate = user.Stats.Winrate_duo;
                Duo.KD = user.Stats.Kd_duo;
                Duo.LastUpdated = user.Stats.Lastmodified_duo;

                Squad.Kills = user.Stats.Kills_squad;
                Squad.Wins = user.Stats.Placetop1_squad;
                Squad.MatchesPlayed = user.Stats.Matchesplayed_squad;
                Squad.MinutesPlayed = user.Stats.Minutesplayed_squad;
                Squad.Score = user.Stats.Score_squad;
                Squad.WinRate = user.Stats.Winrate_squad;
                Squad.KD = user.Stats.Kd_squad;
                Squad.LastUpdated = user.Stats.Lastmodified_squad;
            }
        }
    }
}
