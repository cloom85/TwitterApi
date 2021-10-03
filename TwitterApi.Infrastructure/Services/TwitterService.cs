using System;
using Tweetinvi;
using Tweetinvi.Models;
using TwitterApi.Core;
using TwitterApi.Entities;

namespace TwitterApi.Infrastructure.Services
{
    public class TwitterService : ITwitterService
    {

        private Settings mSettings { get; }
        public TwitterService(Settings settings)
        {
            mSettings = settings;
        }
        public Tweetinvi.Streaming.V2.ISampleStreamV2 StartTwitterSampleStream()
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

        public void StartTwitterStream(ref Tweetinvi.Streaming.V2.ISampleStreamV2 twitterStream)
        {
            twitterStream.StartAsync();
        }

    }
}
