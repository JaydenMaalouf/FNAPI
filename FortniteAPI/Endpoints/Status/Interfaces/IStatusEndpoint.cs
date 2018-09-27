using System.Threading.Tasks;

using FortniteAPI.Endpoints.Status;

namespace FortniteAPI.Endpoints.Interfaces
{
    public interface IStatusEndpoint
    {
        Task<FNStatus> GetStatusAsync();
    }
}
