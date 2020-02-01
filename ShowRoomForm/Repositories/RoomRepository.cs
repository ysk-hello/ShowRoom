using ShowRoomForm.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShowRoomForm.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public IReadOnlyList<RoomEntity> GetRooms()
        {
            var xdoc = XDocument.Load(@"Input\followers_20200118-010001.xml");

            var rooms = new List<RoomEntity>();
            foreach (var x in xdoc.Root.Elements())
            {
                var id = int.Parse(x.Element("Id").Value);
                var name = x.Element("Name").Value;
                var urlKey = x.Element("UrlKey").Value;
                var followerNum = int.Parse(x.Element("FollowerNum").Value);

                rooms.Add(new RoomEntity(id, name, urlKey, followerNum));
            }

            return rooms;
        }
    }
}
