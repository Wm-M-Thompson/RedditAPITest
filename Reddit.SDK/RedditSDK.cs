using System.Text.Json;

namespace ThompsonSolutions.Reddit.SDK
{
    /// <summary>
    /// SDK for consuming the RedditStreamController's API Endpoints
    /// </summary>
    public class RedditSDK : IRedditSDK
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Construct the SDK with your favorite HttpClient!
        /// </summary>
        /// <param name="client">HTTP Client with a required configuration of the BaseAddress</param>
        public RedditSDK(HttpClient client)
        {
            _client = client;
        }

        /// <summary>
        /// Contacts the Thompson Solutions Reddit API to retrieve the Count.
        /// </summary>
        /// <returns>Endpoint to retrieve the unread conversation count by conversation state.</returns>
        public async Task<int> GetCount()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/mod/conversations/unread/count ");
            var result = await _client.SendAsync(request);
            var data = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<int>(data)!;
        }

        // <summary>
        // Contacts the Thompson Solutions Reddit API to retrieve data.
        // </summary>
        // <returns>a list of strings </returns>
        //public async Task<List<string>> GetWhere() 
        //{
          //  return List<string> GetWhere(where.comments, "");
        //}
        // <summary>
        // Contacts the Thompson Solutions Reddit API to retrieve data.
        // </summary>
        // <returns>a list of strings </returns>
        //public async Task<List<string>> GetWhere(where w, string username) 
       // {
         //   var request = new HttpRequestMessage(HttpMethod.Get, "user/" + username + "/" + w);
         //   var result = await _client.SendAsync(request);
         //   var data = await result.Content.ReadAsStringAsync();
         //   return JsonSerializer.Deserialize<List<string>>(data)!;
       // }
        
        /// <summary>
        /// Contacts the Thompson Solutions Reddit API to retrieve data.
        /// </summary>
        /// <returns>a list of strings </returns>
        public async Task<List<string>> GetBest()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "best/");
            var result = await _client.SendAsync(request);
            var data = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<string>>(data)!;
        }


    }
}