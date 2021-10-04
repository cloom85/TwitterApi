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
            var count = service.GetCreationCount();
            service.TweetRecieved();
            var newCount = service.GetCreationCount();
            Assert.AreEqual(newCount, (count+1));
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

        [TestMethod]
        public void TestAverage()
        {
            var dateTime = Substitute.For<IDateTime>();
            dateTime.Now().ReturnsForAnyArgs(new DateTime(2001, 1, 1));
            var service = new TweetService(dateTime);
            var startDate = service.GetCreationDate();
            var currentDate = startDate.AddMinutes(5);
            dateTime.Now().ReturnsForAnyArgs(currentDate);
            for (int i=0; i<25; i++)
            {
            service.TweetRecieved();
            }
            var count = service.GetAverageTweetPerMinute();
            Assert.AreEqual(count,5);
        }

    }
}
