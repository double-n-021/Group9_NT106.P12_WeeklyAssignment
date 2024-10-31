using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Packet
    {
        public int Code { get; set; }
        public string Username { get; set; }
        public string RoomName { get; set; }
        public string RoomID { get; set; }
    }
}
