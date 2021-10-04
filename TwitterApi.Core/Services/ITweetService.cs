using System;

namespace TwitterApi.Core.Services
{
    public interface ITweetService
    {
        int GetCreationCount();
        DateTime GetCreationDate();
        void TweetRecieved();
        double GetAverageTweetPerMinute();

    }
}