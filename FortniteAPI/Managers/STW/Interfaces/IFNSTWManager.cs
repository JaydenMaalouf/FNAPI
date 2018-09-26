using FortniteAPI.Endpoints.Interfaces;

namespace FortniteAPI.Managers.Interfaces
{
    public interface IFNSTWManager
    {
        INewsEndpoint News { get; }
    }
}
