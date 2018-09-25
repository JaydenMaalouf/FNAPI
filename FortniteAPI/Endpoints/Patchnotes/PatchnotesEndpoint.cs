using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json.Linq;

using RestSharp;

using FortniteAPI.Endpoints.Interfaces;
using FortniteAPI.Endpoints.Patchnotes.Items;

namespace FortniteAPI.Endpoints.Patchnotes
{
    class PatchnotesEndpoint : IPatchnotesEndpoint
    {
        internal PatchnotesEndpoint() { }

        public async Task<List<FNPatchnoteItem>> GetPatchnotesAsync()
        {
            var request = new RestRequest("patchnotes/get", Method.GET);
            IRestResponse response = await FNAPI.SendRestRequestAsync(request).ConfigureAwait(false);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JObject.Parse(response.Content)["blogList"].ToObject<List<FNPatchnoteItem>>();
        }
    }
}
