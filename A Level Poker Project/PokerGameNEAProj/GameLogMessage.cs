using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    static class GameLogMessage
    {
        public static string PlayerLogged(string username, string ip)
        {
            return $"{GetNowTime()} : [{ip}] > {username} has logged in\r\n";
        }
        public static string IPConnection(string ip)
        {
            return $"{GetNowTime()} > Connection from {ip}\r\n";
        }
        public static string UserJoinGame(string ip)
        {
            return $"{GetNowTime()} : [{ip}] > Joined Game\r\n";
        }

        public static string BBPay(string ip, string amount)
        {
            return $"{GetNowTime()} : [{ip}] > Payed the big blind of {amount}\r\n";
        }
        public static string SBPay(string ip, string amount)
        {
            return $"{GetNowTime()} : [{ip}] > Payed the small blind of {amount}\r\n";
        }

        public static string MoveMade(string ip, string action, string amount="0")
        {
            switch (action.ToLower())
            {
                case "call":
                    return $"{GetNowTime()} : [{ip}] Called {amount}\r\n";
                case "check":
                    return $"{GetNowTime()} : [{ip}] Checked\r\n";
                case "all-in":
                    return $"{GetNowTime()} : [{ip}] Went all in with {amount}\r\n";
                case "fold":
                    return $"{GetNowTime()} : [{ip}] Folded\r\n";
                case "raise":
                    return $"{GetNowTime()} : [{ip}] Raised to {amount}\r\n";
            }

            return $"{GetNowTime()} : [{ip}] Unknown action\r\n";
        }

        public static string WinnerDetermined(string ip, string amount)
        {
            return $"{GetNowTime()} : [{ip}] Won {amount}\r\n";
        }

        public static string GameEnd()
        {
            return $"{GetNowTime()} : Game Ended\r\n";
        }

        public static string OfflineEarning(string ip, string amount)
        {
            return $"{GetNowTime()} : [{ip}] Earned {amount} while offline";
        }

        private static string GetNowTime()
        {

            DateTime now = DateTime.Now;

            return $"[{now.Hour.ToString().PadLeft(2, '0')}:{now.Minute.ToString().PadLeft(2, '0')}:{now.Second.ToString().PadLeft(2, '0')}]";
        }
    }
}
