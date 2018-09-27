using System.Collections.Generic;

using FortniteAPI.Enums;

namespace FortniteAPI.Endpoints.Interfaces
{
    public interface IFNUser
    {
        UID UserId { get; }
        string Username { get;  }
        List<FNPlatform> Platforms { get; }

        IStatsEndpoint Stats { get; }
    }
}
