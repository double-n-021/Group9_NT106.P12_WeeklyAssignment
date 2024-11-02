using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Server
{
    internal class Room
    {
        public int roomID;
        public string roomName;
        public List<User> userList = new List<User>();
        public byte[] CurrentVideoData { get; set; } // Dữ liệu video dưới dạng byte

        public string GetUsernameListInString()
        {
            List<string> usernames = new List<string>();
            foreach (User user in userList)
            {
                usernames.Add(user.Username);
            }
            string[] s = usernames.ToArray();
            string res = string.Join(",", s);

            return res;
        }

        public byte[] GetAvatarList()
        {
            List<byte> listAvatar = new List<byte>();

            foreach (User user in userList)
            {
                // Lưu kích thước ảnh (4 byte đầu tiên của mỗi ảnh)
                byte[] sizeBytes = BitConverter.GetBytes(user.Avatar.Length);
                listAvatar.AddRange(sizeBytes);

                // Lưu nội dung ảnh
                listAvatar.AddRange(user.Avatar);
            }

            return listAvatar.ToArray();
        }
    }
}
