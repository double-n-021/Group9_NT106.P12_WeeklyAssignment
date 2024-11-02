using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

namespace Client
{
    internal class Manager
    {
        ListView List;
        TextBox RoomID;
        TextBox RoomName;

        public Manager(ListView list, TextBox roomID, TextBox roomName)
        {
            List = list;
            RoomID = roomID;
            RoomName = roomName;
        }

        private List<byte[]> avatar = new List<byte[]>();

        public void AddToUserListView(string line, byte[] image, Form_Onlineroom formonlineroom)
        {
            if (List.InvokeRequired)
            {
                List.Invoke(new Action(() =>
                {
                    List.Items.Add(line);
                    avatar.Add(image);
                    ConvertListViewToPB(List, formonlineroom);
                }));
            }
            else
            {
                List.Items.Add(line);
                avatar.Add(image);
                ConvertListViewToPB(List, formonlineroom);
            }
        }

        private void ConvertListViewToPB(ListView list, Form_Onlineroom formonlineroom)
        {
            int seq_user = 0;
            while(seq_user<5)
            {
                Label match_username = formonlineroom.Controls.Find("lbUS" + (seq_user + 1), true).FirstOrDefault() as Label;
                match_username.Visible = false;
                PictureBox match_avataruser = formonlineroom.Controls.Find("pbAV" + (seq_user + 1), true).FirstOrDefault() as PictureBox;
                match_avataruser.Visible = false;
                seq_user++;
            }

            seq_user = 0;
            foreach (ListViewItem item in list.Items)//0 -> cuối list
            {
                if (seq_user >= 5) break;

                string username = item.Text;

                // Tìm Label cho tên người dùng hiện tại
                Label match_username = formonlineroom.Controls.Find("lbUS" + (seq_user + 1), true).FirstOrDefault() as Label;

                match_username.Text = username;
                match_username.Visible = true;
                seq_user++;
            }

            seq_user = 0;
            foreach (byte[] data in avatar)
            {
                if (seq_user >= 5) break;

                    byte[] imageavatar = data;
                    // Tìm Picturebox cho tên người dùng hiện tại
                    PictureBox match_avataruser = formonlineroom.Controls.Find("pbAV" + (seq_user + 1), true).FirstOrDefault() as PictureBox;

                    if (imageavatar != null && imageavatar.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream(imageavatar))
                        {
                            match_avataruser.Image = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dữ liệu hình ảnh không hợp lệ hoặc rỗng.");
                    }
                    match_avataruser.Visible = true;
                    seq_user++;
            }
        }


        public void RemoveFromUserListView(string line, Form_Onlineroom formonlineroom)
        {
            Action action = () =>
            {
                int seq = 0;
                foreach (ListViewItem item in List.Items)
                {
                    if (item.Text == line)
                    {
                        List.Items.Remove(item);
                        avatar.Remove(avatar[seq]);
                        ConvertListViewToPB(List, formonlineroom);
                        break;
                    }
                    seq++;
                }
            };
            if (List.InvokeRequired)
            {
                List.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public void ClearUserListView(Form_Onlineroom formonlineroom)
        {
            Action action = () =>
            {
                ListViewItem firstLine = List.Items[0];
                byte[] firstAvatar = avatar[0];
                List.Clear();
                avatar.Clear();
                List.Items.Add(firstLine);
                avatar.Add(firstAvatar);
                ConvertListViewToPB(List, formonlineroom);
            };
            if (List.InvokeRequired)
            {
                List.Invoke(action);
            }
            else
            {
                action();
            }
        }

        public void UpdateRoomIDNRoomName(string roomID, string roomName)
        {
            if (RoomID.InvokeRequired)
            {
                RoomID.Invoke(new Action(() =>
                {
                    RoomID.Text = roomID;
                    RoomName.Text = roomName;
                }));
            }
            else
            {
                RoomID.Text = roomID;
                RoomName.Text = roomName;
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
