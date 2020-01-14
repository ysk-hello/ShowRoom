using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShowRoomConsole.Models
{
    /// <summary>
    /// ルームクラスです。
    /// </summary>
    public class Room
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="id">ルームId</param>
        /// <param name="name">ルーム名</param>
        /// <param name="key">ルームURLキー</param>
        /// <param name="num">フォロワー数</param>
        public Room(int id, string name, string key, int num)
        {
            Id = id;
            Name = name;
            URLKey = key;
            FollowerNum = num;
        }

        /// <summary>
        /// ルームIdです。
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// ルーム名です。
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// ルームURLキーです。
        /// </summary>
        public string URLKey { get; }

        /// <summary>
        /// フォロワー数です。
        /// </summary>
        public int FollowerNum { get; }

        /// <summary>
        /// ルームを作成します。
        /// </summary>
        /// <param name="id">ルームId</param>
        /// <returns>ルーム</returns>
        public static async Task<Room> CreateRoom(int id)
        {
            var uri = new Uri(string.Format("https://www.showroom-live.com/api/room/profile?room_id={0}", id));

            var text = string.Empty;
            using (var client = new HttpClient())
            {
                // データを取得する
                text = await client.GetStringAsync(uri);
            }

            var obj = JObject.Parse(text);

            var ok = int.TryParse(obj["follower_num"].ToString(), out int num);

            // Intに変換できなかった場合
            if (!ok) num = -1;

            return new Room(id, obj["room_name"].ToString(), obj["room_url_key"].ToString(), num);
        }
    }
}
