using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Drawing;



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

        public void AddToUserListView(string line, Form_Onlineroom formonlineroom)
        {
            if (List.InvokeRequired)
            {
                List.Invoke(new Action(() =>
                {
                    List.Items.Add(line);
                    ConvertListViewToPB(List, formonlineroom);
                }));
            }
            else
            {
                List.Items.Add(line);
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

                if (match_username != null)
                {
                    match_username.Text = username;
                    match_username.Visible = true;
                }
                else
                {
                    match_username.Visible = false;
                }

                seq_user++;
            }
        }


        public void RemoveFromUserListView(string line)
        {
            Action action = () =>
            {
                foreach (ListViewItem item in List.Items)
                {
                    if (item.Text == line)
                    {
                        List.Items.Remove(item);
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

        public void ClearUserListView()
        {
            Action action = () =>
            {
                ListViewItem firstLine = List.Items[0];
                List.Clear();
                List.Items.Add(firstLine);
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
