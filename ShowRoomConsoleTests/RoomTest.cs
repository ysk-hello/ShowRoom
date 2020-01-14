using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowRoomConsole.Models;
using System.Threading.Tasks;

namespace ShowRoomConsoleTests
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        public async Task ルーム情報を保存する()
        {
            var room = await Room.CreateRoom(270117);

            Assert.AreEqual(270117, room.Id);
            Assert.AreEqual("小島 愛子（STU48 2期研究生）", room.Name);
            Assert.AreEqual("48_KOJIMA_AIKO", room.URLKey);
            Assert.IsTrue(room.FollowerNum >= 0);

            ShowRoomConsole.IO.XmlWriter.Append("room.xml", room);
        }
    }
}
