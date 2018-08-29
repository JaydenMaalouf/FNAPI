using System;
using System.Collections.Generic;

using RestSharp;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;
using FortniteAPI.Extensions;

namespace FortniteAPI.Classes
{
    public class FNUser : FNExtensions, IFNUser
    {
        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        public UID UserID { get; internal set; }
        [JsonProperty]
        public string Username { get; internal set; }
        [JsonProperty]
        public List<FNPlatform> Platforms { get; internal set; }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID UID { set { UserID = value; } }

        [JsonProperty]
        [JsonConverter(typeof(UIDConverter))]
        private UID ID { set { UserID = value; } }

        [JsonProperty]
        private string displayName { set { Username = value; } }

        public FNUser() { }

        public FNUser(UID uid, string username, List<FNPlatform> platforms)
        {
            UserID = uid;
            Username = username;
            Platforms = platforms;
        }

        public FNUser(string username)
        {
            var request = new RestRequest("users/id", Method.POST);
            request.AddParameter("username", username);
            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return;
            }

            JsonConvert.PopulateObject(response.Content, this);
        }

        public FNUser(UID userID)
        {
            var request = new RestRequest("users/username out of id", Method.POST);
            request.AddParameter("ids[0]", userID.GetUID());
            IRestResponse response = FNAPI.SendRequest(request);
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

        public FNUser(IFNBRUser user)
        {
            UserID = user.UserID;
            Username = user.Username;
            Platforms = user.Platforms;
        }

        public T ConvertTo<T>() where T : IFNUser
        {
            return (T)Activator.CreateInstance(typeof(T), new object[] { this });
        }
    }
}
