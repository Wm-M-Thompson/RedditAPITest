namespace ThompsonSolutions.Reddit.Models
{
    public record MessageModel
    {
        public string MessageID { get; init; }
        public string Content { get; init; }

        public MessageModel(string messageID, string content)
        {
            MessageID = messageID;
            Content = content;
        }
    }
}