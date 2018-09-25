using FortniteAPI.Endpoints.Interfaces;
using FortniteAPI.Managers.Interfaces;

namespace FortniteAPI.Interfaces
{
    public interface IFNAPI
    {
        IFNBRManager BR { get; }
        IFNSTWManager STW { get; }
        IStatusEndpoint Status { get; }
        IPatchnotesEndpoint Patchnotes { get; }
    }
}
