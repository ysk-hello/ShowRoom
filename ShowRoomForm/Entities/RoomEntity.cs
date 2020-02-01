using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomForm.Entities
{
    /// <summary>
    /// ルームエンティティクラスです。(継承不可)
    /// </summary>
    public sealed class RoomEntity
    {
        /// <summary>
        /// コンストラクタです。
        /// </summary>
        /// <param name="id">ルームId</param>
        /// <param name="name">ルーム名</param>
        /// <param name="key">ルームURLキー</param>
        /// <param name="num">フォロワー数</param>
        public RoomEntity(int id, string name, string key, int num)
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
    }
}
