using Tweetinvi.Streaming.V2;

namespace TwitterApi.Infrastructure.Services
{
    public interface ITwitterService
    {
        ISampleStreamV2 StartTwitterSampleStream();
        void StartTwitterStream(ref ISampleStreamV2 twitterStream);

    }
}