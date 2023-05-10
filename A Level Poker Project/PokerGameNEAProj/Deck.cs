using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    public class Deck
    {
        Card[] deck;
        int IndexPointer;

        public Deck()
        {
            deck = new Card[52];

            for (int i = 0; i<4; i++)
            {
                char suit = 'a';
                /*
                 * Clubs : ♣
                 * Hearts : ♥
                 * Spades : ♠
                 * Diamonds : ♦
                 */

                switch (i)
                {
                    case 0:
                        suit = '♣';
                        break;
                    case 1:
                        suit = '♥';
                        break;
                    case 2:
                        suit = '♠';
                        break;
                    case 3:
                        suit = '♦';
                        break;
                }
                for (int j = 1; j < 14; j++)
                {
                    // Index = (13 * i) + (j-1))

                    int index = (13 * i) + (j - 1);

                    deck[index] = new Card(j, suit);
                }
            }

            Shuffle();
        }

        private void Shuffle()
        {
            Random rnd = new Random();
            int newIndex;

            for (int i=0; i<52; i++)
            {
                newIndex = rnd.Next(0, 52);
                Card temp = deck[newIndex];
                deck[newIndex] = deck[i];
                deck[i] = temp;
            }
        }

        public Card PopCard()
        {
            for (int i=0; i<52; i++)
            {
                if (deck[i] == null)
                {
                    continue;
                }
                else
                {
                    Card card = deck[i];
                    deck[i] = null;
                    return card;
                }
            }

            return null;
        }
    }
}
