using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PokerGameNEAProj
{
    public partial class GameHistory : Form
    {


        public GameHistory(int UID, string Username, Socket sock)
        {
            InitializeComponent();

            string cmd = NetworkCMDstringGenerator.HistoryRequest(UID);

            sock.Send(Encoding.UTF8.GetBytes(cmd));

            Thread.Sleep(200);

            byte[] buffer = new byte[4096];

            sock.Receive(buffer);

            // String formatted already

            UsernameLBL.Text = $"Username: {Username}";

            HistoryLog.Text = Encoding.UTF8.GetString(buffer);
        }
    }
}
