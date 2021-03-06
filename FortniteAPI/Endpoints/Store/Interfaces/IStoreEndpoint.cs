﻿using System.Threading.Tasks;
using System.Collections.Generic;

using FortniteAPI.Enums;
using FortniteAPI.Endpoints.Store;
using FortniteAPI.Endpoints.Store.Items;

namespace FortniteAPI.Endpoints.Interfaces
{
    public delegate Task StoreUpdatedHandler(FNBRStore store);

    public interface IStoreEndpoint
    {
        event StoreUpdatedHandler StoreUpdated;

        Task<FNBRStore> GetStoreAsync();
        Task<List<FNBRSearchItem>> SearchItemAsync(string name, FNBRItemRarity? rarity = null);
        Task<FNBRLookupItem> GetItemAsync(UID UniqueId);
        Task<List<FNBRStoreItem>> GetUpcomingItemsAsync();
    }
}
