using FortniteAPI.Enums;

namespace FortniteAPI.Interfaces
{
    public interface IFNItemProperties
    {
        FNBRItemType ItemType { get; }
        FNBRItemRarity Rarity { get; }
    }
}
