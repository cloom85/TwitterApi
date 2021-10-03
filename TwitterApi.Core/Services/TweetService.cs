using System;

namespace TwitterApi.Core.Services
{
    public class TweetService : ITweetService
    {
        private static int creationCount = 0;
        private static DateTime creationDate = new DateTime();
        private static IDateTime mDateTime;

        public TweetService(IDateTime dateTime)
        {
            mDateTime = dateTime;
            creationDate = mDateTime.Now();
        }

        public int GetCreationCount() => creationCount;
        public DateTime GetCreationDate() => creationDate;
        public void TweetRecieved() => creationCount++;

        public double GetAverageTweetPerMinute()
        {
            TimeSpan ts = mDateTime.Now() - GetCreationDate();
            return (GetCreationCount() / ts.TotalMinutes);
        }
    }
}
