using System.Threading.Tasks;
using System.Collections.Generic;

using FortniteAPI.Endpoints.Patchnotes.Items;

namespace FortniteAPI.Endpoints.Interfaces
{
    public interface IPatchnotesEndpoint
    {
        Task<List<FNPatchnoteItem>> GetPatchnotesAsync();
    }
}
