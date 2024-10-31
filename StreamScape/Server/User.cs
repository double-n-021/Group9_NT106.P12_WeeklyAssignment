using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class User
    {
        public TcpClient Client { get; set; }
        public string Username { get; set; }
        public BinaryReader Reader { get; set; }
        public BinaryWriter Writer { get; set; }

        public User(TcpClient client)
        {
            Client = client;
            Username = string.Empty;
            NetworkStream stream = Client.GetStream();
            Reader = new BinaryReader(stream);
            Writer = new BinaryWriter(stream);
        }
    }
}
