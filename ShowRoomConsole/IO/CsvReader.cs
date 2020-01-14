using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ShowRoomConsole.IO
{
    /// <summary>
    /// CSVファイル読み取りクラスです。
    /// </summary>
    public class CsvReader
    {
        /// <summary>
        /// RoomIdを読み込みます。
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>Idのリスト</returns>
        /// <remarks>ファイルが存在しない場合は、空配列を返す</remarks>
        public static IEnumerable<int> ReadRoomIds(string filePath)
        {
            // ファイルが存在しない場合
            if (!File.Exists(filePath))
            {
                return new List<int>();
            }

            // ファイルを読み込む
            var lines = File.ReadLines(filePath);

            // RoomIdを取り出す
            var stringIds = lines.Select(l => l.Split(",").FirstOrDefault());

            var ids = new List<int>();
            foreach(var s in stringIds)
            {
                // Intに変換できた場合
                if(int.TryParse(s, out int id))
                {
                    ids.Add(id);
                }
            }

            return ids;
        }
    }
}
