using System.Threading.Tasks;
using System.Collections.Generic;

using RestSharp;

using Newtonsoft.Json;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;
using FortniteAPI.Classes.Items;

namespace FortniteAPI.Classes
{
    public class FNBRUser : FNUser
    {
        public async Task<FNBRStats> GetStatsAsync(FNPlatform platform = FNPlatform.PC, FNStatWindow? window = null)
        {
            if (Platforms.Contains(platform))
            {
                var request = new RestRequest("users/public/br_stats", Method.GET);
                request.AddParameter("user_id", UserID.UIDToString());
                request.AddParameter("platform", platform.ToString().ToLower());
                if (window != null)
                {
                    request.AddParameter("window", window.ToString().ToLower());
                }

                IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
                if (response.ResponseStatus != ResponseStatus.Completed)
                {
                    return null;
                }
                
                var tempUser = JsonConvert.DeserializeObject<FNBRTempUser>(response.Content);
                if (tempUser == null)
                {
                    return null;
                }

                return new FNBRStats(tempUser);
            }
            return null;
        }
        
        public FNBRUser(IFNUser user)
        {
            UserID = user.UserID;
            Username = user.Username;
            Platforms = user.Platforms;
        }
    }
}
