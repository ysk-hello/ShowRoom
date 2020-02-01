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
    }
}
