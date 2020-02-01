using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShowRoomForm.Entities;
using ShowRoomForm.Repositories;
using ShowRoomForm.ViewModels;

namespace ShowRoomFormTests
{
    [TestClass]
    public class MainViewModelTest
    {
        // ViewModelのテスト

        [TestMethod]
        public void ルームを取得する()
        {
            var mock = new Mock<IRoomRepository>();

            var entities = new List<RoomEntity>();
            entities.Add(new RoomEntity(1, "test01", "test1", 1000));
            entities.Add(new RoomEntity(2, "test02", "test2", 2000));
            entities.Add(new RoomEntity(3, "test03", "test3", 3000));

            mock.Setup(m => m.GetRooms()).Returns(entities);

            var vm = new MainViewModel(mock.Object);

            vm.Rooms.Count.Is(3);
            vm.Rooms[0].Name.Is("test01");
            vm.Rooms[1].Name.Is("test02");
            vm.Rooms[2].Name.Is("test03");

            vm.Rooms[0].FollowerNum.Is(1000);
            vm.Rooms[1].FollowerNum.Is(2000);
            vm.Rooms[2].FollowerNum.Is(3000);
        }
    }
}
