namespace Server
{
    internal class Packet
    {
        public int isHost { get; set; }
        public string Username { get; set; }
        public byte[] Avatar { get; set; }
        public int Code { get; set; }
        public string RoomName { get; set; }
        public string RoomID { get; set; }
        public string Message { get; set; }
        public string Icon { get; set; }
        public byte[] VideoData { get; set; } // Dữ liệu video dưới dạng byte
        public double CurrentPosition { get; set; } // Thời gian hiện tại của video
    }
}
