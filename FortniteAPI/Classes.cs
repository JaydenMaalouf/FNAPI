using FortniteAPI.Classes.Items;

namespace FortniteAPI.Classes
{
    public class FNBRTempUser
    {
        public FNBRStatsItem totals { get; set; }
        public FNBRTempUserStats stats { get; set; }
    }

    public class FNBRTempUserStats
    {
        public int kills_solo { get; set; }
        public int placetop1_solo { get; set; }
        public int placetop10_solo { get; set; }
        public int placetop25_solo { get; set; }
        public int matchesplayed_solo { get; set; }
        public double kd_solo { get; set; }
        public double winrate_solo { get; set; }
        public int score_solo { get; set; }
        public int minutesplayed_solo { get; set; }
        public int lastmodified_solo { get; set; }
        public int kills_duo { get; set; }
        public int placetop1_duo { get; set; }
        public int placetop5_duo { get; set; }
        public int placetop12_duo { get; set; }
        public int matchesplayed_duo { get; set; }
        public double kd_duo { get; set; }
        public double winrate_duo { get; set; }
        public int score_duo { get; set; }
        public int minutesplayed_duo { get; set; }
        public int lastmodified_duo { get; set; }
        public int kills_squad { get; set; }
        public int placetop1_squad { get; set; }
        public int placetop3_squad { get; set; }
        public int placetop6_squad { get; set; }
        public int matchesplayed_squad { get; set; }
        public double kd_squad { get; set; }
        public double winrate_squad { get; set; }
        public int score_squad { get; set; }
        public int minutesplayed_squad { get; set; }
        public int lastmodified_squad { get; set; }
    }
}
