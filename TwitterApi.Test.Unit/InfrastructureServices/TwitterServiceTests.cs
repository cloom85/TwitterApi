using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using TwitterApi.Core.Services;
using TwitterApi.Infrastructure.Services;

namespace TwitterApi.Test.Unit
{
    [TestClass]
    public class TwitterServiceTests
    {
        [TestMethod]
        public void TestStartTwitterSampleStreamPass()
        {
            var settings = GetSettings();
            var service = new TwitterService(settings);

            service.TweetRecieved();
            var count = service.GetCreationCount();
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void TestDate()
        {
            var dateTime = Substitute.For<IDateTime>();
            dateTime.Now().ReturnsForAnyArgs(new DateTime(2001, 1, 1));
            var service = new TweetService(dateTime);
            var date = service.GetCreationDate();
            Assert.AreEqual(new DateTime(2001, 1, 1), date);
        }

        private Core.Settings GetSettings() => new Core.Settings
        {
            ConsumerKey = "",
            ConsumerSecret = "",
            BearerToken = ""
        };
    }
}
