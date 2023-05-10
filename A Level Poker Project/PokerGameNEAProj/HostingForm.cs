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
using System.Net;
using System.IO;

namespace PokerGameNEAProj
{
    public partial class HostingForm : Form
    {

        string[] handNames = { CONSTANTS.HSCols.RF, CONSTANTS.HSCols.SF, CONSTANTS.HSCols.FK, CONSTANTS.HSCols.FH, CONSTANTS.HSCols.Fl, CONSTANTS.HSCols.St, CONSTANTS.HSCols.TK, CONSTANTS.HSCols.TP, CONSTANTS.HSCols.OP, CONSTANTS.HSCols.HC };

        Socket[] AllSockets;
        Dictionary<int, Player> Players;
        int playersDue;
        int[] UIDArray;
        TcpListener listen;
        int[] PlayerBalances;
        string LoggedUsers;
        int playerReference;
        bool GameActive;
        int PlayersConnected;
        int PlayersJoined;
        Player[] playerList;
        Queue<Player> Turns;
        Player currentPlayer;
        int BB = 0;
        int SB = 0;

        int POT = 0;

        int recentBet = 0;

        int checksInRow = 0;
        int GameDepth = 0;

        Dictionary<int, int> PlayerInGameBalance;
        Dictionary<int, int> PlayersInFor;
        Dictionary<int, int> BalanceAtStart;

        Card[] communityCards;
        private bool started;

        public HostingForm(int playersDue)
        {
            InitializeComponent();
            this.playersDue = playersDue;
            AllSockets = new Socket[playersDue];
            Players = new Dictionary<int, Player>();
            listen = new TcpListener(System.Net.IPAddress.Any, 5768);
            GameActive = false;
            PlayerBalances = new int[playersDue];
            playerList = new Player[playersDue];
            playerReference = 0;
            listen.Start();
            PlayersConnected = 0;
            PlayersJoined = 0;
            communityCards = new Card[5];
            UIDArray = new int[playersDue];
            Turns = new Queue<Player>();
            started = false;
            PlayerInGameBalance = new Dictionary<int, int>();
            PlayersInFor = new Dictionary<int, int>();
            BalanceAtStart = new Dictionary<int, int>();

            int temp = playersDue;
            Socket sock;
            TcpClient client;
            IPEndPoint end;

            while (temp > 0)
            {
                client = listen.AcceptTcpClient();
                sock = client.Client;
                AllSockets[playersDue - temp] = sock;
                end = client.Client.RemoteEndPoint as IPEndPoint;

                AppendGameLog(GameLogMessage.IPConnection(end.Address.ToString()));

                ThreadPool.QueueUserWorkItem(HandleClient, new object[] {sock, end.Address.ToString()});
                temp--;
            }

            listen.Stop();
        }

        

        private void HandleClient(object obj)
        {
            object[] args = (object[])obj;

            Debug.WriteLine("New Socket Handler");
            DatabaseInteration dbi = new DatabaseInteration();

            Socket sock = (Socket)args[0];
            string endIP = (string)args[1];

            
            int UID = 0;
            byte[] buffer = new byte[128];
            
            DataTable dataTable = new DataTable();
            string TablePos = (Array.IndexOf(UIDArray, UID) + 1).ToString();

            

            buffer = new byte[2048];

            

            string BytesRecivedStr;

            while (sock.Connected)
            {
                buffer = new byte[2048];
                sock.Receive(buffer);

                BytesRecivedStr = Encoding.UTF8.GetString(buffer);

                if (BytesRecivedStr == new string('\0', 2048)) { continue; }

                string[] commands = BytesRecivedStr.Split(';');
                
                foreach (string command in commands)
                {
                    
                    // Handle recieved commands
                    NetworkCMD netCommand = new NetworkCMD(command);
                    if (netCommand.Command == "") { continue; }

                    switch (netCommand.Command.ToUpper())
                    {
                        // Command Cases here
                        #region Login Case
                        case "LOGIN":
                            // Login command has 2 params (0: Username, 1: Password (Not Hashed))
                            string Username = netCommand.Args[0];
                            string PasswordHashed = Hashing.HashStr(netCommand.Args[1]);

                            dataTable = dbi.GetUserData(new string[] { CONSTANTS.UTCols.PW }, Username);
                            if (dataTable.Rows.Count > 0)
                            {
                                if (dataTable.Rows[0][CONSTANTS.UTCols.PW].ToString() == PasswordHashed)
                                {
                                    dataTable.Clear();
                                    dataTable = dbi.GetUserData(new string[] { CONSTANTS.UTCols.UID }, Username);
                                    UID = (int)dataTable.Rows[0][CONSTANTS.UTCols.UID];

                                    dataTable.Clear();
                                    dataTable = dbi.GetUserData(new string[] { CONSTANTS.UTCols.GB }, Username);
                                    if (!UIDArray.Contains(UID))
                                    {
                                        // User is available


                                        PlayerBalances[playerReference] = int.Parse(dataTable.Rows[0][CONSTANTS.UTCols.GB].ToString());
                                        UIDArray[playerReference] = UID;
                                        Player player = new Player(UID, playerReference, Username, PlayerBalances[playerReference], sock, endIP);
                                        playerList[playerReference] = player;
                                        Turns.Enqueue(player);
                                        Players[UID] = player;
                                        PlayerInGameBalance[UID] = 0;
                                        PlayersInFor[UID] = 0;
                                        BalanceAtStart[UID] = 0;

                                        playerReference++;

                                        // Update User Last Online
                                        int BalanceAddition = dbi.UpdateUserDate(UID);

                                        AppendGameLog(GameLogMessage.OfflineEarning(endIP, BalanceAddition.ToString()));

                                        int currentBal = PlayerBalances[playerReference - 1];

                                        currentBal += BalanceAddition;

                                        dbi.UpdateData($"{CONSTANTS.UTCols.GB} = {currentBal}", $"{CONSTANTS.UTCols.UID} = {UID}", CONSTANTS.UT);

                                        if (++PlayersConnected == playersDue)
                                        {
                                            InitiateControls();
                                        }

                                        // Correct Details
                                        sock.Send(Encoding.UTF8.GetBytes("Valid"));
                                        AppendGameLog(GameLogMessage.PlayerLogged(Username, endIP));

                                        LoggedUsers += $"{Username} : {UID}\n";
                                        SetConnectedPlayers(LoggedUsers);
                                    }
                                    else
                                    {
                                        // Account in use
                                        sock.Send(Encoding.UTF8.GetBytes("Invalid"));
                                    }
                                }
                                else
                                {
                                    // Incorrect Details
                                    sock.Send(Encoding.UTF8.GetBytes("Invalid"));
                                }
                            }
                            else
                            {
                                sock.Send(Encoding.UTF8.GetBytes("Invalid"));
                            }
                            break;
                        #endregion
                        #region Register Case
                        case "REGISTER":
                            // Register command has 5 params
                            // 0: Username
                            // 1: Password (Not Hashed)
                            // 2: Email
                            // 3: First Name
                            // 4: Surname

                            List<string> ActiveUsernames = dbi.ReturnCol(CONSTANTS.UTCols.UN, CONSTANTS.UT);
                            List<string> ActiveEmails = dbi.ReturnCol(CONSTANTS.UTCols.EM, CONSTANTS.UT);

                            if (ActiveUsernames.Contains(netCommand.Args[0]))
                            {
                                sock.Send(Encoding.UTF8.GetBytes("U"));
                            }
                            else if (ActiveEmails.Contains(netCommand.Args[2]))
                            {
                                sock.Send(Encoding.UTF8.GetBytes("E"));
                            }
                            else
                            {
                                dbi.RegisterUser(netCommand.Args);
                                sock.Send(Encoding.UTF8.GetBytes("R"));
                            }
                            break;
                        #endregion
                        #region DBSelect Case
                        case "DBSELECT":
                            // First Arg is table
                            // Second is the where condition
                            // Rest are columns to select

                            List<string> results = new List<string>();

                            string TABLE = netCommand.Args[0];
                            string WHERE = netCommand.Args[1];
                            string[] COLUMNS = new string[netCommand.Args.Length - 2];

                            for (int i = 0; i < netCommand.Args.Length; i++)
                            {
                                if (i == 0 || i == 1) { continue; }

                                COLUMNS[i - 2] = netCommand.Args[i];
                            }

                            dataTable.Clear();
                            dataTable = dbi.GetSelectData(COLUMNS, WHERE, TABLE);

                            if (dataTable.Rows.Count == 0)
                            {
                                sock.Send(Encoding.UTF8.GetBytes("E"));
                                break;
                            }

                            foreach (string col in COLUMNS)
                            {
                                results.Add(dataTable.Rows[0][col].ToString());
                            }

                            string joiner = "RESPONSE~";

                            foreach (string result in results)
                            {
                                joiner += result + ",";
                            }

                            joiner.Remove(joiner.Length - 1);

                            buffer = Encoding.UTF8.GetBytes(joiner);
                            sock.Send(buffer);

                            break;
                        #endregion
                        #region DBUpdate Case
                        case "DBUPDATE":
                            // Params are Table, Where, Set
                            //              0      1     2
                            string Table = netCommand.Args[0];
                            string Where = netCommand.Args[1];
                            string Set = netCommand.Args[2];

                            dbi.UpdateData(Set, Where, Table);

                            break;
                        #endregion
                        #region Join Case
                        case "JOIN":
                            if (GameActive)
                            {
                                sock.Send(Encoding.UTF8.GetBytes($"O~{BuyInNUD.Value}"));
                            }
                            else
                            {
                                sock.Send(Encoding.UTF8.GetBytes("N"));
                            }

                            break;
                        #endregion
                        #region Players Case
                        case "PLAYERS":
                            // Requesting Number of Players
                            buffer = Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.PlayersCommands(Players.Values, Convert.ToInt32(BuyInNUD.Value)));
                            sock.Send(buffer);


                            string CardCommand = NetworkCMDstringGenerator.CardInfoCommand(TablePos, "0", Players[UID].PocketCards[0].Number.ToString(), Players[UID].PocketCards[0].Suit.ToString());

                            sock.Send(Encoding.UTF8.GetBytes(CardCommand));

                            CardCommand = NetworkCMDstringGenerator.CardInfoCommand(TablePos, "1", Players[UID].PocketCards[1].Number.ToString(), Players[UID].PocketCards[1].Suit.ToString());
                            sock.Send(Encoding.UTF8.GetBytes(CardCommand));

                            if (++PlayersJoined == playersDue)
                            {
                                // Initiate Game Start
                                // P1 has first turn
                                // Move counter-clockwise

                                string cmd = NetworkCMDstringGenerator.RoundStartCommand(Players.Keys.ElementAt(0), Players.Keys.ElementAt(1), BB, SB);
                                buffer = Encoding.UTF8.GetBytes(cmd);

                                foreach (Socket sck in AllSockets)
                                {
                                    sck.Send(buffer);
                                }
                                Player temp = Turns.Dequeue();
                                Turns.Enqueue(temp);
                                temp = Turns.Dequeue();
                                Turns.Enqueue(temp);
                            }
                            AppendGameLog(GameLogMessage.UserJoinGame(endIP));
                            PlayerInGameBalance[UID] = (int)BuyInNUD.Value;
                            BalanceAtStart[UID] = (int)BuyInNUD.Value;
                            break;
                        #endregion
                        #region CardRequest Case
                        case "CARDREQUEST":
                            // Two args
                            // args[0] = tablePos   (1-4 = Player Ref --- 0 = Community)
                            // args[1] = cardPos    (1-5 = Position in reference)

                            string cardInfoCommand;
                            Card reference;
                            int CardIndex = int.Parse(netCommand.Args[1]) - 1;


                            switch (netCommand.Args[0])
                            {
                                case "0":
                                    reference = communityCards[CardIndex];

                                    cardInfoCommand = NetworkCMDstringGenerator.CardInfoCommand(netCommand.Args[0], netCommand.Args[1], reference.Number.ToString(), reference.Suit.ToString());
                                    buffer = Encoding.UTF8.GetBytes(cardInfoCommand);

                                    sock.Send(buffer);
                                    break;
                                default:
                                    int PlayerIndex = int.Parse(netCommand.Args[0]) - 1;
                                    reference = Players[PlayerIndex].PocketCards[CardIndex];

                                    cardInfoCommand = NetworkCMDstringGenerator.CardInfoCommand(netCommand.Args[0], netCommand.Args[1], reference.Number.ToString(), reference.Suit.ToString());
                                    buffer = Encoding.UTF8.GetBytes(cardInfoCommand);

                                    sock.Send(buffer);
                                    break;
                            }

                            break;
                        #endregion
                        #region Pot Case
                        case "POT":
                            // 2 Arg - amount to add to pot, reason for payment
                            POT += int.Parse(netCommand.Args[0]);
                            
                            #region POT Addition Reasons
                            switch (netCommand.Args[1])
                            {
                                case "BB":
                                    AppendGameLog(GameLogMessage.BBPay(endIP, netCommand.Args[0]));
                                    break;
                                case "SB":
                                    AppendGameLog(GameLogMessage.SBPay(endIP, netCommand.Args[0]));
                                    break;
                            }
                            #endregion

                            // Signal pot change to all users
                            foreach (Socket s in AllSockets)
                            {
                                s.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.PotUpdateCommand(POT)));
                            }

                            PlayerInGameBalance[UID] -= Convert.ToInt32(netCommand.Args[0]);
                            PlayersInFor[UID] += Convert.ToInt32(netCommand.Args[0]);
                            break;
                        #endregion
                        #region TablePos Case
                        case "TABLEPOS":
                            // 0 args
                            sock.Send(Encoding.UTF8.GetBytes(TablePos));
                            break;
                        #endregion
                        #region Move Case
                        case "MOVE":
                            // 1st arg shows move
                            string response;
                            switch (netCommand.Args[0].ToUpper())
                            {
                                case "FOLD":
                                    checksInRow++;
                                    if (Turns.Count == 1)
                                    {
                                        Player winner = Turns.Dequeue();

                                        // winner wins the pot

                                        PlayerInGameBalance[winner.UID] += POT;

                                        POT = 0;

                                        // Game Reset

                                        started = false;
                                        checksInRow = 0;
                                    }

                                    AppendGameLog(GameLogMessage.MoveMade(endIP, "fold"));
                                    break;
                                case "CALL":
                                    POT += int.Parse(netCommand.Args[1]);
                                    recentBet = int.Parse(netCommand.Args[1]);
                                    PlayerInGameBalance[UID] -= Convert.ToInt32(netCommand.Args[1]);
                                    PlayersInFor[UID] += Convert.ToInt32(netCommand.Args[1]);

                                    response = NetworkCMDstringGenerator.PotUpdateCommand(POT);
                                    AllPlayersSend(response);
                                    Turns.Enqueue(currentPlayer);

                                    checksInRow = 0;

                                    AppendGameLog(GameLogMessage.MoveMade(endIP, "call", netCommand.Args[1]));

                                    break;
                                case "ALL IN":
                                    POT += int.Parse(netCommand.Args[1]);
                                    recentBet = int.Parse(netCommand.Args[1]);
                                    PlayerInGameBalance[UID] -= Convert.ToInt32(netCommand.Args[1]);
                                    PlayersInFor[UID] += Convert.ToInt32(netCommand.Args[1]);

                                    response = NetworkCMDstringGenerator.PotUpdateCommand(POT);
                                    AllPlayersSend(response);
                                    Turns.Enqueue(currentPlayer);

                                    checksInRow = 0;

                                    AppendGameLog(GameLogMessage.MoveMade(endIP, "all-in", netCommand.Args[1]));

                                    break;
                                case "CHECK":
                                    Turns.Enqueue(currentPlayer);
                                    checksInRow++;

                                    AppendGameLog(GameLogMessage.MoveMade(endIP, "check"));

                                    break;
                                default:
                                    // Raise Case
                                    POT += int.Parse(netCommand.Args[1]);
                                    recentBet = int.Parse(netCommand.Args[1]);
                                    PlayerInGameBalance[UID] -= Convert.ToInt32(netCommand.Args[1]);
                                    PlayersInFor[UID] += Convert.ToInt32(netCommand.Args[1]);

                                    response = NetworkCMDstringGenerator.PotUpdateCommand(POT);
                                    AllPlayersSend(response);
                                    Turns.Enqueue(currentPlayer);

                                    checksInRow = 0;

                                    AppendGameLog(GameLogMessage.MoveMade(endIP, "raise", netCommand.Args[1]));

                                    break;
                            }

                            foreach (Socket s in AllSockets)
                            {
                                s.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.PotUpdateCommand(POT)));
                            }

                            currentPlayer = Turns.Dequeue();
                            currentPlayer.Sock.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.TurnCommnad(PlayersInFor.Values.Max() - PlayersInFor[currentPlayer.UID], PlayerInGameBalance[currentPlayer.UID])));
                            break;
                        #endregion
                        #region History Request
                        case "HISTORYREQ":
                            // 1 arg
                            // UID

                            int TargetUID = int.Parse(netCommand.Args[0]);

                            DataTable dt = dbi.GetHistory(TargetUID);

                            // Foreach row format and pack into string for sending

                            string res = "";

                            foreach (DataRow dr in dt.Rows)
                            {
                                string date = dr[CONSTANTS.GTCols.DP].ToString();
                                string balanceChange = dr[CONSTANTS.PTCols.BC].ToString();
                                string handCards = dr[CONSTANTS.PTCols.HC].ToString();

                                string[] cardsArray = handCards.Split(',');
                                for(int i = 0; i<cardsArray.Length; i++)
                                {
                                    cardsArray[i] = dbi.CardDBToString(cardsArray[i]);
                                }

                                handCards = "";
                                for (int i=0; i<cardsArray.Length-1; i++)
                                {
                                    handCards += $"{cardsArray[i]},";
                                }
                                handCards += cardsArray.Last();

                                res += $"[{date}] > Hand: {handCards}  --  Balance Change: {balanceChange}" + Environment.NewLine;
                            }

                            sock.Send(Encoding.UTF8.GetBytes(res));

                            break;
                        #endregion
                    }
                    dataTable.Clear();
                }
                if (PlayersJoined == playersDue && !started && GameActive)
                {
                    started = true;

                    currentPlayer = Turns.Dequeue();
                    currentPlayer.Sock.Send(Encoding.UTF8.GetBytes(NetworkCMDstringGenerator.TurnCommnad(PlayersInFor.Values.Max() - PlayersInFor[currentPlayer.UID], PlayerInGameBalance[currentPlayer.UID])));

                }



                if (started)
                {
                    
                    string responseCmd = NetworkCMDstringGenerator.PlayerBalanceUpdate(PlayerInGameBalance.Values);

                    buffer = Encoding.UTF8.GetBytes(responseCmd);

                    foreach (Socket s in AllSockets)
                    {
                        s.Send(buffer);
                    }
                    if (checksInRow == PlayersJoined)
                    {
                        // Next round 
                        GameDepth++;
                        string card1Signal;
                        switch (GameDepth)
                        {
                            case 1:
                                // Show the Flop
                                card1Signal = NetworkCMDstringGenerator.CardInfoCommand("0", "1", communityCards[0].Number.ToString(), communityCards[0].Suit.ToString());
                                string card2Signal = NetworkCMDstringGenerator.CardInfoCommand("0", "2", communityCards[1].Number.ToString(), communityCards[1].Suit.ToString());
                                string card3Signal = NetworkCMDstringGenerator.CardInfoCommand("0", "3", communityCards[2].Number.ToString(), communityCards[2].Suit.ToString());


                                AllPlayersSend(card1Signal + card2Signal + card3Signal);

                                checksInRow = 0;
                                break;
                            case 2:
                                card1Signal = NetworkCMDstringGenerator.CardInfoCommand("0", "4", communityCards[3].Number.ToString(), communityCards[3].Suit.ToString());

                                AllPlayersSend(card1Signal);

                                checksInRow = 0;
                                break;
                            case 3:
                                card1Signal = NetworkCMDstringGenerator.CardInfoCommand("0", "5", communityCards[4].Number.ToString(), communityCards[4].Suit.ToString());
                                AllPlayersSend(card1Signal);

                                checksInRow = 0;
                                break;
                            case 4:
                                // End Game
                                GameActive = false;
                                // Evaluate Hands
                                if (Turns.Count != PlayersJoined) { Turns.Enqueue(currentPlayer); }

                                List<Player> dbiList = new List<Player>();

                                while (Turns.Count > 0) 
                                {
                                    Player temp = Turns.Dequeue();
                                    dbiList.Add(temp);
                                    Debug.WriteLine($"Set {temp.Username} Hand");

                                    Card[] cardsTemp = communityCards.Concat(temp.PocketCards).ToArray();
                                    temp.EndHand = Algorithms.SevenCardEval(cardsTemp);
                                }
                                // Find Potential Ties

                                List<Player> potentialTies = new List<Player>();
                                foreach(Player p in Players.Values)
                                {
                                    if (potentialTies.Count == 0)
                                    {
                                        potentialTies.Add(p);
                                    }
                                    else
                                    {
                                        if (potentialTies[0].EndHand.Ranking < p.EndHand.Ranking)
                                        {
                                            potentialTies.Clear();
                                            potentialTies.Add(p);
                                        }else if (potentialTies[0].EndHand.Ranking == p.EndHand.Ranking)
                                        {
                                            potentialTies.Add(p);
                                        }
                                    }
                                }

                                string result;

                                if (potentialTies.Count == 1)
                                {
                                    // This is winner
                                    result = NetworkCMDstringGenerator.WinnerCommand(potentialTies[0].UID, POT);
                                    PlayerInGameBalance[potentialTies[0].UID] += POT;

                                    AppendGameLog(GameLogMessage.WinnerDetermined(potentialTies[0].EndIP, POT.ToString()));
                                }
                                else
                                {
                                    potentialTies = Algorithms.DetermineWinner(potentialTies.ToArray()).ToList();

                                    // These users win / tie
                                    if (potentialTies.Count == 1)
                                    {
                                        // This is winner
                                        result = NetworkCMDstringGenerator.WinnerCommand(potentialTies[0].UID, POT);
                                        PlayerInGameBalance[potentialTies[0].UID] += POT;

                                        AppendGameLog(GameLogMessage.WinnerDetermined(potentialTies[0].EndIP, POT.ToString()));
                                    }
                                    else
                                    {
                                        // Split Win
                                        int[] UIDs = new int[potentialTies.Count];
                                        int amount = POT / potentialTies.Count;
                                        for (int i=0; i<potentialTies.Count; i++)
                                        {
                                            UIDs[i] = potentialTies[i].UID;
                                            PlayerInGameBalance[UIDs[i]] += amount;
                                        }

                                        result = NetworkCMDstringGenerator.SplitWinnerCommand(POT/potentialTies.Count, UIDs);

                                        foreach (int UIDiter in UIDs)
                                        {
                                            PlayerInGameBalance[UIDiter] += POT / potentialTies.Count;

                                            AppendGameLog(GameLogMessage.WinnerDetermined(Players[UIDiter].EndIP, (POT / potentialTies.Count).ToString()));
                                        }

                                    }
                                }

                                POT = 0;

                                AllPlayersSend(result);

                                checksInRow = 0;
                                GameDepth = 0;
                                // Start new game on host signal
                                started = false;

                                // Add data to database
                                dbi.AddGameRecord(playersDue, UIDArray, dbiList.ToArray(), PlayerInGameBalance, BalanceAtStart);
                                dbi.AmmendHandData(dbiList.ToArray());

                                AllPlayersSend("CLOSEGAME");
                                AppendGameLog(GameLogMessage.GameEnd());

                                break;

                        }
                    }
                }
            }
        }



        #region Set Connected Players Callback
        delegate void SetConnectedPlayersCallback(string newText);
        private void SetConnectedPlayers(string newText)
        {
            if (this.ConnectedPlayersLBL.InvokeRequired)
            {
                SetConnectedPlayersCallback d = new SetConnectedPlayersCallback(SetConnectedPlayers);
                this.Invoke(d, new object[] { newText });
            }
            else
            {
                ConnectedPlayersLBL.Text = newText;
            }
            
        }
        #endregion

        #region Initiate Controls Callback
        delegate void InitiateControlsCallback();
        private void InitiateControls()
        {
            if (this.StartGameBTN.InvokeRequired)
            {
                InitiateControlsCallback d = new InitiateControlsCallback(InitiateControls);
                this.Invoke(d);
            } else
            {
                StartGameBTN.Enabled = true;
                BuyInNUD.Minimum = 200;
                BuyInNUD.Maximum = PlayerBalances.Min();
            }
        }
        #endregion

        #region Append Game Log Callback
        delegate void AppendGameLogCallBack(string message);
        private void AppendGameLog(string message)
        {
            if (GameLog.InvokeRequired)
            {
                AppendGameLogCallBack d = new AppendGameLogCallBack(AppendGameLog);
                GameLog.Invoke(d, new object[] { message });
            }
            else
            {
                GameLog.Text += message;
            }
        }
        #endregion
        private void StartGameBTN_Click(object sender, EventArgs e)
        {
            StartGameBTN.Enabled = false;
            CloseGameBTN.Enabled = true;
            // Initiate Game
            GameActive = true;
            Deck deck = new Deck();

            // Set All Cards Server Side
            for (int i = 0; i < 2; i++)
            {
                foreach (KeyValuePair<int, Player> player in this.Players)
                {
                    Card card = deck.PopCard();
                    
                    player.Value.SetPocketCards(card, i);
                }
            }

            for (int i=0; i<5; i++)
            {
                communityCards[i] = deck.PopCard();
            }

            BB = Convert.ToInt32(BuyInNUD.Value / 100);
            SB = BB / 2;

            

            
        }

        private void CloseGameBTN_Click(object sender, EventArgs e)
        {
            
            // Something I'm Yet To Figure Out

            if (!started)
            {
                StartGameBTN.Enabled = true;
                CloseGameBTN.Enabled = false;

                string signal = "CLOSEGAME";

                AllPlayersSend(signal);
            }
        }

        private void AllPlayersSend(string command)
        {
            foreach(Socket s in AllSockets)
            {
                s.Send(Encoding.UTF8.GetBytes(command));
            }
        }

        private void ExportBTN_Click(object sender, EventArgs e)
        {
            // Prompt to save card data to csv file
            DatabaseInteration dbi = new DatabaseInteration();

            DataTable results = dbi.GetHandData();

            DataRow resRow = results.Rows[0];

            Stream fileStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((fileStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter sw = new StreamWriter(fileStream);

                    foreach (string s in handNames)
                    {
                        sw.Write($"{s},{resRow[s]}\n");
                    }

                    sw.Close();

                    fileStream.Close();
                }
            }

        }
    }
}
