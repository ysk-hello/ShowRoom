using ShowRoomConsole.Models;
using System.IO;
using System.Xml.Linq;

namespace ShowRoomConsole.IO
{
    /// <summary>
    /// XMLファイル書き込みクラスです。
    /// </summary>
    public class XmlWriter
    {
        /// <summary>
        /// Roomを追加します。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="room">ルーム</param>
        public static void Append(string filePath, Room room)
        {
            var xRoom =
                new XElement("Room",
                    new XElement("Id", room.Id),
                    new XElement("UrlKey", room.URLKey),
                    new XElement("Name", room.Name),
                    new XElement("FollowerNum", room.FollowerNum));

            XDocument xdoc;

            //　ファイルが存在する場合
            if (File.Exists(filePath))
            {
                // ファイルを読み込む
                xdoc = XDocument.Load(filePath);
                xdoc.Element("Rooms").Add(xRoom);
            }
            else
            {
                var x = new XElement("Rooms", xRoom);
                xdoc = new XDocument(x);
            }

            // ファイルに保存する
            xdoc.Save(filePath);
        }
    }
}
