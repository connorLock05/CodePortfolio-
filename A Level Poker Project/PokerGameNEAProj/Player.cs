using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
namespace PokerGameNEAProj
{
    internal class Player
    {
        Hand endHand;
        int uID;
        int tablePos;
        Card[] pocketCards;
        int balance;
        Socket sock;
        string endIP;

        string username;
        public Hand EndHand { get { return endHand; } set { endHand = value; } }
        public int UID { get { return uID; } }
        public int TablePos { get { return tablePos; } }
        public Card[] PocketCards { get { return pocketCards; } }
        public string Username { get { return username; } }
        public int Balance { get { return balance; } }
        public Socket Sock { get { return sock; } }
        public string EndIP { get { return endIP; } }

        public Player(int UID, int tablePos, string Username, int bal, Socket sock, string endIP)
        {
            this.uID = UID;
            this.tablePos = tablePos;
            pocketCards = new Card[2];
            username = Username;
            balance = bal;
            this.sock = sock;
            this.endIP = endIP;
        }

        public void SetTablePos(int pos)
        {
            tablePos = pos;
        }

        public void SetPocketCards(Card card, int pos)
        {
            pocketCards[pos] = card;
        }
        
    }
}
