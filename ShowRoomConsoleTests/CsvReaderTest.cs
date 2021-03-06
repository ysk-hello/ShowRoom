using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShowRoomConsole.IO;
using System.Linq;

namespace ShowRoomConsoleTests
{
    [TestClass]
    public class CsvReaderTest
    {
        [TestMethod]
        public void CSVを読み込む()
        {
            var ids = CsvReader.ReadRoomIds(@"Input\TestData.csv").ToArray();

            Assert.IsTrue(ids.Count() == 3);

            Assert.AreEqual(270117, ids[0]);
            Assert.AreEqual(97002, ids[1]);
            Assert.AreEqual(146900, ids[2]);
        }

        [TestMethod]
        public void CSVを読み込む_ファイルなし()
        {
            var ids = CsvReader.ReadRoomIds(@"Input\NoTestData.csv").ToArray();

            Assert.IsTrue(ids.Count() == 0);
        }

        [TestMethod]
        public void CSVを読み込む_Idなし()
        {
            var ids = CsvReader.ReadRoomIds(@"Input\TestData2.csv").ToArray();

            Assert.IsTrue(ids.Count() == 2);

            Assert.AreEqual(270117, ids[0]);
            Assert.AreEqual(97002, ids[1]);
        }
    }
}
