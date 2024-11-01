using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
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

                if (data != null)
                {
                    byte[] imageavatar = data;
                    // Tìm Picturebox cho tên người dùng hiện tại
                    PictureBox match_avataruser = formonlineroom.Controls.Find("pbAV" + (seq_user + 1), true).FirstOrDefault() as PictureBox;
                    using (MemoryStream ms = new MemoryStream(imageavatar))
                    {
                        match_avataruser.Image = Image.FromStream(ms);
                    }
                    seq_user++;
                }
                else MessageBox.Show("Ảnh là null");
            }
        }


        public void RemoveFromUserListView(string line, byte[] image, Form_Onlineroom formonlineroom)
        {
            Action action = () =>
            {
                for (int i = 0; i < List.Items.Count; i++)
                {
                    if (List.Items[i].Text == line)
                    {
                        List.Items.RemoveAt(i);
                        avatar.RemoveAt(i);
                        ConvertListViewToPB(List, formonlineroom);
                        break;
                    }
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
