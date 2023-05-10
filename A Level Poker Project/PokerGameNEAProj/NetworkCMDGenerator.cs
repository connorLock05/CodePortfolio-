using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    internal static class NetworkCMDstringGenerator
    {
        public static string DataBaseSelectCommand(string Table, string where, params string[] args)
        {
            string command = "DBSELECT~" + Table.ToUpper() + ",";

            command += where + ",";

            for (int i = 0; i < args.Length - 1; i++)
            {
                command += args[i] + ",";
            }

            command += args.Last() + ";";

            return command;
        }

        public static string DataBaseUpdateCommand(string Table, string where, string newvalue)
        {
            // Command In Form DBUPDATE~TABLE,WHERE,COLUMN = VALUE

            string cmd = $"DBUPDATE~{Table.ToUpper()},{where},{newvalue};";

            return cmd;
        }


        public static string CardInfoCommand(string tablePos, string cardLoc, string number, string suit)
        {
            return $"CARDINFO~{tablePos},{cardLoc},{number},{suit};";
        }

        public static string LoginRequestCommand(string Username, string Password)
        {
            return $"LOGIN~{Username},{Password};";

        }

        public static string RegisterCommand(string[] args)
        {
            return $"REGISTER~{args[0]},{args[1]},{args[2]},{args[3]},{args[4]};";
        }

        public static string PlayersCommands(Dictionary<int, Player>.ValueCollection players, int BuyInFee)
        {
            string cmd = "PLAYERS~";
            for (int i = 0; i < players.Count - 1; i++)
            {
                cmd += $"{players.ElementAt(i).Username}:{BuyInFee},";
            }

            cmd += $"{players.Last().Username}:{BuyInFee};";

            return cmd;
        }

        internal static string TablePos()
        {
            return $"TABLEPOS;";
        }

        public static string TurnCommnad(int min, int max)
        {
            return $"TURN~{min},{max};";
        }

        public static string MoveCommand(string action, params int[] args)
        {
            string cmd = $"MOVE~{action}";

            foreach (int i in args)
            {
                cmd += $",{i};";
            }

            return cmd;
        }

        public static string RoundStartCommand(int UIDBB, int UIDSB, int BB, int SB)
        {
            return $"ROUND~{UIDBB},{UIDSB},{BB},{SB};";
        }


        public static string PotCommand(int amount, string reason)
        {
            return $"POT~{amount},{reason};";
        }

        internal static string PotUpdateCommand(int POT)
        {
            return $"POTUPDATE~{POT};";
        }

        public static string PlayerBalanceUpdate(Dictionary<int, int>.ValueCollection args)
        {
            string res = "BALANCEUPDATE~";

            for(int i=0; i < args.Count - 1; i++)
            {
                res += $"{args.ElementAt(i)},";
            }

            res += $"{args.Last()};";

            return res;
        }

        public static string WinnerCommand(int UID, int amount)
        {
            return $"WINNER~{UID},{amount};";
        }

        public static string SplitWinnerCommand(int amount, params int[] UIDs)
        {
            string res = "SPLITWIN~";

            for(int i=0; i<UIDs.Length; i++)
            {
                res += $"{UIDs[i]},";
            }

            res += $"{amount};";

            return res;
        }

        public static string HistoryRequest(int UID)
        {
            string res = $"HISTORYREQ~{UID};";

            return res;
        }

        public static string SeedRequest()
        {
            return "SEED;";
        }
    }
}
