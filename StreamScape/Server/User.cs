using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class User
    {
        public string Username { get; set; }
        public string EmailPhone { get; set; }
        public string Password { get; set; }

        //Phương thức khởi tạo thông tin cho user
        public User(string username, string emailPhone, string password)
        {
            Username = username;
            EmailPhone = emailPhone;
            Password = password;
        }

        //Phương thức kiểm tra thông tin login
        public bool ValidateLogin(string enteredUsername, string enteredPassword)
        {
            return Username == enteredUsername && Password == enteredPassword;
        }

        //Phương thức cập nhật username
        public void UpdateInfo(string newUsername)
        {
            Username = newUsername;
        }
    }
}
