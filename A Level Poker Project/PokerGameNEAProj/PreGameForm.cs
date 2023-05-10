using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Security.Policy;

namespace PokerGameNEAProj
{
    public partial class PreGameForm : Form
    {
        Socket sock;
        int balance;
        string Username;
        int UID;

        public PreGameForm(Socket sock, string username, string balance, int UID)
        {
            InitializeComponent();
            this.sock = sock;
            //ThreadPool.QueueUserWorkItem(HandleServerResponse, sock);

            UsernameLBL.Text = "Username : " + username;
            BalanceLBL.Text = "Balance : " + balance;
            this.balance = int.Parse(balance);
            this.Username = username;
            this.UID = UID;
        }

        private void JoinGameClick(object sender, EventArgs e)
        {
            byte[] buffer = new byte[2048];

            sock.Send(Encoding.UTF8.GetBytes("JOIN"));
            sock.Receive(buffer);

            // Recieves Either O (OK) or N (NO)

            string recieved = Encoding.UTF8.GetString(buffer);
            NetworkCMD cmd = new NetworkCMD(recieved);

            if (cmd.Command == "O")
            {

                string BalRecieved = cmd.Args[0];

                DialogResult dr = MessageBox.Show($"The buy in fee is {BalRecieved}. Do you wish to proceed?", "Proceed?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    int newBalance = balance - int.Parse(BalRecieved);
                    // Request table pos
                    string CMD = NetworkCMDstringGenerator.TablePos();
                    sock.Send(Encoding.UTF8.GetBytes(CMD));
                    CMD = NetworkCMDstringGenerator.DataBaseUpdateCommand(CONSTANTS.UT, $"{CONSTANTS.UTCols.UN} = '{Username}'", $"{CONSTANTS.UTCols.GB} = {newBalance}");
                    sock.Send(Encoding.UTF8.GetBytes(CMD));
                    
                    // Join Active Game
                    GameTable gt = new GameTable(sock, int.Parse(BalRecieved), UID);
                    this.Hide();
                    gt.ShowDialog();
                    
                    this.Show();

                    // Update balance 

                    CMD = NetworkCMDstringGenerator.DataBaseSelectCommand(CONSTANTS.UT, $"UID = {UID}", CONSTANTS.UTCols.GB);
                    sock.Send(Encoding.UTF8.GetBytes(CMD));
                    buffer = new byte[2048];
                    sock.Receive(buffer);

                    string recievesd = Encoding.UTF8.GetString(buffer);
                    NetworkCMD resp = new NetworkCMD(recievesd);

                    // Balance is 1st arg
                    balance = int.Parse(resp.Args[0]);

                    BalanceLBL.Text = "Balance : " + balance;

                }

            } else if (recieved == "N")
            {
                // Game is not ready
                MessageBox.Show("The Game Is Not Ready To Be Joined Yet", "Game Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GameHistoryBTN_Click(object sender, EventArgs e)
        {
            GameHistory gh = new GameHistory(UID, Username, sock);

            this.Hide();
            gh.ShowDialog();

            this.Show();
        }
    }
}
