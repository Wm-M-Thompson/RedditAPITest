using ThompsonSolutions.Reddit.Data.Core;
using ThompsonSolutions.Reddit.Data.Entities;
using System.Collections.Concurrent;
using System.Text.Json;

namespace ThompsonSolutions.Reddit.Data
{
    public class MessageRepo : IMessageRepo
    {
        private static int _MessagesReceived;
        private static readonly ConcurrentDictionary<string, int> _topHashtags = new();

        public Task AddMessage(MessageEntity Message)
        {
            Interlocked.Increment(ref _MessagesReceived);
            if (Message.Hashtags != null)
            {
                var hashtags = JsonSerializer.Deserialize<List<string>>(Message.Hashtags);
                if (hashtags != null)
                    for (var i = 0; i < hashtags.Count; i++)
                        _topHashtags.AddOrUpdate(hashtags[i], 0, (y, z) => z + 1);
            }
            return Task.CompletedTask;
        }

        public Task<List<string>> GetTopHashtags()
            => Task.FromResult(_topHashtags.OrderByDescending(x => x.Value).Take(10).Select(x => x.Key).ToList());

        public Task<int> GetMessageCount()
            => Task.FromResult(_MessagesReceived);
    }
}