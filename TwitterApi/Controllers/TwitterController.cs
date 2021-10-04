using Microsoft.AspNetCore.Mvc;
using TwitterApi.Core.Services;

namespace TwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TwitterController : ControllerBase
    {
        private readonly ITweetService tweetService;

        public TwitterController(ITweetService tweet)
        {
            tweetService = tweet;
        }

        [HttpGet]
        public int GetTweetTotal()
        {
            return tweetService.GetCreationCount();
        }

        [HttpGet]
        public double GetTweetAveragePerMinute()
        {
            return tweetService.GetAverageTweetPerMinute();
        }

    }
}
