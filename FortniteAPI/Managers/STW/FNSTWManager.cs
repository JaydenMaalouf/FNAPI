using FortniteAPI.Endpoints.News;
using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Managers.Interfaces
{
    class FNSTWManager : IFNSTWManager
    {
        internal FNSTWManager() { }

        public INewsEndpoint News => new STWNewsEndpoint();
    }
}
