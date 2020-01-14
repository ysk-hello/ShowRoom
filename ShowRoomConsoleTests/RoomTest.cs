using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowRoomConsole.Models;
using System.Threading.Tasks;

namespace ShowRoomConsoleTests
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public async Task ���[������ۑ�����()
        {
            var room = await Room.CreateRoom(270117);

            Assert.AreEqual(270117, room.Id);
            Assert.AreEqual("���� ���q�iSTU48 2���������j", room.Name);
            Assert.AreEqual("48_KOJIMA_AIKO", room.URLKey);
            Assert.IsTrue(room.FollowerNum >= 0);

            ShowRoomConsole.IO.XmlWriter.Append("room.xml", room);
        }
    }
}
