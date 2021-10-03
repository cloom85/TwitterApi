using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using TwitterApi.Core.Services;

namespace TwitterApi.Test.Unit
{
    [TestClass]
    public class TweetServiceTests
    {
        [TestMethod]
        public void TestCount()
        {
            var dateTime = Substitute.For<IDateTime>();
            dateTime.Now().ReturnsForAnyArgs(new DateTime(2001, 1, 1));
            var service = new TweetService(dateTime);
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
    }
}
