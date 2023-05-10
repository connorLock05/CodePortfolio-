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
using System.Diagnostics;

namespace PokerGameNEAProj
{
    public partial class GameTable : Form
    {

        /* Card Suits: ♠♣♥♦
         * Clubs : ♣
         * Hearts : ♥
         * Spades : ♠
         * Diamonds : ♦
         */

        const int OffsetX = 30;
        const int OffsetY = 30;

        Socket sock;

        Label[] AllCards;

        Label[] Player1Elements; // Player Elements In Form [UsernameLabel, Card1, Card2]
        Label[] Player2Elements;
        Label[] Player3Elements;
        Label[] Player4Elements;
        Label[] UsernameLabels;
        Label[] BalanceLabels;
        Label[] CommunityElements;
        int balance;
        int UID;
        public GameTable(Socket sock, int balance, int UID)
        {
            InitializeComponent();

            AllCards = new Label[] { Flop1, Flop2, Flop3, Turn, River, P1C1, P1C2, P2C1, P2C2, P3C1, P3C2, P4C1, P4C2 };

            Player1Elements = new Label[] { UsernameP1, P1C1, P1C2, BalanceP1 };
            Player2Elements = new Label[] { UsernameP2, P2C1, P2C2, BalanceP2 };
            Player3Elements = new Label[] { UsernameP3, P3C1, P3C2, BalanceP3 };
            Player4Elements = new Label[] { UsernameP4, P4C1, P4C2, BalanceP4 };
            UsernameLabels = new Label[] { UsernameP1, UsernameP2, UsernameP3, UsernameP4 };
            BalanceLabels = new Label[] { BalanceP1, BalanceP2, BalanceP3, BalanceP4 };

            CommunityElements = new Label[] {Flop1, Flop2, Flop3, Turn, River, PotLabel };
            this.balance = balance;
            this.UID = UID;

            this.sock = sock;

            ThreadPool.QueueUserWorkItem(HandleServerResponse, sock);
        }

        private void HandleServerResponse(object state)
        {
            Socket sock = (Socket)state;

            

            byte[] buffer = new byte[2048];

            sock.Send(Encoding.UTF8.GetBytes("PLAYERS"));
            Thread.Sleep(200);
            sock.Receive(buffer);
            string RecievedText = Encoding.UTF8.GetString(buffer);

            string[] cmds = RecievedText.Split(';');

            NetworkCMD command = new NetworkCMD(cmds[0]);
            int numberPlayers = command.Args.Length;

            SetPlayerLabels(command.Args);
            VisibleElements(numberPlayers);

            for (int i=1; i<cmds.Length; i++)
            {
                
                command = new NetworkCMD(cmds[i]);
                if (command.Command == "") { continue; }

                if (i < 3)
                {
                    Card generated = new Card(int.Parse(command.Args[2]), char.Parse(command.Args[3]));
                    int TablePos = int.Parse(command.Args[0]);
                    int CardLoc = int.Parse(command.Args[1]);

                    generated.SetLabel(ref AllCards[(TablePos == 0 ? 0 : 3) + 2 * TablePos + CardLoc]);
                }
                else if (i == 3)
                {
                    // a third command will be ROUND
                    // Args:
                    // 0 : Big Blind UID
                    // 1 : Small Blind UID
                    // 2 : Big Blind Cost
                    // 3 : Small Blind Cost

                    int BBUID = int.Parse(command.Args[0]);
                    int SBUID = int.Parse(command.Args[1]);

                    int BBCost = int.Parse(command.Args[2]);
                    int SBCost = int.Parse(command.Args[3]);

                    if (UID == BBUID)
                    {
                        balance -= BBCost;
                        sock.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.PotCommand(BBCost, "BB")));
                    }
                    if (UID == SBUID)
                    {
                        balance -= SBCost;
                        sock.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.PotCommand(SBCost, "SB")));
                    }
                }
                else if (i == 4)
                {
                    // This users turn
                    // 2 args:
                    // 0 : Selector Min
                    // 1 : Selector Max
                    ToggleBTNS(true);

                    SetSelectorMinMax(command.Args[0], command.Args[1]);
                    SelectorValueChangeThreaded(MoneySelector, null);
                    break;
                }
                else
                {
                    // Last command is POTUPDATE
                    // Args:
                    // 0 : New Amount
                    PotUpdate(command.Args[0]);
                    break;
                }
            }

            while (sock.Connected)
            {
                buffer = new byte[2048];
                sock.Receive(buffer);
                string recieved = Encoding.UTF8.GetString(buffer);

                if (recieved == new string('\0', buffer.Length)) { continue; }

                string[] commands = recieved.Split(';');
                foreach (string commandStep in commands)
                {
                    
                    command = new NetworkCMD(commandStep);

                    switch (command.Command)
                    {
                        #region CardInfo Case
                        case "CARDINFO":
                            // 4 Arguments
                            // 0 : TablePos
                            // 1 : CardLoc
                            // 2 : Number
                            // 3 : Suit

                            Card generated = new Card(int.Parse(command.Args[2]), char.Parse(command.Args[3]));
                            int TablePos = int.Parse(command.Args[0]);
                            int CardLoc = int.Parse(command.Args[1]) - 1;

                            generated.SetLabel(ref AllCards[(TablePos == 0 ? 0 : 3) + 2 * TablePos + CardLoc]);


                            break;
                        #endregion
                        #region Round Case
                        case "ROUND":
                            // Args:
                            // 0 : Big Blind UID
                            // 1 : Small Blind UID
                            // 2 : Big Blind Cost
                            // 3 : Small Blind Cost

                            int BBUID = int.Parse(command.Args[0]);
                            int SBUID = int.Parse(command.Args[1]);

                            int BBCost = int.Parse(command.Args[2]);
                            int SBCost = int.Parse(command.Args[3]);

                            if (UID == BBUID)
                            {
                                balance -= BBCost;
                                sock.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.PotCommand(BBCost, "BB")));
                            }
                            if (UID == SBUID)
                            {
                                balance -= SBCost;
                                sock.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.PotCommand(SBCost, "SB")));
                            }

                            break;
                        #endregion
                        #region PotUpdate Case
                        case "POTUPDATE":
                            // Args:
                            // 0 : New Amount
                            PotUpdate(command.Args[0]);
                            break;
                        #endregion
                        #region BalanceInfo
                        case "BALANCEUPDATE":
                            // Args:
                            // One arg for each player in order of table pos
                            for (int i = 0; i < command.Args.Length; i++)
                            {
                                SetPlayerBalance(int.Parse(command.Args[i]), i + 1);
                            }
                            break;
                        #endregion
                        #region Turn Case
                        case "TURN":
                            // This users turn
                            // 2 args:
                            // 0 : Selector Min
                            // 1 : Selector Max
                            ToggleBTNS(true);

                            SetSelectorMinMax(command.Args[0], command.Args[1]);

                            SelectorValueChangeThreaded(MoneySelector, null);
                            break;
                        #endregion
                        #region Winner Case
                        case "WINNER":
                            // 2 Args
                            // Winner UID
                            // Amount won
                            if (UID.ToString() == command.Args[0])
                            {
                                // You are winner
                                balance += int.Parse(command.Args[1]);
                            }
                            break;
                        #endregion
                        #region Split Winner Case
                        case "SPLITWIN":
                            // Args are UIDs then amount
                            string[] args = command.Args;
                            int amount = int.Parse(args.Last());

                            for(int i=0; i<args.Length-1; i++)
                            {
                                if (args[i] == UID.ToString())
                                {
                                    // You win
                                    balance += amount;
                                }
                            }
                            break;
                        #endregion
                        #region Close Game Case
                        case "CLOSEGAME":
                            // Game End
                            this.DialogResult = DialogResult.None;
                            
                            break;
                        #endregion
                    }
                }
            }

        }
        delegate void SetSelectorMinMaxCallback(string min, string max);
        private void SetSelectorMinMax(string min, string max)
        {
            if (MoneySelector.InvokeRequired)
            {
                SetSelectorMinMaxCallback d = new SetSelectorMinMaxCallback(SetSelectorMinMax);
                MoneySelector.Invoke(d, min, max);
            }
            else
            {
                MoneySelector.Minimum = int.Parse(min);
                MoneySelector.Maximum = int.Parse(max);
                Debug.WriteLine($"Min : {min} -- Max : {max}");

                MoneySelector.Value = MoneySelector.Minimum;

            }
        }

        delegate void UnlockBTNSCallback(bool state);
        private void ToggleBTNS(bool state)
        {
            if (FoldBTN.InvokeRequired)
            {
                UnlockBTNSCallback d = new UnlockBTNSCallback(ToggleBTNS);
                this.Invoke(d, new object[] {state});
            }
            else
            {
                FoldBTN.Enabled = state;
                All_InBTN.Enabled = state;
                ActionBTN.Enabled = state;

                MoneySelector.Enabled = state;
            }
        }

        delegate void PotUpdateCallback(string v);
        private void PotUpdate(string v)
        {
            if (PotLabel.InvokeRequired)
            {
                PotUpdateCallback d = new PotUpdateCallback(PotUpdate);
                this.Invoke(d, new object[] { v });
            }
            else
            {
                PotLabel.Text = $"Pot:\n{v}";
            }
        }

        delegate void SetPlayerLabelsCallback(string[] args);
        private void SetPlayerLabels(string[] args)
        {
            if (UsernameP1.InvokeRequired)
            {
                SetPlayerLabelsCallback d = new SetPlayerLabelsCallback(SetPlayerLabels);
                this.Invoke(d, new object[] { args });
            }else
            {
                // Each arg of form "Username:Balance"
                string[] tempSplit;
                for(int i=0; i<args.Length; i++)
                {
                    tempSplit = args[i].Split(':');

                    UsernameLabels[i].Text = tempSplit[0];
                    BalanceLabels[i].Text = $"Balance : {tempSplit[1]}";
                }
            }
        }

        delegate void VisibleElementsCallback(int playersDue);

        public void VisibleElements(int PlayersDue)
        {
            if (P1C1.InvokeRequired)
            {
                VisibleElementsCallback d = new VisibleElementsCallback(VisibleElements);
                this.Invoke(d, new object[] {PlayersDue});
            }
            else
            {
                if (PlayersDue < 4)
                {
                    Debug.WriteLine("Clearing P4");
                    foreach (Label lbl in Player4Elements)
                    {
                        lbl.Visible = false;
                    }
                }
                if (PlayersDue < 3)
                {
                    Debug.WriteLine("Clearing P3");
                    foreach (Label lbl in Player3Elements)
                    {
                        lbl.Visible = false;
                    }
                }
            }
        }

        delegate void SetPlayerBalanceCallback(int newBal, int playerPos);
        private void SetPlayerBalance(int newBal, int playerPos)
        {
            if (UsernameP1.InvokeRequired)
            {
                SetPlayerBalanceCallback d = new SetPlayerBalanceCallback(SetPlayerBalance);
                this.Invoke(d, new object[] { newBal, playerPos});
            }
            else
            {
                switch (playerPos)
                {
                    case 1:
                        BalanceP1.Text = $"Balance : {newBal}";
                        break;
                    case 2:
                        BalanceP2.Text = $"Balance : {newBal}";
                        break;
                    case 3:
                        BalanceP3.Text = $"Balance : {newBal}";
                        break;
                    case 4:
                        BalanceP4.Text = $"Balance : {newBal}";
                        break;
                }
            }
        }

        delegate void SelectorChangedThreadedCallback(object sender, EventArgs e);
        public void SelectorValueChangeThreaded(object sender, EventArgs e)
        {
            if (MoneySelector.InvokeRequired)
            {
                SelectorChangedThreadedCallback d = new SelectorChangedThreadedCallback(SelectorValueChangeThreaded);
                MoneySelector.Invoke(d, sender, e);
            }
            else
            {
                SelectorValueChange(sender, e);
            }
        }


        private void GameTable_Load(object sender, EventArgs e)
        {
            this.Size = new Size(975, 600);

            foreach (Label c in AllCards)
            {
                c.Text = "";
                c.Image = Properties.Resources.cardBG;
                c.AutoSize = false;
            }

            // Position Elements
            // Username1  (110, 240)  Username4 (Symmetrical)
            UsernameP1.Location = new Point(110, 240);
            UsernameP4.Location = new Point(this.Size.Width - UsernameP4.Size.Width - 110, 240);

            UsernameP2.Location = new Point(UsernameP1.Location.X + UsernameP1.Size.Width + OffsetX, UsernameP1.Location.Y + UsernameP1.Size.Height + P1C1.Size.Height + 10 + OffsetY);
            UsernameP3.Location = new Point(UsernameP4.Location.X - UsernameP3.Size.Width - OffsetX, UsernameP4.Location.Y + UsernameP3.Size.Height + P1C1.Size.Height + 10 + OffsetY);

            // Balance Position 17 px above username lbl
            BalanceP1.Location = new Point(UsernameP1.Location.X, UsernameP1.Location.Y - 17);
            BalanceP2.Location = new Point(UsernameP2.Location.X, UsernameP2.Location.Y - 17);
            BalanceP3.Location = new Point(UsernameP3.Location.X, UsernameP3.Location.Y - 17);
            BalanceP4.Location = new Point(UsernameP4.Location.X, UsernameP4.Location.Y - 17);

            SetCardsPos();
            
            // Set PotLabel
            PotLabel.Size = new Size(Turn.Location.X + Turn.Size.Width - Flop2.Location.X, Turn.Size.Height + 20);
            PotLabel.Location = new Point(Flop2.Location.X, Flop2.Location.Y + 60);
        }

        private void SetCardsPos()
        {
            // Player 1
            P1C1.Location = new Point(UsernameP1.Location.X + (UsernameP1.Size.Width / 2) - 3 - P1C1.Size.Width, UsernameP1.Location.Y + UsernameP1.Size.Height + 3);
            P1C2.Location = new Point(UsernameP1.Location.X + (UsernameP1.Size.Width / 2) + 3, UsernameP1.Location.Y + UsernameP1.Size.Height + 3);

            // PLayer 2
            P2C1.Location = new Point(UsernameP2.Location.X + (UsernameP2.Size.Width / 2) - 3 - P2C1.Size.Width, UsernameP2.Location.Y + UsernameP2.Size.Height + 3);
            P2C2.Location = new Point(UsernameP2.Location.X + (UsernameP2.Size.Width / 2) + 3, UsernameP2.Location.Y + UsernameP2.Size.Height + 3);

            // Player 3
            P3C1.Location = new Point(UsernameP3.Location.X + (UsernameP3.Size.Width / 2) - 3 - P3C1.Size.Width, UsernameP3.Location.Y + UsernameP3.Size.Height + 3);
            P3C2.Location = new Point(UsernameP3.Location.X + (UsernameP3.Size.Width / 2) + 3, UsernameP3.Location.Y + UsernameP3.Size.Height + 3);

            // Player 4
            P4C1.Location = new Point(UsernameP4.Location.X + (UsernameP4.Size.Width / 2) - 3 - P4C1.Size.Width, UsernameP4.Location.Y + UsernameP4.Size.Height + 3);
            P4C2.Location = new Point(UsernameP4.Location.X + (UsernameP4.Size.Width / 2) + 3, UsernameP4.Location.Y + UsernameP4.Size.Height + 3);

            // Community Cards
            int formCentre = this.Size.Width / 2;

            // 6px gap between cards
            Flop3.Location = new Point(formCentre - Flop3.Size.Width / 2, 140);
            Flop2.Location = new Point(Flop3.Location.X - 33, 140);
            Flop1.Location = new Point(Flop2.Location.X - 33, 140);

            Turn.Location = new Point(Flop3.Location.X + 33, 140);
            River.Location = new Point(Turn.Location.X + 33, 140);



        }

        private void SelectorValueChange(object sender, EventArgs e)
        {
            TrackBar selector = (TrackBar)sender;

            if (selector.Value == selector.Minimum)
            {
                if (selector.Value == 0)
                {
                    ActionBTN.Text = "Check";
                }
                else
                {
                    ActionBTN.Text = $"Call - ({selector.Value})";
                }
            }else if (selector.Value == selector.Maximum)
            {
                ActionBTN.Text = "All In";
                
            }
            else
            {
                ActionBTN.Text = $"Raise - (+{selector.Value - selector.Minimum})";
            }

            ActionBTN.Enabled = !(selector.Value == selector.Maximum);
        }

        #region Button Click Handlers

        private void FoldBTNClick(object sender, EventArgs e)
        {
            string response = NetworkCMDstringGenerator.MoveCommand("Fold");
            sock.Send(Encoding.UTF8.GetBytes(response));
            HideBTNS();
        }

        private void AllInBTNClick(object sender, EventArgs e)
        {
            string response = NetworkCMDstringGenerator.MoveCommand("All In", balance);
            balance = 0;

            sock.Send(Encoding.UTF8.GetBytes(response));
            HideBTNS();
        }

        private void ActionBTNClick(object sender, EventArgs e)
        {
            Button actionBTN = (Button)sender;
            string response;

            switch (actionBTN.Text)
            {
                case "Check":
                    response = NetworkCMDstringGenerator.MoveCommand("Check");
                    break;
                default:
                    response = NetworkCMDstringGenerator.MoveCommand(actionBTN.Text, MoneySelector.Value);
                    balance -= MoneySelector.Value;
                    break;
            }
            sock.Send(Encoding.UTF8.GetBytes(response));
            HideBTNS();
        }

        private void HideBTNS()
        {
            FoldBTN.Enabled = false;
            All_InBTN.Enabled = false;
            ActionBTN.Enabled = false;

            MoneySelector.Enabled = false;
        }
        #endregion


    }
}
