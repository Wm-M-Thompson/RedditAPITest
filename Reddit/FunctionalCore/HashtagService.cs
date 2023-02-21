using System.Text.RegularExpressions;

namespace ThompsonSolutions.Reddit.FunctionalCore
{
    public class HashtagService
    {
        const string HASHTAG_LETTERS = @"\p{L}\p{M}";
        const string HASHTAG_NUMERALS = @"\p{Nd}";
        const string HASHTAG_SPECIAL_CHARS = @"_\u200c\u200d\ua67e\u05be\u05f3\u05f4\uff5e\u301c\u309b\u309c\u30a0\u30fb\u3003\u0f0b\u0f0c\u00b7";
        const string HASHTAG_LETTERS_NUMERALS = HASHTAG_LETTERS + HASHTAG_NUMERALS + HASHTAG_SPECIAL_CHARS;
        const string HASHTAG_LETTERS_NUMERALS_SET = "[" + HASHTAG_LETTERS_NUMERALS + "]";
        const string HASHTAG_LETTERS_SET = "[" + HASHTAG_LETTERS + "]";

        public static List<string> GetValidHashtags(string inputText)
        {
            return Regex.Matches(inputText, "(^|[^&" + HASHTAG_LETTERS_NUMERALS + @"])(#|\uFF03)(?!\uFE0F|\u20E3)(" + HASHTAG_LETTERS_NUMERALS_SET + "*" + HASHTAG_LETTERS_SET + HASHTAG_LETTERS_NUMERALS_SET + "*)").OfType<Match>().Select(x => x.Value.Trim()).ToList();
        }
    }
}