using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessangerApp
{
    public partial class Messenger : Form
    {
        readonly string Username;
        readonly bool Hosting;
        readonly Socket sock;

        List<Socket> AllSockets;

        public Messenger(string username, bool host, string ip = null)
        {
            InitializeComponent();

            Username = username;
            Hosting = host;
            this.Text += $" - {Username}";

            if (Hosting)
            {
                AllSockets = new List<Socket>();

                ThreadPool.QueueUserWorkItem(NewConnectionListener);
                ThreadPool.QueueUserWorkItem(ClientHandler);
            }
            else
            {
                TcpClient client = new TcpClient(ip, 5768);
                sock = client.Client;

                ThreadPool.QueueUserWorkItem(ServerListener);
            }

        }

        private void NewConnectionListener(object state)
        {
            TcpListener listen = new TcpListener(System.Net.IPAddress.Any, 5768);
            listen.Start();

            TcpClient client;

            while (true)
            {
                client = listen.AcceptTcpClient();
                AllSockets.Add(client.Client);
            }
        }

        private void ServerListener(object state)
        {
            byte[] buffer;
            string recieved;

            while (sock.Connected)
            {
                try
                {
                    buffer = new byte[4096];

                    sock.Receive(buffer);
                    recieved = Encoding.UTF8.GetString(buffer);

                    if (recieved == new string('\0', buffer.Length)) { continue; }

                    // Message Recieved

                    AddText(recieved);
                }
                catch
                {
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        private void ClientHandler(object state)
        {
            byte[] buffer;
            string recieved;

            while (true)
            {
                
                
                foreach (Socket s in AllSockets)
                {
                    try
                    {
                        buffer = new byte[4096];
                        s.Receive(buffer);
                        recieved = Encoding.UTF8.GetString(buffer);

                        if (recieved == new string('\0', 5768)) { continue; }

                        // Add message
                        AddText(recieved);

                        // Send to all clients
                        AllClientsSend(buffer);
                    }
                    catch
                    {
                        AllSockets.Remove(s);
                    }
                }
                
                
            }
        }

        private void AllClientsSend(byte[] buffer)
        {
            foreach (Socket socket in AllSockets)
            {
                socket.Send(buffer);
            }
        }

        delegate void AddTextCallback(string text);
        private void AddText(string text)
        {
            if (DisplayBox.InvokeRequired)
            {
                AddTextCallback d = new AddTextCallback(AddText);
                DisplayBox.Invoke(d, text);
            }
            else
            {
                string[] parts = text.Split('¬');
                // Parts[0] = Username
                // Parts[1] = Message

                DisplayBox.Text += $"{parts[0]} : {parts[1]}";
                DisplayBox.Text += Environment.NewLine;
            }
        }

        private void SendBTN_Click(object sender, EventArgs e)
        {
            string messageSignal = $"{Username}¬{InputField.Text}";

            if (Hosting)
            {
                AddText(messageSignal);
                AllClientsSend(Encoding.UTF8.GetBytes(messageSignal));
            }
            else
            {
                sock.Send(Encoding.UTF8.GetBytes(messageSignal));
            }
        }
    }
}
