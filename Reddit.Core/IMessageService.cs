using ThompsonSolutions.Reddit.Models;

namespace ThompsonSolutions.Reddit.Core
{
    public interface IMessageService
    {
        Task ProcessMessage(MessageModel Message);
        Task<List<string>> GetTopHashtags();
        Task<int> GetMessageCount();
    }
}