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
        public void ������()
        {
            // �ݒ�̓ǂݍ���
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            // Twitter�I�u�W�F�N�g�̐���
            _twitter = new Twitter(config["Twitter:ConsumerKey"], config["Twitter:ConsumerSecret"],
                config["Twitter:AccessToken"], config["Twitter:AccessSecret"]);
        }

        [TestMethod]
        public void �Ԃ₭()
        {
            _twitter.Tweet(DateTime.Now.ToString());
        }

        [TestMethod]
        public void �^�C�����C�����擾����()
        {
            _twitter.GetTimeline();
        }

        [TestMethod]
        public void �c�C�[�g����������()
        {
            _twitter.SearchTweets(10, "hello");
        }
    }
}
