using System;
using System.Threading.Tasks;

using FortniteAPI;
using FortniteAPI.Endpoints.Store;

namespace ExampleTest
{
    class Program
    {
        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        public static FNAPI APi = new FNAPI("VALID API KEY HERE");

        public async Task MainAsync()
        {
            APi.BR.Store.StoreUpdated += StoreUpdated;

            var season = APi.GetCurrentSeason();
            var week = APi.GetCurrentWeek();
            var version = APi.GetCurrentVersion();
            var status = await APi.Status.GetStatusAsync();
            var patchnotes = await APi.Patchnotes.GetPatchnotesAsync();

            var store = await APi.BR.Store.GetStoreAsync();
            var featured = store.GetFeaturedStore();
            var daily = store.GetDailyStore();
            var upcoming = await APi.BR.Store.GetUpcomingItemsAsync();
            var search = await APi.BR.Store.SearchAsync("Brite Gunner", FortniteAPI.Enums.FNBRItemRarity.EPIC);
            var searchItem = search[0];

            var item = await APi.BR.Store.GetItemAsync(searchItem.ItemId);

            var user = APi.GetUser("Kangaaa");
            var stats = await user.Stats.GetBRStatsAsync();
            var userUID = APi.GetUser(new UID("711b6eaea0464736ab39212e16ac6c87"));

            var leaderboard = await APi.BR.Leaderboard.GetLeaderboardAsync();
            var leader = leaderboard[0];
            var lUser = leader.GetUser();
            var lStats = await lUser.Stats.GetBRStatsAsync();

            var brNews = await APi.BR.News.GetNewsAsync();
            var challenges = await APi.BR.Challenges.GetChallengesAsync();
            var stwNews = await APi.STW.News.GetNewsAsync();

            Console.Read();
        }

        private Task StoreUpdated(FNBRStore store)
        {
            Console.WriteLine(store.Items.Count.ToString());
            foreach (var item in store.Items)
            {
                Console.WriteLine("Name: {0}\nCost: {1}", item.Name, item.Cost);
            }
            return Task.CompletedTask;
        }
    }
}
