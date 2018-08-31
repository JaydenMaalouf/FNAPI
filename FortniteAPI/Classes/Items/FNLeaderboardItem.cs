using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Classes.Items
{
    public class FNBRLeaderboardItem : IFNUser
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

        [JsonProperty("UID")]
        [JsonConverter(typeof(UIDConverter))]
        public UID UserID { get; internal set; }
        [JsonProperty]
        public string Username { get; internal set; }
        [JsonProperty]
        public List<FNPlatform> Platforms { get; internal set; }

        public T GetUser<T>(bool? ForceGet = false) where T : IFNUser
        {
            if (ForceGet == true)
            {
                return (T)Activator.CreateInstance(typeof(T), new object[] { Username });
            }

            return (T)Activator.CreateInstance(typeof(T), new object[] { UserID, Username, Platforms });
        }

        public FNBRUser GetUser(bool? ForceGet = false)
        {
            if (ForceGet == true)
            {
                return new FNBRUser(Username);
            }

            return new FNBRUser(UserID, Username, (this as IFNUser).Platforms);
        }
    }
}
