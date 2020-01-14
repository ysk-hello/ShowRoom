using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowRoomConsole.IO;
using System.Linq;

namespace ShowRoomConsoleTests
{
    [TestClass]
    public class CsvReaderTest
    {
        [TestMethod]
        public void CSV‚ğ“Ç‚İ‚Ş()
        {
            var ids = CsvReader.ReadRoomIds(@"..\..\..\Data\TestData.csv").ToArray();

            Assert.IsTrue(ids.Count() == 3);

            Assert.AreEqual(270117, ids[0]);
            Assert.AreEqual(97002, ids[1]);
            Assert.AreEqual(146900, ids[2]);
        }

        [TestMethod]
        public void CSV‚ğ“Ç‚İ‚Ş_ƒtƒ@ƒCƒ‹‚È‚µ()
        {
            var ids = CsvReader.ReadRoomIds(@"..\..\..\Data\NoTestData.csv").ToArray();

            Assert.IsTrue(ids.Count() == 0);
        }

        [TestMethod]
        public void CSV‚ğ“Ç‚İ‚Ş_Id‚È‚µ()
        {
            var ids = CsvReader.ReadRoomIds(@"..\..\..\Data\TestData2.csv").ToArray();

            Assert.IsTrue(ids.Count() == 2);

            Assert.AreEqual(270117, ids[0]);
            Assert.AreEqual(97002, ids[1]);
        }
    }
}
