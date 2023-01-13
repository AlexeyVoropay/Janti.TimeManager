using System;
using Microsoft.AspNetCore.Mvc;

namespace TimeManagerWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimeManagerController : ControllerBase
    {
        private readonly ITimeManager _timeManager;

        public TimeManagerController(ITimeManager timeManager)
        {
            _timeManager = timeManager;
        }

        [HttpGet("GetTime")]
        public string GetTime()
        {
            return _timeManager.GetTime();
        }

        [HttpPost("SetTimeZone")]
        public bool SetTimeZone(string olsonTimeZone)
        {
            return _timeManager.SetTimeZone(olsonTimeZone);
        }

        [HttpPost("ConvertDate")]
        public string ConvertDate(string dateTime)
        {
            return _timeManager.ConvertDate(dateTime);
        }
    }
}