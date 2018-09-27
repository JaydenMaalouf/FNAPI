using System.Threading.Tasks;

using FortniteAPI.Endpoints.News;

namespace FortniteAPI.Endpoints.Interfaces
{
    public interface INewsEndpoint
    {
        Task<FNNews> GetNewsAsync();
    }
}
