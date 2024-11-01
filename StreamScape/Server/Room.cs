using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Room
    {
        public int roomID;
        public string roomName;
        public List<User> userList = new List<User>();

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
            List<byte> avatarList = new List<byte>();
            foreach (User user in userList)
            {
                if (user.Avatar != null)
                {
                    int avatarSize = user.Avatar.Length;
                    byte[] avatarSizeBytes = BitConverter.GetBytes(avatarSize);
                    avatarList.AddRange(avatarSizeBytes);
                    avatarList.AddRange(user.Avatar);
                }
            }
            return avatarList.ToArray();
        }
    }
}
