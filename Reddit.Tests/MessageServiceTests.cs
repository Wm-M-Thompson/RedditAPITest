using ThompsonSolutions.Reddit.FunctionalCore;
using Xunit;

namespace ThompsonSolutions.Reddit.Tests
{
    public class MessageServiceTests
    {
        [Theory]
        [InlineData("Random # Hashtag #hashtag", "#hashtag")]
        [InlineData("#Azərbaycanca", "#Azərbaycanca")]
        [InlineData("test before #mûǁae", "#mûǁae")]
        [InlineData("#Čeština test after", "#Čeština")]
        [InlineData("#Ċaoiṁín test after", "#Ċaoiṁín")]
        [InlineData("#Caoiṁín", "#Caoiṁín")]
        [InlineData("#táim", "#táim")]
        [InlineData("#hag̃ua", "#hag̃ua")]
        [InlineData("Random # Hashtag #café test after", "#café")]
        [InlineData("#עברית Random # Hashtag ", "#עברית")]
        [InlineData("#אֲשֶׁר", "#אֲשֶׁר")]
        [InlineData("test before #עַל־יְדֵי", "#עַל־יְדֵי")]
        [InlineData("#וכו׳", "#וכו׳")]
        [InlineData("test before #מ״כ", "#מ״כ")]
        [InlineData("#العربية", "#العربية")]
        [InlineData("#حالياً", "#حالياً")]
        [InlineData("test before #يـﮱـَٱ", "#يـﮱـَٱ")]
        [InlineData("Random # Hashtag #ประเทศไทย", "#ประเทศไทย")]
        [InlineData("#ฟรี", "#ฟรี")]
        [InlineData("#日本語ハッシュタグ", "#日本語ハッシュタグ")]
        [InlineData("＃日本語ハッシュタグ", "＃日本語ハッシュタグ")]
        [InlineData("これはOK #ハッシュタグ", "#ハッシュタグ")]
        [InlineData("これはダメ#ハッシュタグ", null)]
        [InlineData("#1 Random # Hashtag ", null)]
        [InlineData("#2", null)]
        public void GetValidHashtag(string input, string expected)
        {
            var result = HashtagService.GetValidHashtags(input);
            if (expected == null)
                Assert.Empty(result);
            else
                Assert.Equal(expected, result.Single());
        }

        [Theory]
        [InlineData("#startingHashtag Random # Hashtag #hashtag", "#startingHashtag", "#hashtag")]
        [InlineData("# spaces here Random #CaseSensitive #casesensitive", "#CaseSensitive", "#casesensitive")]
        [InlineData("something #hashtag1, comma#midArea, #hashtag2", "#hashtag1", "#hashtag2")]
        public void GetValidHashtags(string input, params string[] expecteds)
        {
            var result = HashtagService.GetValidHashtags(input);
            Assert.Equal(expecteds.Length, result.Count);
            foreach (var expected in expecteds)
                Assert.Contains(expected, result);
        }
    }
}