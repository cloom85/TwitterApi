using Microsoft.VisualStudio.TestTools.UnitTesting;
using TwitterApi.Infrastructure.Services;

namespace TwitterApi.Test.Unit
{
    [TestClass]
    public class TwitterServiceTests
    {
        [TestMethod]
        public void TestStartTwitterSampleStream()
        {
            var settings = GetSettings();
            var service = new TwitterService(settings);

            var stream = service.StartTwitterSampleStream();
            
            Assert.IsNotNull(stream);
        }

        private Core.Settings GetSettings() => new Core.Settings
        {
            ConsumerKey = "",
            ConsumerSecret = "",
            BearerToken = ""
        };
    }
}
