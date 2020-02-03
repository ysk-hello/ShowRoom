using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowRoomForm.Repositories;

namespace ShowRoomFormTests
{
    [TestClass]
    public class RoomRepositoryTest
    {
        [TestMethod]
        public void ルームを取得する()
        {
            var repository = new RoomRepository();
            var rooms = repository.GetRooms();

            Assert.AreEqual(45, rooms.Count);
        }
    }
}
