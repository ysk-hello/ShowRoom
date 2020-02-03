using CoreTweet;
using System;

namespace ShowRoomTweet
{
    public class Twitter
    {
        private Tokens _tokens;

        public Twitter(string consumerKey, string consumerSecret, string accessToken, string accessSecret)
        {
            _tokens = Tokens.Create(consumerKey, consumerSecret, accessToken, accessSecret);
        }

        public void Tweet(string text)
        {
            try
            {
                _tokens.Statuses.Update(status => text);
            }
            catch (TwitterException te)
            {

            }
        }

        public void GetTimeline()
        {
            var timeline = _tokens.Statuses.HomeTimeline();

            foreach(var t in timeline)
            {
                Console.WriteLine(t.Text);
            }
        }

        public async void SearchTweets(int cnt, string keyword)
        {
            var tweets = await _tokens.Search.TweetsAsync(count => cnt, q => keyword);

            foreach(var t in tweets)
            {
                Console.WriteLine("{0} {1}", t.User.ScreenName, t.Text);
            }
        }
    }
}
