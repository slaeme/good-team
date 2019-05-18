using System;
using System.Linq;
using System.Threading.Tasks;
using Common;
using GT.Interfaces;
using GT.Interfaces.Storage;
using GT.Models;
using GT.Storage;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private IDeedStorage _deedStorage;
        private IUserStorage _userStorage;
        [SetUp]
        public void Setup()
        {
            _deedStorage = new DeedStorage();
            _userStorage = new UserStorage();
        }


        [Test]
        public void GetDeeds()
        {
            var deeds = AsyncExecutionHelper.RunSync(async () => await _deedStorage.GetAllAsync());
        }

        [Test]
        public void CreateUser()
        {
            AsyncExecutionHelper.RunSync(async () => await _userStorage.CreateAsync(new User {Name = "Tom"}));
            
            Assert.AreEqual(true,true);
        }

        [Test]
        public void CreateDeed()
        {
            var rand = new Random();

            var userFirst = AsyncExecutionHelper.RunSync(async ()=>await _userStorage.GetAsync(null));
            AsyncExecutionHelper.RunSync(async () => await _deedStorage.CreateAsync(new Deed
            {
                Name = "Test sasaasasas",
                DescriptionPublic = "Public description",
                DescriptionPrivate = "Private description",
                UserId = userFirst.UserId,
                //User = userFirst
                Latitude = rand.Next(10, 100),
                Longitude = rand.Next(10, 100),
            }));

            Assert.AreEqual(true, true);
        }
    }
}