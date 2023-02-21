using ThompsonSolutions.Reddit.Core;
using ThompsonSolutions.Reddit.Models;
using System.Text.Json;
using ThompsonSolutions.Reddit.Data.Core;
using ThompsonSolutions.Reddit.Data.Entities;
using ThompsonSolutions.Reddit.FunctionalCore;

namespace ThompsonSolutions.Reddit
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepo _repo;

        public MessageService(IMessageRepo repo)
        {
            _repo = repo;
        }

        public async Task ProcessMessage(MessageModel Message)
        {
            var hashtags = HashtagService.GetValidHashtags(Message.Content);
            var MessageEntity = new MessageEntity
            {
                Id = Message.MessageID,
                Content = Message.Content,
                Hashtags = JsonSerializer.Serialize(hashtags)
            };
            await _repo.AddMessage(MessageEntity);
        }

        public async Task<List<string>> GetTopHashtags()
            => await _repo.GetTopHashtags();

        public async Task<int> GetMessageCount()
            => await _repo.GetMessageCount();
    }
}