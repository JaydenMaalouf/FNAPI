using System.Threading.Tasks;

using Newtonsoft.Json;

using RestSharp;

using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Endpoints.Status
{
    public class StatusEndpoint : IStatusEndpoint
    {
        internal StatusEndpoint() { }

        public async Task<FNStatus> GetStatusAsync()
        {
            var request = new RestRequest("status/fortnite_server_status", Method.GET);
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNStatus>(response.Content);
        }
    }
}
