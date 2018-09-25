using System.Collections.Generic;

using FortniteAPI.Enums;

namespace FortniteAPI.Interfaces
{
    public interface IFNUser
    {
        UID UserID { get; }
        string Username { get;  }
        List<FNPlatform> Platforms { get; }
    }
}
