using System.IO;
using System.Linq;
using Newtonsoft.Json;
using NUnit.Framework;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.UnitTests
{
    public class TwitchTest
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ResponseDataShouldNeverBeNull()
        {
            var content = File.ReadAllText("Assets/Response/TwitchDataResponse.json");
            var json = JsonConvert.DeserializeObject<TwitchDataResponse>(content);

            Assert.IsNotNull(json);
        }

        [Test]
        public void ResponseDataOfGameMustHaveGameId()
        {
            var content = File.ReadAllText("Assets/Response/TwitchDataResponse.json");
            var json = JsonConvert.DeserializeObject<TwitchDataResponse>(content);

            Assert.IsNotNull(json);

            foreach (var id in json.Data.Where(id => id.GameId == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataOfGameMustHaveUserId()
        {
            var content = File.ReadAllText("Assets/Response/TwitchDataResponse.json");
            var json = JsonConvert.DeserializeObject<TwitchDataResponse>(content);

            Assert.IsNotNull(json);

            foreach (var id in json.Data.Where(id => id.UserId == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataOfGameMustHaveId()
        {
            var content = File.ReadAllText("Assets/Response/TwitchDataResponse.json");
            var json = JsonConvert.DeserializeObject<TwitchDataResponse>(content);

            Assert.IsNotNull(json);

            foreach (var id in json.Data.Where(id => id.Id == null))
            {
                Assert.Fail();
            }
        }

        [Test]
        public void ResponseDataWithLanguageParameterMustReturnOnlyStreamsWithThisLanguage()
        {
            var content = File.ReadAllText("Assets/Response/TwitchDataLanguagePLResponse.json");
            var json = JsonConvert.DeserializeObject<TwitchDataResponse>(content);

            Assert.IsNotNull(json);

            int counter = File.ReadAllLines("Assets/Response/TwitchDataLanguagePLResponse.json")
                .Count(line => line.Contains("\"language\": \"pl\","));

            Assert.AreEqual(20, counter);
        }
    }
}