using System.IO;
using System.Net.Sockets;


namespace Server
{
    internal class User
    {
        public string Username { get; set; }
        public byte[] Avatar { get; set; }
        public int isHost { get; set; }
        public TcpClient Client { get; set; }
        public BinaryReader Reader { get; set; }
        public BinaryWriter Writer { get; set; }

        public User(TcpClient client)
        {
            Client = client;
            Username = string.Empty;
            Avatar = new byte[0];
            NetworkStream stream = Client.GetStream();
            Reader = new BinaryReader(stream);
            Writer = new BinaryWriter(stream);
        }
    }
}
