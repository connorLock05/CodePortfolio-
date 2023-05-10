using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Text;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace PokerGameNEAProj
{
    public partial class LoginRegister : Form
    {
        bool IsLogin;
        bool Host = false;

        Control[] registrationComponents;
        Label[] InfoBoxes;
        TextBox[] textBoxes;
        Control[] PlayerCountSelectorObjs;

        Socket sock;

        Regex regexEmail;
        Regex regexUsername;
        Regex regexPassword;


        public LoginRegister(Socket sock) // External Client
        {
            InitializeComponent();
            IsLogin = false;
            this.sock = sock;

            SetComponentArrays();

            regexEmail = new Regex(CONSTANTS.EMAILVALIDATIONPATTERN);
            regexUsername = new Regex(CONSTANTS.USERNAMEVALIDATIONPATTERN);
            regexPassword = new Regex(CONSTANTS.PASSWORDVALIDATIONPATTERN);
            
        }

        public LoginRegister() // Hosting User
        {
            InitializeComponent();
            IsLogin = false;

            Host = true;
            SetComponentArrays();
        }

        public void SetComponentArrays()
        {
            PlayerCountSelectorObjs = new Control[] { PlayerCountNUD, PlayersNUDLabel };
            textBoxes = new TextBox[] { UsernameTextBox, PasswordTextBox, EmailTextBox, FirstNameTextBox, SurnameTextBox };
            InfoBoxes = new Label[] { InfoLine1, InfoLine2, InfoLine3, InfoLine4, InfoLine5 };
            registrationComponents = new Control[] { FnameLBL, FirstNameTextBox, EmailLBL, EmailTextBox, SnameLBL, SurnameTextBox, InfoLine1, InfoLine2, InfoLine3, InfoLine4, InfoLine5 };
        }



        private void LoginLoad(object sender, EventArgs e)
        {
            if (IsLogin) { return; }

            foreach (Control c in registrationComponents)
            {
                c.Visible = false;
            }
            foreach (TextBox tb in textBoxes)
            {
                tb.Text = "";
            }

            SubmitBTN.Text = "Login";
            IsLogin = true;

            foreach (Control c in PlayerCountSelectorObjs)
            {
                c.Visible = IsLogin && Host;
            }

            this.Text = "Login";
        }

        private void RegisterLoad(object sender, EventArgs e)
        {
            if (!IsLogin) { return; }

            foreach (Control c in registrationComponents)
            {
                c.Visible = true;
            }
            foreach (TextBox tb in textBoxes)
            {
                tb.Text = "";
            }

            SubmitBTN.Text = "Register";
            IsLogin = false;

            foreach (Control c in PlayerCountSelectorObjs)
            {
                c.Visible = IsLogin && Host;
            }

            this.Text = "Register";
        }

        private void LoginRegister_Load(object sender, EventArgs e)
        {
            LoginLoad(null, null);
        }

        private void SubmitBTNClick(object sender, EventArgs e)
        {
            string text = SubmitBTN.Text.ToLower();

            if (text == "login") { LoginProcess(Host); }
            if (text == "register") { RegisterProcess(Host); }
        }

        private void LoginProcess(bool hosting)
        {
            if (hosting)
            {
                DatabaseInteration dbi = new DatabaseInteration();
                string passwordRes;
                DataTable dt = dbi.GetUserData(new string[] { CONSTANTS.UTCols.PW }, UsernameTextBox.Text);
                try
                {
                    passwordRes = dt.Rows[0][CONSTANTS.UTCols.PW].ToString();
                }
                catch
                {
                    MessageBox.Show("That Username or Password Is Incorrect", "Credentials Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string inputPass = Hashing.HashStr(PasswordTextBox.Text);

                if (passwordRes == inputPass)
                {
                    // Login Success
                    Debug.WriteLine("Login Success");

                    // Attempting to host -> User must have admin privilleges
                    dt.Clear();
                    dt = dbi.GetUserData(new string[] { CONSTANTS.UTCols.A }, UsernameTextBox.Text);
                    string adminRes = dt.Rows[0][CONSTANTS.UTCols.A].ToString();
                    Debug.WriteLine($"Admin : {adminRes}");

                    if (adminRes == "True")
                    {
                        // Hosting Allowed
                        // Take to host Page
                        HostingForm hf = new HostingForm((int)PlayerCountNUD.Value);
                        this.Hide();
                        hf.ShowDialog();

                        this.Show();
                    }
                    else
                    {
                        // Hosting disallowed
                        foreach(TextBox tb in textBoxes)
                        {
                            tb.Text = "";
                        }
                        MessageBox.Show("The user logged in with does not have hosting priviliges, Please login again with a user with hosting privielges or connect to an active host", "Hosting Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                           
                    }

                } else
                {
                    // Login Failed
                    MessageBox.Show("That Username or Password Is Incorrect", "Credentials Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Debug.WriteLine("Login Failed");

                    foreach (TextBox tb in textBoxes)
                    {
                        tb.Text = "";
                    }
                }

            }
            else
            {
                // User is a client
                // Use Sockets to get data from database
                
                byte[] buffer;
                string command = NetworkCMDstringGenerator.LoginRequestCommand(UsernameTextBox.Text, PasswordTextBox.Text);

                buffer = Encoding.UTF8.GetBytes(command);
                sock.Send(buffer);
                sock.Receive(buffer);

                string returnText = Encoding.UTF8.GetString(buffer);

                if (returnText.Substring(0,5) == "Valid")
                {
                    // Login Success

                    command = NetworkCMDstringGenerator.DataBaseSelectCommand(CONSTANTS.UT, $"{CONSTANTS.UTCols.UN}='{UsernameTextBox.Text}'", CONSTANTS.UTCols.GB, CONSTANTS.UTCols.UID);
                    buffer = Encoding.UTF8.GetBytes(command);

                    sock.Send(buffer);
                    sock.Receive(buffer);

                    NetworkCMD cmd = new NetworkCMD(Encoding.UTF8.GetString(buffer));

                    if (cmd.Command == "RESPONSE")
                    {
                        Debug.Write("RESPONSE CHECK");
                        string balance = cmd.Args[0];
                        int UID = int.Parse(cmd.Args[1]);
                        PreGameForm pgf = new PreGameForm(sock, UsernameTextBox.Text, balance, UID);
                        this.Hide();
                        pgf.ShowDialog();

                        this.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("There was an error attempting to load the next form, Please Try Again", "Unexpected Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
                else
                {
                    // Invalid Login
                    MessageBox.Show("The Username Or Password Is Incorrect", "Credentials Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void RegisterProcess(bool hosting)
        {
            if (CheckValidity())
            {
                if (hosting)
                {
                    DatabaseInteration dbi = new DatabaseInteration();
                    List<string> ActiveUsernames = dbi.ReturnCol(CONSTANTS.UTCols.UN, CONSTANTS.UT);
                    List<string> ActiveEmails = dbi.ReturnCol(CONSTANTS.UTCols.EM, CONSTANTS.UT);

                    if (ActiveUsernames.Contains(UsernameTextBox.Text))
                    {
                        MessageBox.Show("That Username is already taken", "Username Error");
                        return;
                    }
                    if (ActiveEmails.Contains(EmailTextBox.Text.ToLower()))
                    {
                        MessageBox.Show("That Email is already taken", "Email Error");
                        return;
                    }

                    string passHash = Hashing.HashStr(PasswordTextBox.Text);

                    dbi.RegisterUser(UsernameTextBox.Text, passHash, EmailTextBox.Text.ToLower(), FirstNameTextBox.Text, SurnameTextBox.Text);

                    MessageBox.Show("Account Registered Successfully", "Registration Success");

                    LoginLoad(null, null);

                }
                else
                {
                    // Connected Player Registering
                    string[] args = new string[5];
                    args[0] = UsernameTextBox.Text;
                    args[1] = Hashing.HashStr(PasswordTextBox.Text);
                    args[2] = EmailTextBox.Text.ToLower();
                    args[3] = FirstNameTextBox.Text;
                    args[4] = SurnameTextBox.Text;

                    string command = NetworkCMDstringGenerator.RegisterCommand(args);
                    byte[] buffer = new byte[2048];
                    buffer = Encoding.UTF8.GetBytes(command);

                    sock.Send(buffer);
                    sock.Receive(buffer);

                    string response = Encoding.UTF8.GetString(buffer);

                    switch (response[0])
                    {
                        case 'U':
                            MessageBox.Show("That Username is Already in Use", "Username Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 'E':
                            MessageBox.Show("That Email is Already in Use", "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 'R':
                            MessageBox.Show("Account Successfully registered", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoginLoad(null, null);
                            break;
                    }

                }
            }
            else
            {
                MessageBox.Show("A Criteria Error Occured", "Criteria Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsernameEnter(object sender, EventArgs e)
        {
            foreach (Label lbl in InfoBoxes)
            {
                lbl.Text = "";
            }

            string[] toSet = CONSTANTS.UsernameHelp.Split('\n');

            for (int i = 0; i < toSet.Length; i++)
            {
                InfoBoxes[i].Text = toSet[i];
            }
        }

        private void PasswordEnter(object sender, EventArgs e)
        {
            foreach (Label lbl in InfoBoxes)
            {
                lbl.Text = "";
            }

            string[] toSet = CONSTANTS.PasswordHelp.Split('\n');

            for (int i = 0; i < toSet.Length; i++)
            {
                InfoBoxes[i].Text = toSet[i];
            }
        }

        private void EmailEnter(object sender, EventArgs e)
        {
            foreach(Label lbl in InfoBoxes)
            {
                lbl.Text = "";
            }

            string[] toSet = CONSTANTS.EmailHelp.Split('\n');

            for(int i = 0; i < toSet.Length; i++)
            {
                InfoBoxes[i].Text = toSet[i];
            }
        }

        private bool CheckValidity()
        {
            bool UsernameValid = regexUsername.IsMatch(UsernameTextBox.Text);
            bool PasswordValid = regexPassword.IsMatch(PasswordTextBox.Text);
            bool EmailValid = regexEmail.IsMatch(EmailTextBox.Text);

            return UsernameValid && PasswordValid && EmailValid;

        }

        private void ShowPassChanged(object sender, EventArgs e)
        {
            PasswordTextBox.UseSystemPasswordChar = !ShowPassCheck.Checked;
        }

        private void BackToConnect(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }


    }

}
