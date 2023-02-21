using ThompsonSolutions.Reddit.Core;
using Microsoft.AspNetCore.Mvc;

namespace ThompsonSolutions.Reddit.API
{
    [Route("api")]
    public class RedditStreamController : ControllerBase
    {
        private readonly IMessageService _svc;

        public RedditStreamController(IMessageService svc)
        {
            _svc = svc;
        }

        [HttpGet("count")]
        public async Task<int> GetMessageCount()
            => await _svc.GetMessageCount();

        [HttpGet("tophashtags")]
        public async Task<List<string>> GetTopHashtags()
            => await _svc.GetTopHashtags();
    }
}