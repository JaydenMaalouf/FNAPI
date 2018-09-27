using System.Drawing;

using FortniteAPI.Enums;

namespace FortniteAPI.Endpoints.Store.Items
{
    public interface IFNBRItemProperties
    {
        FNBRItemType ItemType { get; }
        FNBRItemRarity Rarity { get; }

        Color GetRarityColor();
    }
}
