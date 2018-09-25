using System.Threading.Tasks;

using Newtonsoft.Json;

using RestSharp;

using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Endpoints.News
{
    public class STWNewsEndpoint : INewsEndpoint
    {
        internal STWNewsEndpoint() { }

        public async Task<FNNews> GetNewsAsync()
        {
            var request = new RestRequest("stw_motd/get", Method.GET);
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<FNNews>(response.Content);
        }
    }
}
