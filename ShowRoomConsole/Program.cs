using ShowRoomConsole.IO;
using ShowRoomConsole.Models;
using System;
using System.IO;

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
            // ルームIdの読み込み
            var roomIds = CsvReader.ReadRoomIds(@"..\..\..\Data\RoomIds.csv");

            // 出力ファイル名
            var fileName = "followers_" + DateTime.Now.ToString("yyyyMMdd-hhmmss") + ".xml";
            
            foreach (var id in roomIds)
            {
                // ルームの作成
                var room = Room.CreateRoom(id).Result;
                // ルームを出力ファイルに追加
                XmlWriter.Append(Path.Combine(fileName), room);
                
                // コンソールに出力
                Console.WriteLine($"{room.Name} {room.FollowerNum}");
            }
        }
    }
}
