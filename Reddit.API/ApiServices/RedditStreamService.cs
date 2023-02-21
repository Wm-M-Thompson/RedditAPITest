using ThompsonSolutions.Reddit.Core;
using ThompsonSolutions.Reddit.Models;
using ThompsonSolutions.Utilities;
using System.Text.Json;

namespace ThompsonSolutions.Reddit.API
{
    public partial class RedditStreamService : BackgroundService
    {
        const int Message_LEN_X2 = 560;

        private readonly IMessageService _svc;
        private readonly HttpClient _client;
        private readonly string _streamEndpoint;
        private readonly ILogger _logger;

        public RedditStreamService(IMessageService svc, HttpClient client, string streamEndpoint, ILogger<RedditStreamService> logger)
        {
            _svc = svc;
            _client = client;
            _streamEndpoint = streamEndpoint;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                try
                {
                    using var response = await _client.GetAsync(_streamEndpoint, HttpCompletionOption.ResponseHeadersRead, stoppingToken);
                    using var responseStream = await response.Content.ReadAsStreamAsync(stoppingToken);
                    using var reader = new StreamReader(responseStream);
                    while (false == reader.EndOfStream)
                    {
                        var maybeMessage = DeserializeMessage(reader.ReadLine());
                        if (null != maybeMessage.Exception)
                            _logger.LogError(maybeMessage.Exception, "Error with Deserialization: {msg}", maybeMessage.Message);
                        else if (false == maybeMessage.HasValue)
                            _logger.LogError("Error with Deserialization: {msg}", maybeMessage.Message);
                        else
                            await _svc.ProcessMessage(maybeMessage.Value);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error with Reddit stream");
                }
            }
        }

        public static Maybe<MessageModel> DeserializeMessage(string? line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return Maybe<MessageModel>.None("Line was empty");

            try
            {
                var MessageData = JsonSerializer.Deserialize<MessageDataDTO>(line);
                if (MessageData == null || MessageData.data == null || MessageData.data.text == null || MessageData.data.id == null)
                    return Maybe<MessageModel>.None("Received a line with data, but data was null: " + line.Truncate(Message_LEN_X2));

                return Maybe<MessageModel>.Some(new MessageModel(MessageData.data.id, MessageData.data.text));
            }
            catch (Exception ex)
            {
                return Maybe<MessageModel>.None(ex, "Error getting Message from Stream: " + line.Truncate(Message_LEN_X2));
            }
        }
    }
}