using ShowRoomForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomForm.ViewModels
{
    public class Room
    {
        private RoomEntity _entity;
        public Room(RoomEntity entity)
        {
            _entity = entity;
        }

        public string Name => _entity.Name;

        public string DispDataDateTime => _entity.DataDateTime.ToShortDateString();

        public int FollowerNum => _entity.FollowerNum;
    }
}
