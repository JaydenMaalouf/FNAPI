using System.Collections.Generic;
using System.Threading.Tasks;

using FortniteAPI.Endpoints.Store;
using FortniteAPI.Endpoints.Store.Items;
using FortniteAPI.Enums;

namespace FortniteAPI.Endpoints.Interfaces
{
    public delegate Task StoreUpdatedHandler(FNBRStore store);

    public interface IStoreEndpoint
    {
        event StoreUpdatedHandler StoreUpdated;

        Task<FNBRStore> GetStoreAsync();
        Task<List<FNBRSearchItem>> SearchAsync(string name, FNBRItemRarity? rarity = null);
        Task<FNBRItem> GetItemAsync(UID UID);
        Task<List<FNBRStoreItem>> GetUpcomingItemsAsync();
    }
}
