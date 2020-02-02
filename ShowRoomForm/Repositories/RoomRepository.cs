using ShowRoomForm.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShowRoomForm.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        public IReadOnlyList<RoomEntity> GetRooms()
        {
            var di = new DirectoryInfo("Input");
            // xmlのリストアップ
            var files = di.EnumerateFiles("followers_*.xml", SearchOption.AllDirectories);

            // ルームリスト
            var rooms = new List<RoomEntity>();

            foreach (var file in files)
            {
                rooms.AddRange(GetRooms(file.FullName));
            }

            return rooms;
        }

        public IReadOnlyList<RoomEntity> GetLatestRooms()
        {
            var di = new DirectoryInfo("Input");
            // xmlのリストアップ
            var files = di.EnumerateFiles("followers_*.xml", SearchOption.AllDirectories);

            // 最新xmlの日時
            var latestDateTime = files.Select(f => {
                // 年月日時分秒の抽出
                Match match = Regex.Match(f.Name, @"(\d{4})(\d{2})(\d{2})-(\d{2})(\d{2})(\d{2})");

                var year = int.Parse(match.Groups[1].Value);
                var month = int.Parse(match.Groups[2].Value);
                var day = int.Parse(match.Groups[3].Value);

                var hour = int.Parse(match.Groups[4].Value);
                var minute = int.Parse(match.Groups[5].Value);
                var second = int.Parse(match.Groups[6].Value);

                return new DateTime(year, month, day, hour, minute, second);
            }).Max();

            // 最新xml
            var latestFile = files.SingleOrDefault(f => f.Name == string.Format("followers_{0:0000}{1:00}{2:00}-{3:00}{4:00}{5:00}.xml",
                latestDateTime.Year, latestDateTime.Month, latestDateTime.Day,
                latestDateTime.Hour, latestDateTime.Minute, latestDateTime.Second));

            return GetRooms(latestFile.FullName);
        }

        public IReadOnlyList<RoomEntity> GetRooms(int roomId)
        {
            return GetRooms().Where(r => r.Id == roomId).ToList();
        }

        public IReadOnlyList<RoomEntity> GetRooms(string filePath)
        {
            // xmlを読み込み
            var xdoc = XDocument.Load(filePath);

            // 年月日時分秒の抽出
            Match match = Regex.Match(Path.GetFileName(filePath), @"(\d{4})(\d{2})(\d{2})-(\d{2})(\d{2})(\d{2})");

            var year = int.Parse(match.Groups[1].Value);
            var month = int.Parse(match.Groups[2].Value);
            var day = int.Parse(match.Groups[3].Value);

            var hour = int.Parse(match.Groups[4].Value);
            var minute = int.Parse(match.Groups[5].Value);
            var second = int.Parse(match.Groups[6].Value);

            var datetime = new DateTime(year, month, day, hour, minute, second);
            
            // ルームリスト
            var rooms = new List<RoomEntity>();

            foreach (var x in xdoc.Root.Elements())
            {
                var id = int.Parse(x.Element("Id").Value);
                var name = x.Element("Name").Value;
                var urlKey = x.Element("UrlKey").Value;
                var followerNum = int.Parse(x.Element("FollowerNum").Value);

                rooms.Add(new RoomEntity(id, datetime, name, urlKey, followerNum));
            }

            return rooms;
        }
    }
}
