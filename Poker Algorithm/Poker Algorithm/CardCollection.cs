using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Algorithm
{
    internal class CardCollection
    {
        private List<Card> cards;
        private int value;
        private int count;
        private Algorithms algo;

        public List<Card> Cards
        {
            get { return cards; }
        }

        public int Value
        {
            get { return value; }
        }

        public int Count
        {
            get { return count; }
        }
        public CardCollection(int value, int count)
        {
            this.value = value;
            this.count = count;
            cards = new List<Card>();
            algo = new Algorithms();
        }

        public void Add(Card card)
        {
            if (Convert.ToInt32(card.FaceValue) == value)
            {
                cards.Add(card);
            }
            else
            {
                throw new InvalidCardValueException();
            }
        }

        static public bool operator >(CardCollection first, CardCollection second)
        {
            return first.Value > second.Value;
        }

        static public bool operator <(CardCollection first, CardCollection second)
        {
            return first.Value < second.Value;
        }
    }
}
