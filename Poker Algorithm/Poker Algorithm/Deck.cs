using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Algorithm
{
    internal class Deck
    {
        private Card?[] cardDeck;
        Random rnd;

        public Deck()
        {
            rnd = new Random();
            cardDeck = new Card[52];

            char tempSuit = 'C';

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        tempSuit = 'C';
                        break;
                    case 1:
                        tempSuit = 'H';
                        break;
                    case 2:
                        tempSuit = 'D';
                        break;
                    case 3:
                        tempSuit = 'S';
                        break;
                }

                for (int j = 0; j < 13; j++)
                {
                    cardDeck[j + (i * 13)] = new Card(Convert.ToString(j + 1), tempSuit);
                }
            }

            Shuffle();
        }

        public void Shuffle()
        {
            for (int i = 0; i < cardDeck.Length; i++)
            {
                int index = rnd.Next(0, 52);
                Card? tempCard = cardDeck[index];
                cardDeck[index] = cardDeck[i];
                cardDeck[i] = tempCard;
            }
        }

        public Card? popCard()
        {
            for(int i=0; i < cardDeck.Length; i++)
            {
                Card? card = cardDeck[i];
                if (card == null) continue;

                cardDeck[i] = null;
                return card;
            }
            return null;
        }

        public Card?[] GetDeck()
        {
            return cardDeck;
        }
    }
}
