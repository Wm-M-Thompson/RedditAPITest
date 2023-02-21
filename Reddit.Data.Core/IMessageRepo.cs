using ThompsonSolutions.Reddit.Data.Entities;

namespace ThompsonSolutions.Reddit.Data.Core
{
    public interface IMessageRepo
    {
        Task AddMessage(MessageEntity Message);
        Task<List<string>> GetTopHashtags();
        Task<int> GetMessageCount();
    }
}