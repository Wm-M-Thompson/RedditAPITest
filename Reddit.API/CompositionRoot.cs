using ThompsonSolutions.Reddit.Core;
using ThompsonSolutions.Reddit.Data;
using ThompsonSolutions.Reddit.Data.Core;

namespace ThompsonSolutions.Reddit.API
{
    public class CompositionRoot
    {
        public static void Compose(IServiceCollection sc, IConfigurationRoot config)
        {
            sc.AddTransient<IMessageService>(x => new MessageService(x.GetRequiredService<IMessageRepo>()));
            sc.AddTransient<IMessageRepo>(x => new MessageRepo());

            sc.AddHttpClient(nameof(RedditStreamService), client =>
            {
                var token = config.GetValue<string>("RedditToken");
                client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + token);
            });

            sc.AddHostedService(x =>
            {
                var streamEndpoint = config.GetValue<string>("StreamEndpoint");
                var factory = x.GetRequiredService<IHttpClientFactory>();
                var client = factory.CreateClient(nameof(RedditStreamService));
                return new RedditStreamService(x.GetRequiredService<IMessageService>(), client,streamEndpoint, x.GetRequiredService<ILogger<RedditStreamService>>());
            });
        }
    }
}