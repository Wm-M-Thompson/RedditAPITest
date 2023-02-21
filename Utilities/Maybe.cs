namespace ThompsonSolutions.Utilities
{
    public class Maybe<T>
    {
        public T Value { get; set; } = default!;
        public bool HasValue { get; set; }
        public string? Message { get; set; }
        public Exception? Exception { get; set; }

        public static Maybe<T> Some(T input)
            => new() { Value = input, HasValue = true };

        public static Maybe<T> None(string reason)
            => new() { Message = reason };

        public static Maybe<T> None(Exception ex, string reason)
            => new() { Exception = ex, Message = reason };
    }
}