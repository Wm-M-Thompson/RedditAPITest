namespace ThompsonSolutions.Reddit.Data.Entities
{
    public record MessageEntity
    {
        public string? Id { get; set; }
        public string? Content { get; set; }
        public string? Hashtags { get; set; }
    }
}