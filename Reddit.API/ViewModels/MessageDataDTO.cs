#pragma warning disable IDE1006 // DTO's don't follow the same naming conventions
namespace ThompsonSolutions.Reddit.API
{
    public record MessageDataDTO
    {
        public MessageDTO? data { get; set; }
    }
}