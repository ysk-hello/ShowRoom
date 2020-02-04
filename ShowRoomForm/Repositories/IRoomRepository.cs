using ShowRoomForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomForm.Repositories
{
    public interface IRoomRepository
    {
        IReadOnlyList<RoomEntity> GetRooms();

        IReadOnlyList<RoomEntity> GetLatestRooms();

        IReadOnlyList<RoomEntity> GetRooms(int roomId);

        IReadOnlyList<RoomEntity> GetRooms(int roomId, DateTime start, DateTime end);

        IReadOnlyList<RoomEntity> GetRooms(string fileName);
    }
}
