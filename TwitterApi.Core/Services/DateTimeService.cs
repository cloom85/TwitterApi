using System;

namespace TwitterApi.Core.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now() => DateTime.Now;
    }
}
