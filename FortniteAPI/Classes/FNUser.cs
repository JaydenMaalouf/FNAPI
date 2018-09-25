using System;
using System.Collections.Generic;

using RestSharp;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Classes
{
    public class FNUser : IFNUser
    {
        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        public UID UserID { get; internal set; }

        [JsonProperty]
        public string Username { get; internal set; }

        [JsonProperty]
        public List<FNPlatform> Platforms { get; internal set; } = new List<FNPlatform>();

        [JsonProperty]
        private FNPlatform Platform { set { Platforms.Add(value); } }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID UID { set { UserID = value; } }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID ID { set { UserID = value; } }

        [JsonProperty]
        private string DisplayName { set { Username = value; } }

        internal FNUser() { }

        internal FNUser(UID uid, string username, List<FNPlatform> platforms)
        {
            UserID = uid;
            Username = username;
            Platforms = platforms;
        }

        public FNUser(string username)
        {
            var request = new RestRequest("users/id", Method.GET);
            request.AddParameter("username", username);
            IRestResponse response = FNAPI.SendRestRequestAsync(request).Result;
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return;
            }

            JsonConvert.PopulateObject(response.Content, this);
        }

        public FNUser(UID userID)
        {
            var request = new RestRequest("users/username out of id", Method.GET);
            request.AddParameter("ids[0]", userID.UIDToString());
            IRestResponse response = FNAPI.SendRestRequestAsync(request).Result;
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return;
            }

            var user = JsonConvert.DeserializeObject<List<FNUser>>(response.Content)[0];
            if (user != null)
            {
                Username = user.Username;
                UserID = user.UserID;
                Platforms = user.Platforms;
            }
        }

        public T ConvertTo<T>() where T : IFNUser
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { this });
        }
    }
}
