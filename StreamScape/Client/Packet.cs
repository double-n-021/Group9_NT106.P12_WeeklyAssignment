using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    internal class Packet
    {
        public string Username { get; set; }
        public byte[] Avatar { get; set; }
        public int Code { get; set; }
        public string RoomName { get; set; }
        public string RoomID { get; set; }

    }
}
