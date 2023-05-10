using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessangerApp
{
    public partial class Connection : Form
    {
        readonly string UsernameOriginal;
        readonly string IPOriginal;

        const string USERNAMEREGEX = @"^[a-zA-z0-9#~=+\-_!£$%&]{8,}$";
        public Connection()
        {
            InitializeComponent();

            UsernameOriginal = UsernameField.Text;
            IPOriginal = IPField.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Do nothing
        }

        // Text Field Placeholder text creators
        private void UsernameField_Enter(object sender, EventArgs e)
        {
            if (UsernameField.Text == UsernameOriginal)
            {
                UsernameField.Text = "";
            }
        }

        private void UsernameField_Leave(object sender, EventArgs e)
        {
            if (UsernameField.Text == "")
            {
                UsernameField.Text = UsernameOriginal;
            }
        }

        private void IPField_Enter(object sender, EventArgs e)
        {
            if (IPField.Text == IPOriginal)
            {
                IPField.Text = "";
            }
        }

        private void IPField_Leave(object sender, EventArgs e)
        {
            if (IPField.Text == "")
            {
                IPField.Text = IPOriginal;
            }
        }

        // Button click handlers

        private void HostBTN_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(UsernameField.Text, USERNAMEREGEX) || UsernameField.Text == UsernameOriginal) { MessageBox.Show("Invalid Username", "Username Error"); return; }

            // Messenger Form Show (Host)
            this.Hide();
            Messenger msg = new Messenger(UsernameField.Text, true);

            msg.ShowDialog();

            this.Show();

        }

        private void JoinBTN_Click(Object sender, EventArgs e)
        {
            if (!Regex.IsMatch(UsernameField.Text, USERNAMEREGEX) || UsernameField.Text == UsernameOriginal) { MessageBox.Show("Invalid Username", "Username Error"); return; }
            if (IPField.Text == "" || IPField.Text == IPOriginal) { MessageBox.Show("Invalid IP", "IP Error"); return; }

            // Messenger Form Show (Join)
            this.Hide();
            Messenger msg = new Messenger(UsernameField.Text, false, IPField.Text);

            msg.ShowDialog();

            this.Show();
        }
    }
}
