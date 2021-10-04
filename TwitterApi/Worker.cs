using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TwitterApi.Core.Services;
using TwitterApi.Infrastructure.Services;

namespace TwitterApi
{
    public class Worker : IWorker
    {
        private readonly ILogger<Worker> logger;
        private readonly ITwitterService twitterService;
        private readonly ITweetService tweetService;
        private int previousCount = 0;

        public Worker(ILogger<Worker> logger, ITwitterService twitter, ITweetService tweet)
        {
            this.logger = logger;
            twitterService = twitter;
            tweetService = tweet;
        }

        public async Task StartStream(CancellationToken cancellationToken)
        {
            try
            {
                var stream = twitterService.StartTwitterSampleStream();
                stream.TweetReceived += (sender, arge) =>
                {
                    if (!(arge.Tweet == null))
                    {
                    tweetService.TweetRecieved();
                    }
                };
                stream.EventReceived += (sender, EventArgs) =>
                {
                    if (EventArgs.Json.Contains("Unauthorized"))
                    {
                        stream.StopStream();
                        logger.LogInformation("Login Failure:  Please stop application and check credentials.");
                    }
                };

                while (!cancellationToken.IsCancellationRequested)
                {
                    var count = tweetService.GetCreationCount();
                    logger.LogInformation($"Stream is running current count is: {count}");
                    if (count == previousCount && previousCount != 0)
                    {
                        logger.LogInformation($"Stream is stopped - restarting");
                        twitterService.StartTwitterStream(ref stream);
                    }
                    previousCount = count;

                    await Task.Delay(1000 * 5);
                }
            }
            catch (Exception ex)
            {
                logger.LogInformation($"Stream has failed with exception: {ex}");
            }
        }

    }
}