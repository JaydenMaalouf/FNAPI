using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using RestSharp;

using FortniteAPI.Enums;
using FortniteAPI.Interfaces;

namespace FortniteAPI.Classes.Items
{
    public class FNBRItem : FNItem, IFNItemProperties
    {
        [JsonProperty("type")]
        public FNBRItemType ItemType { get; internal set; }
        [JsonProperty]
        public FNBRItemRarity Rarity { get; internal set; }

        [JsonProperty]
        public FNBRItemObtained Obtained { get; internal set; }
        [JsonProperty]
        public FNItemImages Images { get; internal set; }

        public async Task<FNBRItemOccurrences> GetOccurencesAsync() => await Task.FromResult(GetOccurences());
        private FNBRItemOccurrences GetOccurences()
        {
            var request = new RestRequest("item/get", Method.POST);
            request.AddHeader("Authorization", FNAPI.APIKey);
            request.AddParameter("ids", ItemID);

            IRestResponse response = FNAPI.SendRequest(request);
            if (response.ResponseStatus != ResponseStatus.Completed)
            {
                return null;
            }

            return JObject.Parse(response.Content)["occurrences"].ToObject<FNBRItemOccurrences>();
        }

        public Color GetRarityColor()
        {
            if (Rarity == FNBRItemRarity.LEGENDARY)
            {
                return Color.FromArgb(211, 120, 65);
            }
            if (Rarity == FNBRItemRarity.EPIC)
            {
                return Color.FromArgb(177, 91, 226);
            }
            if (Rarity == FNBRItemRarity.RARE)
            {
                return Color.FromArgb(73, 172, 242);
            }
            return Color.FromArgb(96, 170, 58);
        }
    }

    public class FNBRItemObtained
    {
        [JsonProperty]
        public string Obtained { get; internal set; }
        [JsonProperty]
        public FNBRItemObtainedType Type { get; internal set; }
    }

    public class FNBRItemOccurrences
    {
        [JsonProperty]
        public string First { get; internal set; }
        [JsonProperty]
        public string Last { get; internal set; }
        [JsonProperty]
        public int Occurrences { get; internal set; }
        [JsonProperty]
        public List<FNBRItemOccurrenceEntry> Entries {get; internal set;}
    }

    public class FNBRItemOccurrenceEntry
    {
        [JsonProperty]
        public string Date { get; internal set; }
        [JsonProperty]
        public int Cost { get; internal set; }
        [JsonProperty]
        public bool Featured { get; internal set; }
    }
}
