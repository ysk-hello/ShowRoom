using ShowRoomForm.Entities;
using ShowRoomForm.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomForm.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IRoomRepository _roomRepository;

        /// <summary>
        /// 本番用コンストラクター
        /// </summary>
        public MainViewModel() : this(new RoomRepository())
        {
        
        }

        /// <summary>
        /// テスト用コンストラクター
        /// </summary>
        /// <param name="roomRepository"></param>
        public MainViewModel(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;

            foreach (var entity in _roomRepository.GetLatestRooms())
            {
                // 表示用のメンバーリスト
                Members.Add(entity);
            }
        }

        #region viewでバインドするプロパティ

        public BindingList<RoomEntity> Members { get; set; } = new BindingList<RoomEntity>();

        public BindingList<Room> Rooms { get; set; } = new BindingList<Room>();

        public BindingList<RoomEntity> RoomsData { get; set; } = new BindingList<RoomEntity>();

        #endregion

        #region method

        public void ShowRoomGridView(int roomId)
        {
            Rooms.Clear();

            // 日時(降順)で並べる
            var entities = _roomRepository.GetRooms(roomId).OrderByDescending(r => r.DataDateTime).ToList();

            for (int i = 0; i < entities.Count(); i++)
            {
                if (i == entities.Count() - 1)
                {
                    // 前日のデータがない場合

                    Rooms.Add(new Room(entities[i], 0));
                }
                else
                {
                    // 前日のデータがある場合

                    // グリッド用のルームリスト
                    Rooms.Add(new Room(entities[i], entities[i + 1].FollowerNum));
                }
            }
        }

        public void ShowChart(int roomId)
        {
            RoomsData.Clear();

            foreach (var entity in _roomRepository.GetRooms(roomId).OrderByDescending(r => r.DataDateTime))
            {
                // チャート用ルームリスト
                RoomsData.Add(entity);
            }
        }

        #endregion
    }
}
