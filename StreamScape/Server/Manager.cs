using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    internal class Manager
    {
        ListView Log;
        TextBox RoomCnt;
        TextBox UserCnt;

        public Manager(ListView log, TextBox room_count, TextBox user_count)
        {
            Log = log;
            RoomCnt = room_count;
            UserCnt = user_count;
        }

        public void WriteToLog(string line)
        {
            if (Log.InvokeRequired)
            {
                Log.Invoke(new Action(() =>
                {
                    Log.Items.Add(string.Format("{0}: {1}", DateTime.Now.ToString("HH:mm"), line));
                }));
            }
            else
            {
                Log.Items.Add(string.Format("{0}: {1}", DateTime.Now.ToString("HH:mm"), line));
            }
        }

        public void UpdateRoomCount(int num)
        {
            if (RoomCnt.InvokeRequired)
            {
                RoomCnt.Invoke(new Action(() =>
                {
                    RoomCnt.Text = num.ToString();
                }));
            }
            else
            {
                RoomCnt.Text = num.ToString();
            }
        }

        public void UpdateUserCount(int num)
        {
            if (UserCnt.InvokeRequired)
            {
                UserCnt.Invoke(new Action(() =>
                {
                    UserCnt.Text = num.ToString();
                }));
            }
            else
            {
                UserCnt.Text = num.ToString();
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
