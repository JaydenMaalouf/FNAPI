using System.Collections.Generic;

using RestSharp;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Stats;
using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Endpoints.User
{
    public class FNUser : IFNUser
    {
        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        public UID UserId { get; internal set; }

        [JsonProperty]
        public string Username { get; internal set; }

        [JsonProperty]
        public List<FNPlatform> Platforms { get; internal set; } = new List<FNPlatform>();

        [JsonProperty]
        private FNPlatform Platform { set { Platforms.Add(value); } }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID UID { set { UserId = value; } }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID Id { set { UserId = value; } }

        [JsonProperty]
        private string DisplayName { set { Username = value; } }
        
        public IStatsEndpoint Stats => new StatsEndpoint(this);

        internal FNUser() { }

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

        public FNUser(UID UniqueId)
        {
            var request = new RestRequest("users/username out of id", Method.GET);
            request.AddParameter("ids[0]", UniqueId.ToString());
            IRestResponse response = FNAPI.SendRestRequestAsync(request).Result;
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return;
            }

            var users = JsonConvert.DeserializeObject<List<FNUser>>(response.Content);
            if (users != null && users.Count > 0)
            {
                var user = users[0];
                Username = user.Username;
                UserId = user.UserId;
                Platforms = user.Platforms;
            }
        }
    }
}
