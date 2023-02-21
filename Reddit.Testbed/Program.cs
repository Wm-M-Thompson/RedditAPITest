using ThompsonSolutions.Reddit.SDK;

namespace ThompsonSolutions.Reddit.Testbed
{
    public class Program
    {
        public static async Task Main()
        {
            // Start the service first "Without Debugging"
            // Then run this testbed as a new instance.
            // This is in place of real automated testing.

            var client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:65510")
            };

            var sut = new RedditSDK(client);

            await Task.Delay(5000);
            var result = await sut.GetCount();
            Console.WriteLine(result > 0 ? "Success" : "Failure");
        }
    }
}