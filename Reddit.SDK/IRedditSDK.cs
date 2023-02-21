namespace ThompsonSolutions.Reddit.SDK
{
     enum where
    {
        overview,
        submitted,
        comments,
        upvoted,
        downvoted,
        hidden,
        saved,
        gilded
    }
    /// <summary>
    /// Mockable SDK interface to set the contract of consuming the RedditStreamController API endpoints
    /// </summary>
    public interface IRedditSDK
    {

        /// <summary>
        /// Contacts the Thompson Solutions Reddit API to retrieve the Count.
        /// </summary>
        /// <returns>Endpoint to retrieve the unread conversation count by conversation state.  </returns>
        Task<int> GetCount();

        /// <summary>
        /// Contacts the Thompson Solutions Reddit API to retrieve:
        /// </summary>
        /// <returns>a list of strings </returns>
        Task<List<string>> GetBest();

        // <summary>
        // Contacts the Thompson Solutions Reddit API to retrieve:
        // → /user/username/overview
        // → /user/username/submitted
        // → /user/username/comments
        // → /user/username/upvoted
        // → /user/username/downvoted
        // → /user/username/hidden
        // → /user/username/saved
        // → /user/username/gilded
        // </summary>
        // <returns>a list of strings </returns>
        //Task<List<string>> GetWhere();// where w, string username);
    }
}