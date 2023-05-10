using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace PokerGameNEAProj
{
    public partial class Connection : Form
    {
        

        public Connection()
        {
            InitializeComponent();

            HostBTN.Enabled = File.Exists("PokerDB.accdb");
            
        }

        private void IPTextFieldLeave(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb == null) { return; }

            if (tb.Text == "")
            {
                tb.Text = "Enter IP Here";
            }
        }

        private void IPTextFieldEnter(object sender, EventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb == null) { return; }

            if (tb.Text == "Enter IP Here")
            {
                tb.Text = "";
            }
        }

        private void ConnectBTNClick(object sender, EventArgs e)
        {
            try
            {
                TcpClient tcpClient = new TcpClient(IPtextField.Text, 5768);
                Socket sock = tcpClient.Client;
                
                
                // Initiate connection procedure
                


                // Forward to login 
                if (sock.Connected)
                {
                    LoginRegister loginForm = new LoginRegister(sock);

                    this.Hide();
                    loginForm.ShowDialog();

                    this.Show();
                }
                else
                {
                    MessageBox.Show("There was an error during connection. Please Try Again", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } catch
            {
                MessageBox.Show("That IP Address Is Not Currently Accepting Connections", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HostGameBTNClick(object sender, EventArgs e)
        {
            //Load login with host parameters

            // Initiate Host Game Procedure

            LoginRegister loginForm = new LoginRegister();
            
            this.Hide();
            loginForm.ShowDialog();

            this.Show();
        }
    }
}
