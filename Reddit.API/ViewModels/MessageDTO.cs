#pragma warning disable IDE1006 // DTO's don't follow the same naming conventions
namespace ThompsonSolutions.Reddit.API
{
    public record MessageDTO
    {
        public string? id { get; set; }
        public List<string>? edit_history_Message_ids { get; set; }
        public string? text { get; set; }
    }
}