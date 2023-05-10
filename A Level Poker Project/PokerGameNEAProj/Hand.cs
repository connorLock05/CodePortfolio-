using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    internal class Hand
    {
        Card[] cards;
        int ranking; // High to Low for Royal Flush to High Card   (1 - 10)

        public Card[] Cards { get { return cards; } }
        public int Ranking { get { return ranking; } }

        public int primary, secondary, tertiary, quaternary, quiternary;
        public Hand(Card[] cards, string handAbbrev)
        {
            this.cards = cards;

            switch (handAbbrev)
            {
                case "RF":
                    this.ranking = 10;
                    break;
                case "SF":
                    this.ranking = 9;
                    break;
                case "FK":
                    this.ranking = 8;
                    break;
                case "FH":
                    this.ranking = 7;
                    break;
                case "Fl":
                    this.ranking = 6;
                    break;
                case "St":
                    this.ranking = 5;
                    break;
                case "TK":
                    this.ranking = 4;
                    break;
                case "TP":
                    this.ranking = 3;
                    break;
                case "OP":
                    this.ranking = 2;
                    break;
                case "HC":
                    this.ranking = 1;
                    break;
            }

            primary = cards[0].Number;
            secondary = cards[1].Number;
            tertiary = cards[2].Number;
            quaternary = cards[3].Number;
            quiternary = cards[4].Number;
        }
    }
}
