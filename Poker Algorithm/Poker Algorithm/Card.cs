using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Algorithm
{

    // Suit Icons : ♠ ♣ ♥ ♦

    internal class Card
    {
        private string faceValueLetter;
        private string faceValue;
        private char suitLetter;
        private char suitIcon;

        public string FaceValueLetter
        {
            get { return faceValueLetter; }
            set { faceValueLetter = value; } 
        }

        public string FaceValue
        {
            get { return faceValue; }
            set { faceValue = value; }
        }

        public char SuitLetter
        {
            get { return suitLetter; }
            set { suitLetter = value; }
        }

        public Card(string faceValueNum, char suit)
        {
            this.faceValue = faceValueNum;
            this.suitLetter = suit;

            switch (faceValueNum)
            {
                case "1":
                    this.faceValueLetter = "A";
                    break;
                case "11":
                    this.faceValueLetter = "J";
                    break;
                case "12":
                    this.faceValueLetter = "Q";
                    break;
                case "13":
                    this.faceValueLetter = "K";
                    break;
                default:
                    this.faceValueLetter = faceValueNum;
                    break;
            }

            switch (suit)
            {
                case 'C':
                    this.suitIcon = '♣';
                    break;
                case 'H':
                    this.suitIcon = '♥';
                    break;
                case 'D':
                    this.suitIcon = '♦';
                    break;
                case 'S':
                    this.suitIcon = '♠';
                    break;
                default:
                    this.suitIcon = '?';
                    break;
            }

            if (this.faceValue == "1")
            {
                faceValue = "14";
            }
        }

        public string GetCardTextNum()
        {
            return faceValue + " " + suitIcon;
        }

        public string GetCardTextPrettify()
        {
            return faceValueLetter + " " + suitIcon;
        }

        // Operator Overrides

        public static bool operator>(Card first, Card second)
        {
            int firstNum = Convert.ToInt32(first.faceValue);
            int secondNum = Convert.ToInt32(second.faceValue);

            return firstNum > secondNum;
        }
        public static bool operator <(Card first, Card second)
        {
            int firstNum = Convert.ToInt32(first.faceValue);
            int secondNum = Convert.ToInt32(second.faceValue);

            return firstNum < secondNum;
        }
    }
}
