using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Security.Policy;

namespace PokerGameNEAProj
{
    internal class DatabaseInteration
    {
        const string provStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=PokerDB.accdb";

        string selectCMD;
        OleDbCommand oleDBCMD;
        OleDbConnection conn;
        OleDbDataAdapter DataAdapt;
        DataTable dt;

        public DatabaseInteration()
        {
            conn = new OleDbConnection(provStr);
            dt = new DataTable();
        }

        public void RegisterUser(params string[] args)
        {
            // Args = [Username, password, email, fname, sname]
            string dateFormat = FormatDate(DateTime.Now);
            Debug.WriteLine(dateFormat);
            conn.Open();

            oleDBCMD = new OleDbCommand($"INSERT INTO {CONSTANTS.UT} ([{CONSTANTS.UTCols.UN}], [{CONSTANTS.UTCols.PW}], [{CONSTANTS.UTCols.EM}], [{CONSTANTS.UTCols.FN}], [{CONSTANTS.UTCols.SN}], [{CONSTANTS.UTCols.LO}]) VALUES(?, ?, ?, ?, ?, ?)", conn);

            // -- Add Parameters --
            oleDBCMD.Parameters.Add(new OleDbParameter(CONSTANTS.UTCols.UN, args[0]));
            oleDBCMD.Parameters.Add(new OleDbParameter(CONSTANTS.UTCols.PW, args[1]));
            oleDBCMD.Parameters.Add(new OleDbParameter(CONSTANTS.UTCols.EM, args[2]));
            oleDBCMD.Parameters.Add(new OleDbParameter(CONSTANTS.UTCols.FN, args[3]));
            oleDBCMD.Parameters.Add(new OleDbParameter(CONSTANTS.UTCols.SN, args[4]));
            oleDBCMD.Parameters.Add(new OleDbParameter(CONSTANTS.UTCols.LO, dateFormat));
            // -- Parameters End --

            


            oleDBCMD.ExecuteNonQuery();
            conn.Close();

        }

        public DataTable GetSelectData(string[] columns, string where, string table)
        {
            string selectColsStr = ArrayToOLEDBstring(columns);

            selectCMD = $"SELECT {selectColsStr} FROM {table} WHERE {where}";
            dt.Clear();
            try
            {
                conn.Open();
                DataAdapt = new OleDbDataAdapter(selectCMD, conn);
                conn.Close();
            }
            catch
            {
                dt.Clear();
                return dt;
            }

            DataAdapt.Fill(dt);

            return dt;
        }

        public void UpdateData(string SET, string WHERE, string TABLE)
        {
            string command = $"UPDATE {TABLE} SET {SET} WHERE {WHERE}";

            conn.Open();

            oleDBCMD = new OleDbCommand(command, conn);
            oleDBCMD.ExecuteNonQuery();
            conn.Close();
        }
        public DataTable GetUserData(string[] columns, string whereUser)
        {
            string selectColsStr = ArrayToOLEDBstring(columns);

            selectCMD = $"SELECT {selectColsStr} FROM {CONSTANTS.UT} WHERE Username = '{whereUser}'";
            try
            {
                conn.Open();
                DataAdapt = new OleDbDataAdapter(selectCMD, conn);
                conn.Close();
            } catch
            {
                dt.Clear();
                return dt;
            }
            DataAdapt.Fill(dt);

            return dt;
            
        }

        public List<string> ReturnCol(string column, string table)
        {
            selectCMD = $"SELECT [{column}] FROM {table.ToUpper()}";
            try
            {
                conn.Open();
                DataAdapt = new OleDbDataAdapter(selectCMD, conn);
                conn.Close();
            }
            catch
            {
                List<string> empty = new List<string>();
                return empty;
            }
            DataAdapt.Fill(dt);

            List<string> results = new List<string>();

            foreach (DataRow dr in dt.Rows)
            {
                results.Add(dr[column].ToString());
            }

            return results;
        }

        private string ArrayToOLEDBstring(string[] arr)
        {
            string result = "";

            for (int i = 0; i < arr.Length; i++)
            {
                if (i == arr.Length - 1)
                {
                    result += "[" + arr[i] + "]";
                }else
                {
                    result += "[" + arr[i] + "], ";
                }
            }

            return result;
        }

        private string FormatDate(DateTime now)
        {
            int day = now.Day;
            int month = now.Month;
            int year = now.Year;

            int hour = now.Hour;
            int minute = now.Minute;

            // Format is dd/mm/yyyy:hh.mm

            string dayStr = day.ToString();
            string monthStr = month.ToString();
            string hourStr = hour.ToString();
            string minuteStr = minute.ToString();
            string[] elems = new string[] {dayStr, monthStr, hourStr, minuteStr};

            for (int i=0; i<elems.Length; i++)
            {
                if (elems[i].Length == 1)
                {
                    elems[i] = "0" + elems[i];
                }
            }

            return $"{elems[0]}/{elems[1]}/{year}:{elems[2]}.{elems[3]}";
        }

        public void AddGameRecord(int noPlayers, int[] UIDs, Player[] players, Dictionary<int, int> CurrentBalance, Dictionary<int, int> BalanceAtStart)
        {
            string UIDstring = "";
            for(int i=0; i<UIDs.Length-1; i++)
            {
                UIDstring += $"{UIDs[i]},";
            }

            UIDstring += UIDs.Last();

            string command = $"INSERT INTO {CONSTANTS.GT} ([{CONSTANTS.GTCols.NP}], [{CONSTANTS.GTCols.PIDs}], [{CONSTANTS.GTCols.DP}]) VALUES (?, ?, ?)";

            conn.Open();

            oleDBCMD = new OleDbCommand(command, conn);

            oleDBCMD.Parameters.AddWithValue(CONSTANTS.GTCols.NP, noPlayers);
            oleDBCMD.Parameters.AddWithValue(CONSTANTS.GTCols.PIDs, UIDstring);
            oleDBCMD.Parameters.AddWithValue(CONSTANTS.GTCols.DP, FormatDate(DateTime.Now));

            oleDBCMD.ExecuteNonQuery();

            // Add player Table record for each user

            // Get GameID for the record just created

            string GIDrecent = GetMostRecentGameID();


            for (int i=0; i<players.Length; i++)
            {
                command = $"INSERT INTO {CONSTANTS.PT} ([{CONSTANTS.PTCols.UID}], [{CONSTANTS.PTCols.GID}],[{CONSTANTS.PTCols.PP}], [{CONSTANTS.PTCols.BC}], [{CONSTANTS.PTCols.HC}]) VALUES (?, ?, ?, ?, ?)";

                

                oleDBCMD = new OleDbCommand(command, conn);

                oleDBCMD.Parameters.AddWithValue(CONSTANTS.PTCols.UID, players[i].UID);
                oleDBCMD.Parameters.AddWithValue(CONSTANTS.PTCols.GID, GIDrecent);
                oleDBCMD.Parameters.AddWithValue(CONSTANTS.PTCols.PP, i+1);
                oleDBCMD.Parameters.AddWithValue(CONSTANTS.PTCols.BC, CurrentBalance[players[i].UID] - BalanceAtStart[players[i].UID]);
                oleDBCMD.Parameters.AddWithValue(CONSTANTS.PTCols.HC, HandToDBstring(players[i].EndHand));

                oleDBCMD.ExecuteNonQuery();
            }

            conn.Close();
        }

        public void AmmendHandData(Player[] players)
        {
            foreach (Player player in players)
            {
                string colName;

                switch (player.EndHand.Ranking)
                {
                    case 1:
                        colName = CONSTANTS.HSCols.HC;
                        break;
                    case 2:
                        colName = CONSTANTS.HSCols.OP;
                        break;
                    case 3:
                        colName = CONSTANTS.HSCols.TP;
                        break;
                    case 4:
                        colName = CONSTANTS.HSCols.TK;
                        break;
                    case 5:
                        colName = CONSTANTS.HSCols.St;
                        break;
                    case 6:
                        colName = CONSTANTS.HSCols.Fl;
                        break;
                    case 7:
                        colName = CONSTANTS.HSCols.FH;
                        break;
                    case 8:
                        colName = CONSTANTS.HSCols.FK;
                        break;
                    case 9:
                        colName = CONSTANTS.HSCols.SF;
                        break;
                    case 10:
                        colName = CONSTANTS.HSCols.RF;
                        break;
                    default:
                        colName = "null";
                        break;
                }

                if (colName != "null")
                {
                    // Get value at colName Pos

                    int CurrentAtPos = GetHandStatValueAt(colName);

                    // Increment by 1 and re-assign

                    UpdateHandStatAt(colName, ++CurrentAtPos);

                }
            }
        }


        private string GetMostRecentGameID()
        {
            string command = $"SELECT TOP 1 {CONSTANTS.GTCols.GID} FROM {CONSTANTS.GT} ORDER BY {CONSTANTS.GTCols.GID} DESC";

            DataAdapt = new OleDbDataAdapter(command, conn);

            dt.Clear();
            DataAdapt.Fill(dt);

            return dt.Rows[0][CONSTANTS.GTCols.GID].ToString();
        }

        private int GetHandStatValueAt(string colName)
        {
            string command = $"SELECT {colName} FROM {CONSTANTS.HS}";

            conn.Open();

            DataAdapt = new OleDbDataAdapter(command, conn);

            dt.Clear();

            DataAdapt.Fill(dt);

            conn.Close();

            int result = int.Parse(dt.Rows[0][colName].ToString());

            return result;
        }

        private void UpdateHandStatAt(string colName, int value)
        {
            string command = $"UPDATE {CONSTANTS.HS} SET {colName} = {value}";

            conn.Open();

            oleDBCMD = new OleDbCommand(command, conn);

            oleDBCMD.ExecuteNonQuery();
            conn.Close();
        }

        private string HandToDBstring(Hand hand)
        {
            string res = "";

            for(int i=0; i<hand.Cards.Length-1; i++)
            {
                res += $"{hand.Cards[i].CardToDB()},";
            }

            res += hand.Cards.Last().CardToDB();

            return res;
        }
        public int UpdateUserDate(int UID)
        {
            string command = $"SELECT {CONSTANTS.UTCols.LO} FROM {CONSTANTS.UT} WHERE {CONSTANTS.UTCols.UID} = {UID}";

            conn.Open();

            DataAdapt = new OleDbDataAdapter(command, conn);
            dt.Clear();
            DataAdapt.Fill(dt);

            string currentTime = dt.Rows[0][CONSTANTS.UTCols.LO].ToString();
            string newTime = FormatDate(DateTime.Now);

            command = $"UPDATE {CONSTANTS.UT} SET {CONSTANTS.UTCols.LO} = '{newTime}' WHERE {CONSTANTS.UTCols.UID} = {UID}";

            oleDBCMD = new OleDbCommand(command, conn);

            oleDBCMD.ExecuteNonQuery();
            conn.Close();

            // Find Time Difference in hours
            // Year = 8,760 hours
            // Month = 744 Hours
            // Day = 24 Hours

            // Time Format = 'dd/mm/yyyy:HH.MM'

            string[] dateTimeSplitNew = newTime.Split(':');
            string[] dateTimeSplitOld = currentTime.Split(':');

            string[] valuesSplitNew = (dateTimeSplitNew[0].Split('/').Concat(dateTimeSplitNew[1].Split('.'))).ToArray();
            string[] valuesSplitOld = (dateTimeSplitOld[0].Split('/').Concat(dateTimeSplitOld[1].Split('.'))).ToArray();

            int YearDif = int.Parse(valuesSplitNew[2]) - int.Parse(valuesSplitOld[2]);
            int MonthDif = int.Parse(valuesSplitNew[1]) - int.Parse(valuesSplitOld[1]);
            int DayDif = int.Parse(valuesSplitNew[0]) - int.Parse(valuesSplitOld[0]);
            int HourDif = int.Parse(valuesSplitNew[3]) - int.Parse(valuesSplitOld[3]);

            int TotalHourDif = (YearDif * 8760) + (MonthDif * 744) + (DayDif * 24) + HourDif;

            return TotalHourDif * CONSTANTS.OFFLINERATE;

        }

        public DataTable GetHandData()
        {
            string command = $"SELECT * FROM {CONSTANTS.HS}";

            conn.Open();

            DataAdapt = new OleDbDataAdapter(command, conn);

            dt.Clear();
            DataAdapt.Fill(dt);

            conn.Close();

            return dt;
        }

        public DataTable GetHistory(int UID)
        {
            DataTable dt = new DataTable();

            string cmd = $"SELECT {CONSTANTS.GTCols.DP}, {CONSTANTS.PTCols.BC}, {CONSTANTS.PTCols.HC} FROM {CONSTANTS.GT}, {CONSTANTS.PT} WHERE ({CONSTANTS.PT}.{CONSTANTS.GTCols.GID} = {CONSTANTS.GT}.{CONSTANTS.GTCols.GID}) AND {CONSTANTS.PTCols.UID} = {UID};";

            conn.Open();

            DataAdapt = new OleDbDataAdapter(cmd, conn);
            DataAdapt.Fill(dt);

            conn.Close();

            return dt;

        }

        public string CardDBToString(string DBform)
        {
            // DBform[0] = Value (T = 10)
            // DBform[1] = Suit  (1 = Clubs, 2 = Hearts, 3 = Spades, 4 = Diamonds)

            string value = DBform[0].ToString();
            char suit = DBform[1];

            if (value == "T") { value = "10"; }

            // Suits : ♠ ♣ ♥ ♦

            switch (suit)
            {
                case '1':
                    suit = '♣';
                    break;
                case '2':
                    suit = '♥';
                    break;
                case '3':
                    suit = '♠';
                    break;
                case '4':
                    suit = '♦';
                    break;

            }

            return $"{value}{suit}";
        }

        public int GetSeed()
        {
            string command = $"SELECT {CONSTANTS.RSCols.Se} FROM {CONSTANTS.RS}";

            conn.Open();
            DataAdapt = new OleDbDataAdapter(command , conn);
            dt.Clear();

            DataAdapt.Fill(dt);

            int seed = int.Parse(dt.Rows[0][CONSTANTS.RSCols.Se].ToString());

            command = $"UPDATE {CONSTANTS.RS} SET {CONSTANTS.RSCols.Se} = {seed + 1}";

            oleDBCMD = new OleDbCommand(command, conn);

            oleDBCMD.ExecuteNonQuery();

            conn.Close();

            return seed;
        }
    }
}
