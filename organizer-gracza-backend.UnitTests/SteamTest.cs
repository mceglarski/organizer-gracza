using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.UnitTests
{
    public class SteamTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ResponseDataShouldNeverBeNull()
        {
            var content = File.ReadAllText("Assets/Response/SteamUserResponse.json");
            var json = JsonConvert.DeserializeObject<SteamUserResponse>(content);

            Assert.IsNotNull(json);
        }

        [Test]
        public void ResponseDataOfSteamUserMustHaveSteamId()
        {
            var content = File.ReadAllText("Assets/Response/SteamUserResponse.json");
            var json = JsonConvert.DeserializeObject<SteamUserResponse>(content);

            Assert.IsNotNull(json);

            foreach (var id in json.Response.Players.Where(id => id.SteamId == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataOfFriendsMustHaveSteamIds()
        {
            var content = File.ReadAllText("Assets/Response/SteamUserFriendsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamUserFriendsResponse>(content);

            Assert.IsNotNull(json);

            foreach (var id in json.FriendsList.Friends.Where(id => id.SteamId == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataOfUserGamesMustHaveAppId()
        {
            var content = File.ReadAllText("Assets/Response/SteamUserGamesResponse.json");
            var json = JsonConvert.DeserializeObject<SteamUserGamesResponse>(content);

            Assert.IsNotNull(json);

            foreach (var id in json.Response.Games.Where(id => id.AppId == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataOfNewsAboutGameMustHaveAppIdEqualsToParameterValue()
        {
            var parameter = 730;

            var content = File.ReadAllText("Assets/Response/SteamGameNewsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamNewsResponse>(content);

            Assert.IsNotNull(json);

            var query = json.AppNews.AppId;
            if (parameter != query)
                Assert.Fail();
        }

        [Test]
        public void ResponseDataOfNewsAboutGameMustHaveAmoutOfNewsEqualsToCount()
        {
            var content = File.ReadAllText("Assets/Response/SteamGameNewsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamNewsResponse>(content);

            Assert.IsNotNull(json);

            int count = json.AppNews.NewsItems.Count;

            if (count != json.AppNews.Count)
                Assert.Fail();
        }

        [Test]
        public void ResponseDataOfNewsAboutGameMustHaveAppIdInsideNews()
        {
            var content = File.ReadAllText("Assets/Response/SteamGameNewsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamNewsResponse>(content);

            Assert.IsNotNull(json);

            foreach (var id in json.AppNews.NewsItems.Where(id => id.AppId == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataOfAchievementsMustHaveName()
        {
            var content = File.ReadAllText("Assets/Response/SteamGameAchievementsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamAchievementResponse>(content);

            Assert.IsNotNull(json);

            foreach (var name in json.AchievementPercentages.Achievements.Where(name => name.Name == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataOfAchievementsDetailsMustHaveGameName()
        {
            var content = File.ReadAllText("Assets/Response/SteamGameAchievementsDetailsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamAchievementDetailResponse>(content);

            Assert.IsNotNull(json);

            var query = json.Game.GameName;

            if (query == null)
                Assert.Fail();
        }
        
        [Test]
        public void ResponseDataOfAchievementsOfUserForSpecifiedGameMustHaveSteamId()
        {
            var content = File.ReadAllText("Assets/Response/SteamUserAndGameAchievementsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamUserAchievementResponse>(content);

            Assert.IsNotNull(json);

            var query = json.playerstats.SteamID;

            if (query == null)
                Assert.Fail();
        }
        
        [Test]
        public void ResponseDataOfAchievementsOfUserForSpecifiedGameMustHaveGameName()
        {
            var content = File.ReadAllText("Assets/Response/SteamUserAndGameAchievementsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamUserAchievementResponse>(content);

            Assert.IsNotNull(json);

            var query = json.playerstats.GameName;

            if (query == null)
                Assert.Fail();
        }
        
        [Test]
        public void ResponseDataOfAchievementsOfUserForSpecifiedGameMustHaveSteamIdEqualsToUserSteamId()
        {
            string userSteamId = "76561198006496927";
            
            var content = File.ReadAllText("Assets/Response/SteamUserAndGameAchievementsResponse.json");
            var json = JsonConvert.DeserializeObject<SteamUserAchievementResponse>(content);

            Assert.IsNotNull(json);

            var query = json.playerstats.SteamID;

            if (query != userSteamId)
                Assert.Fail();
        }
        
        [Test]
        public void ResponseDataOfDidntPlayedGamesMustHaveGamesEqualToNull()
        {
            
            var content = File.ReadAllText("Assets/Response/SteamRecentlyDidntPlayedResponse.json");
            var json = JsonConvert.DeserializeObject<SteamRecentlyPlayedResponse>(content);

            Assert.IsNotNull(json);

            var query = json.Response.Games;

            if (query != null)
                Assert.Fail();
        }
        
        [Test]
        public void ResponseDataOfDidntPlayedGamesMustHaveGamesEqualToNullAndTotalCountEquals0()
        {
            
            var content = File.ReadAllText("Assets/Response/SteamRecentlyDidntPlayedResponse.json");
            var json = JsonConvert.DeserializeObject<SteamRecentlyPlayedResponse>(content);

            Assert.IsNotNull(json);
            
            var gameValue = json.Response.Games;

            if (gameValue != null)
                Assert.Fail();

            var totalCountValue = json.Response.TotalCount;
            
            if(totalCountValue != 0)
                Assert.Fail();
        }
        
        [Test]
        public void ResponseDataOfDidntPlayedGamesMustHaveGamesAndTotalCount()
        {
            
            var content = File.ReadAllText("Assets/Response/SteamRecentlyPlayedResponse.json");
            var json = JsonConvert.DeserializeObject<SteamRecentlyPlayedResponse>(content);

            Assert.IsNotNull(json);
            
            var gameValue = json.Response.Games;

            if (gameValue == null)
                Assert.Fail();

            var totalCountValue = json.Response.TotalCount;
            
            if(totalCountValue == 0)
                Assert.Fail();
        }
    }
}