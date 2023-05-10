using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    static class CONSTANTS
    {

        public const string PASSWORDVALIDATIONPATTERN = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!£$^*<>?/.|+-_])[A-Za-z\d!£$^*<>?/.|+-_]{8,}$";
        public const string EMAILVALIDATIONPATTERN = @"^[A-Za-z\d@!£$&#]+@(outlook(\.co\.uk|\.com)|hotmail(\.co\.uk|\.com)|gmail\.com|exe\-coll\.ac\.uk)$";
        public const string USERNAMEVALIDATIONPATTERN = @"^([A-Za-z\d!£$^*<>?/.|+\-_]){8,15}$";

        public const string SymbolsAllowed = "!£$^*<>?/.|+-_";
        public const string UpperCaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public const string LowerCaseChars = "abcdefghijklmnopqrstuvwxyz";
        public const string Numbers = "0123456789";

        public const string UsernameHelp = "You MAY use Upper and Lowercase\nYou MAY use Symbols: " + SymbolsAllowed + "\nYou MAY use numbers\nUsername MUST be at least 8 characters\nUsername MUST be no more than 15 characters";
        public const string PasswordHelp = "You Must use Upper and Lowercase\n You MUST use at least one symbol:\n" + SymbolsAllowed + "\nPassword MUST be at least 8 characters\nPassword MUST include a number";
        public const string EmailHelp = "You may use a outlook, hotmail,\ngmail or exeter college email address";

        public const string GAME_VERSION = "0.0.0";

        public const int OFFLINERATE = 100; // Earned Per Hour

        public const string UT = "USERTABLE";
        public const string GT = "GAMETABLE";
        public const string PT = "PLAYERTABLE";
        public const string HS = "HANDSTATS";
        public const string RS = "RNDSEED";

        public struct UTCols
        {
            public const string UID = "UserID";
            public const string UN = "Username";
            public const string PW = "Password";
            public const string FN = "Fname";
            public const string SN = "Sname";
            public const string EM = "Email";
            public const string GB = "GameBalance";
            public const string LO = "LastOnline";
            public const string A = "Admin";
        }

        public struct GTCols
        {
            public const string GID = "GameID";
            public const string NP = "NoPlayers";
            public const string PIDs = "PlayersIDs";
            public const string DP = "DatePlayed";

        }

        public struct PTCols
        {
            public const string GID = "GameID";
            public const string UID = "UserID";
            public const string PP = "PlayerPosition";
            public const string BC = "BalanceChange";
            public const string HC = "HandCards";
        }

        public struct HSCols
        {
            public const string RF = "RoyalFlush";
            public const string SF = "StraightFlush";
            public const string FK = "FourOfAKind";
            public const string FH = "FullHouse";
            public const string Fl = "Flush";
            public const string St = "Straight";
            public const string TK = "ThreeOfAKind";
            public const string TP = "TwoPair";
            public const string OP = "OnePair";
            public const string HC = "HighCard";
        }

        public struct RSCols
        {
            public const string Se = "Seed";
        }
    }
}
