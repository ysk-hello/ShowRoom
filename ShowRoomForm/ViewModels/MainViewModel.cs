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

            foreach (var entity in _roomRepository.GetRooms())
            {
                // 表示用のルームリスト
                Rooms.Add(new Room(entity));
            }
        }

        #region viewでバインドするプロパティ

        public BindingList<Room> Rooms { get; set; } = new BindingList<Room>();

        #endregion
    }
}
