﻿using Microsoft.Extensions.Configuration;
using ShowRoomConsole.IO;
using ShowRoomConsole.Models;
using ShowRoomTweet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShowRoomConsole
{
    /// <summary>
    /// Programクラスです。
    /// </summary>
    class Program
    {
        /// <summary>
        /// Mainメソッドです。
        /// </summary>
        /// <param name="args">コマンドライン引数</param>
        static void Main(string[] args)
        {
            // 設定の読み込み
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");

            var config = builder.Build();

            // Twitterオブジェクトの生成
            var twitter = new Twitter(config["Twitter:ConsumerKey"], config["Twitter:ConsumerSecret"],
                config["Twitter:AccessToken"], config["Twitter:AccessSecret"]);

            // ルームIdの読み込み
            var roomIds = CsvReader.ReadRoomIds(@"..\..\..\Data\RoomIds.csv");

            // 出力ファイル名
            var fileName = "followers_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xml";

            var rooms = new List<Room>();
            foreach (var id in roomIds)
            {
                // ルームの作成
                var room = Room.CreateRoom(id).Result;

                // ルームを追加
                rooms.Add(room);

                // ルームを出力ファイルに追加
                XmlWriter.Append(Path.Combine(fileName), room);

                // コンソールに出力
                Console.WriteLine($"{room.Name} {room.FollowerNum}");
            }

            // フォロワー数順に並べる
            rooms = rooms.OrderByDescending(r => r.FollowerNum).ToList();

            // ツイートする内容
            var text = DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine;
            foreach (var r in rooms.Take(5))
            {
                text += $"{r.Name} {r.FollowerNum}" + Environment.NewLine;
            }

            // ツイートする
            twitter.Tweet($"{text}");
        }
    }
}
