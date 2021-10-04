using Tweetinvi;
using Tweetinvi.Models;
using TwitterApi.Core;
using Tweetinvi.Streaming.V2;

namespace TwitterApi.Infrastructure.Services
{
    public class TwitterService : ITwitterService
    {
        private Settings mSettings { get; }
        public TwitterService(Settings settings)
        {
            mSettings = settings;
        }

        public ISampleStreamV2 StartTwitterSampleStream()
        {
            var appCredentials = new ConsumerOnlyCredentials(mSettings.ConsumerKey, mSettings.ConsumerKey)
            {
                BearerToken = mSettings.BearerToken
            };
            var appClient = new TwitterClient(appCredentials);
            var twitterStream = appClient.StreamsV2.CreateSampleStream();
            StartTwitterStream(ref twitterStream);

            return twitterStream;
        }

        public void StartTwitterStream(ref ISampleStreamV2 twitterStream)
        {
            twitterStream.StartAsync();
        }

    }
}
