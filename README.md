[![NuGet](https://img.shields.io/badge/nuget-1.1.2-brightgreen.svg)](https://www.nuget.org/packages/FNAPI/)
[![Discord](https://discordapp.com/api/guilds/474621956562616331/widget.png)](https://discordapp.com/invite/8zPBaCQ)

# FNAPI - C# Fortnite API
An unofficial .NET API Wrapper for the Fortnite API (http://fortniteapi.com)
Documentation is found below!

## Installation
Our stable build is available from NuGet through the FNAPI metapackage:
- [FNAPI](https://www.nuget.org/packages/FNAPI/)

## Getting Started
Once you have added the NuGet Package to your Project, you will need to add the `using FortniteAPI;` to your class header.
Then simply instance the FNAPI class with your API key, like so:
```csharp
var API = new FNAPI("ENTER A VALID API KEY HERE");
```
Now you can easily make calls to the API.

## GetUser()
The base user class `FNUser` contains the UID and Username of a user. 
If you already know a user's UID or Username, you can use the `GetUser()` method to return an `FNUser` object.
- Username:
```csharp
var user = API.GetUser("username");
```
- UID:
```csharp
var user = API.GetUser(new UID("uid"));
```

If you're wanting to get a user's BR stats, you can simply use `.Stats.GetBRStatsAsync();` and it will return the requested stats.
```csharp
var user = API.GetUser("username");
var stats = await user.Stats.GetBRStatsAsync();
```

## BR.Store.GetStoreAsync()
The current store is a breeze to get using `GetStoreAsync()`. 
This is an `async` method though, so it will need to be used with `await`.
```csharp
var store = await API.BR.Store.GetStoreAsync();
```
This will return an `FNBRStore` object - which holds all the current in-store items.
You can also use `GetFeaturedStore()` and `GetDailyStore()` on the `FNBRStore` to return the corresponding in-store items.
```csharp
var daily = store.GetDailyStore();
var featured = store.GetFeaturedStore();
```
The `FNBRStore` also has the ability to get any upcoming items available but not yet in stores.
```csharp
var upcoming = await API.BR.Store.GetUpcomingItemsAsync();
```
If you are looking for an item that isn't currently in-stores, you can search for it!
```csharp
var item = await API.BR.Store.SearchItemAsync("ITEM NAME");
```
This will return a list of `FNBRSearchItem` which can be used to get more details on the item. 
For example, we can use it to get the occurrences of said item.
```csharp
var searchItem = API.BR.Store.SearchItemAsync("ITEM NAME").First();
var item = await API.BR.Store.GetItemAsync(searchItem.ItemID);
var occurrences = item.Occurrences;
```
>NOTE: The `SearchItemAsync` call does not consume your call count.

## BR.Challenges.GetChallengesAsync()
>NOTE: This won't expose any unreleased challenges.

This will return a list of `FNChallengeItem`. Which holds information about the challenge's name, stars required and difficulty.
You can check which the current week for challenges like so:
```csharp
var challenges = API.BR.Challenges.GetChallengesAsync();
```

## BR.Leaderboard.GetLeaderboardAsync()
In Battle Royale, there are Global Leaderboards. You can get these using the API, quick easily!
Using `GetLeaderboardAsync()` will return a list of `FNLeaderboardItem`. 
```csharp
var leaderboard = await API.BR.Leaderboard.GetLeaderboardAsync();
```
This includes information about each leaderboard entry. However, from this, you can then use `GetUser()` to return a `FNBRUser` object based on the leaderboard entry - this can then be used to look up the players stats.
```csharp
	var leaderboardItem = await API.BR.Leaderboard.GetLeaderboardAsync().First();
	var user = leaderboardItem.GetUser();
	var userStats = await user.Stats.GetBRStatsAsync();
```

## BR.News.GetNewsAsync()
This returns a list of `FNNewsItem`. This holds the Title, Body and Image for the BR MOTD. 
```csharp
var news = await API.BR.News.GetNewsAsync();
```

## STW.News.GetNewsAsync()
This returns a list of `FNNewsItem`. This holds the Title, Body and Image for the STW MOTD.
```csharp
var news = await API.STW.News.GetNewsAsync();
```

## Patchnotes.GetPatchnotesAsync()
Want the latest patchnotes? Use this simple call to get data from the Patchnotes. This includes: `title`,`description`, `images` and an `ExternalLink` to the patchnotes page.
```csharp
var patchnotes = await API.Patchnotes.GetPatchnotesAsync();
```

## GetCurrentVersion()
Returns the current Game Version.
```csharp
var version = API.GetCurrentVersion();
```

## GetStatusAsync()
Need to check whether servers are up and running? Simply use the `GetStatusAsync()` method.
```csharp
var status = await API.GetStatusAsync();
```

## GetCurrentWeek()
Returns the current Week.
```csharp
var week = API.GetCurrentWeek();
```

Returns the current Season.
## GetCurrentSeason()
```csharp
var season = API.GetCurrentSeason();
```
