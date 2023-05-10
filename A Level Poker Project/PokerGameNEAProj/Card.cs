using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PokerGameNEAProj
{

    public class Card
    {


        int CardNumber;
        char CardSuit;
        string CardLetter;

        public int Number { get { return CardNumber; } }
        public char Suit { get { return CardSuit; } }
        public string Letter { get { return CardLetter; } }

        public Card(int number, char suit)
        {
            CardNumber = number;
            CardSuit = suit;

            if (!(CardNumber == 1 || CardNumber == 11 || CardNumber == 12 || CardNumber == 13 || CardNumber == 14))
            {
                CardLetter = CardNumber.ToString();
            }
            else
            {
                switch (CardNumber)
                {
                    case 1: CardLetter = "A"; CardNumber = 14; break;
                    case 11: CardLetter = "J"; break;
                    case 12: CardLetter = "Q"; break;
                    case 13: CardLetter = "K"; break;
                    case 14: CardLetter = "A"; break;
                }
            }
        }

        public static Card GetCardFromLabel(Label lbl)
        {
            // Form is : Number\nSuit
            string[] split = lbl.Text.Split('\n');
            int number = int.Parse(split[0]);
            char suit = split[1].ToCharArray()[0];

            return new Card(number, suit);
        }

        delegate void SetLabelCallback(ref Label lbl);
        public void SetLabel(ref Label lbl)
        {
            if (lbl.InvokeRequired)
            {
                SetLabelCallback d = new SetLabelCallback(SetLabel);
                lbl.Invoke(d, new object[] { lbl });
            }
            else
            {
                //lbl.AutoSize = false;
                //lbl.ClientSize = new System.Drawing.Size(27, 40);
                if (Suit == '♦' || Suit == '♥')
                {
                    lbl.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lbl.ForeColor = System.Drawing.Color.Black;
                }
                lbl.Text = $"{CardLetter}\n{Suit}";

                lbl.Image = null;
            }
        }

        public void LowerAce()
        {
            if (CardLetter == "A")
            {
                CardNumber = 1;
            }
        }

        public void HigherAce()
        {
            if (CardLetter == "A")
            {
                CardNumber = 14;
            }
        }

        public string CardToString()
        {
            return $"{CardLetter} {Suit}";
        }

        // Suits : ♠ ♣ ♥ ♦

        public string CardToDB()
        {
            string res = "";

            if (Number == 10) { res += "T"; }
            else { res += Letter; }

            switch (Suit)
            {
                case '♣':
                    res += 1.ToString();
                    break;
                case '♥':
                    res += 2.ToString();
                    break;
                case '♠':
                    res += 3.ToString();
                    break;
                case '♦':
                    res += 4.ToString();
                    break;
                
            }

            return res;
        }

        

    }
}
