using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterApi.Core.Services;

namespace TwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TwitterController : ControllerBase
    {

        private readonly ILogger<TwitterController> _logger;
        private readonly ITweetService mysingleton;

        public TwitterController(ILogger<TwitterController> logger, ITweetService singleton)
        {
            _logger = logger;
            mysingleton = singleton;
        }

        [HttpGet]
        public int GetTweetTotal()
        {
            return mysingleton.GetCreationCount();
        }

        [HttpGet]
        public double GetTweetAverage()
        {
            TimeSpan ts = DateTime.Now - mysingleton.GetCreationDate();
            return (mysingleton.GetCreationCount() / ts.TotalMinutes);
        }
    }
}
