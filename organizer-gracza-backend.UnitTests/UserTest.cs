using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NUnit.Framework;
using organizer_gracza_backend.Controllers;
using organizer_gracza_backend.Data;
using organizer_gracza_backend.Interfaces;
using organizer_gracza_backend.Model;

namespace organizer_gracza_backend.UnitTests
{
    public class UserTest
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;
        private UsersController _usersController;

        
        [SetUp]
        public void Setup()
        {
            _usersController = new UsersController(_userRepository,_mapper, _photoService);
        }

        [Test]
        public void CheckIfSteamIdIsInValidFormatLettersInvalid()
        {
            var query = _usersController.IsValidSteamid("ABCDEF");
            Assert.IsFalse(query);
        }
        [Test]
        public void CheckIfSteamIdIsInValidFormatDigitsValid()
        {
            var query = _usersController.IsValidSteamid("1234567");
            Assert.IsTrue(query);
        }
        [Test] 
        public void CheckIfSteamIdIsInValidFormatPunctuationValid()
        {
            var query = _usersController.IsValidSteamid("1234/567");
            Assert.IsFalse(query);
        }
        [Test] 
        public void CheckIfSteamIdIsInValidFormatLettersAndDigitsValid()
        {
            var query = _usersController.IsValidSteamid("123B4A567");
            Assert.IsFalse(query);
        }
        [Test] 
        public void CheckIfSteamIdIsInValidFormatDigitsAndPunctuationValid()
        {
            var query = _usersController.IsValidSteamid("123/4567");
            Assert.IsFalse(query);
        }
    }
}