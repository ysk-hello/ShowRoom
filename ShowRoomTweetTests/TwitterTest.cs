using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowRoomTweet;
using System;
using System.IO;

namespace ShowRoomTweetTests
{
    [TestClass]
    public class TwitterTest
    {
        private Twitter _twitter;

        [TestInitialize]
        public void 初期化()
        {
            // 設定の読み込み
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            // Twitterオブジェクトの生成
            _twitter = new Twitter(config["Twitter:ConsumerKey"], config["Twitter:ConsumerSecret"],
                config["Twitter:AccessToken"], config["Twitter:AccessSecret"]);
        }

        [TestMethod]
        public void つぶやく()
        {
            _twitter.Tweet(DateTime.Now.ToString());
        }

        [TestMethod]
        public void タイムラインを取得する()
        {
            _twitter.GetTimeline();
        }

        [TestMethod]
        public void ツイートを検索する()
        {
            _twitter.SearchTweets(10, "hello");
        }
    }
}
