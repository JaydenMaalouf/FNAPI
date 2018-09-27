using System;
using System.Threading.Tasks;

using FortniteAPI;
using FortniteAPI.Endpoints.Store;
using FortniteAPI.Enums;

namespace ExampleTest
{
    class Program
    {
        static void Main(string[] args)
        => new Program().MainAsync().GetAwaiter().GetResult();

        public static FNAPI API = new FNAPI("VALID API KEY HERE");

        public async Task MainAsync()
        {
            API.BR.Store.StoreUpdated += StoreUpdated;
            
            var season = API.GetCurrentSeason();
            var week = API.GetCurrentWeek();
            var version = API.GetCurrentVersion();
            var status = await API.Status.GetStatusAsync();
            var patchnotes = await API.Patchnotes.GetPatchnotesAsync();
            var challenges = await API.BR.Challenges.GetChallengesAsync();

            var store = await API.BR.Store.GetStoreAsync();
            var featured = store.GetFeaturedStore();
            var daily = store.GetDailyStore();
            var upcoming = await API.BR.Store.GetUpcomingItemsAsync();
            var search = await API.BR.Store.SearchItemAsync("Brite Gunner");
            var searchItem = search[0];

            var item = await API.BR.Store.GetItemAsync(searchItem.ItemId);

            var user = API.GetUser("Kangaaa");
            var stats = await user.Stats.GetBRStatsAsync();
            var gameModeStats = await user.Stats.GetBRStatsAsync(FNBRGameMode.ALL);
            var userUID = API.GetUser(new UID("711b6eaea0464736ab39212e16ac6c87"));

            var leaderboard = await API.BR.Leaderboard.GetLeaderboardAsync();
            var leader = leaderboard[0];
            var lUser = leader.GetUser();
            var lStats = await lUser.Stats.GetBRStatsAsync();

            var brNews = await API.BR.News.GetNewsAsync();
            var stwNews = await API.STW.News.GetNewsAsync();

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
