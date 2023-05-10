using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Algorithm
{
    internal class Hand
    {
        private Card[] cards;
        private Algorithms algo;

        private string handType;

        private int primaryValue;
        private int secondaryValue;

        public Card[] Cards
        {
            get { return cards; }
        }
        public int PrimaryValue
        {
            get { return primaryValue; }
            set { primaryValue = value; }
        }

        public int SecondaryValue
        {
            set { secondaryValue = value; }
            get { return secondaryValue; }
        }

        public Hand(Card[] cardsUsed, string hand)
        {
            cards = cardsUsed;
            handType = hand;
            algo = new Algorithms();

            int tempValue;
            int[] tempListOne;
            int[] tempListTwo;

            switch (hand)
            {
                case "Straight Flush":
                    tempValue = algo.cnvt(cards[0].FaceValue);
                    foreach (Card card in cards)
                    {
                        if (algo.cnvt(card.FaceValue) > tempValue)
                        {
                            tempValue = algo.cnvt(card.FaceValue);
                        }
                    }

                    primaryValue = tempValue;
                    break;
                case "Four of a Kind":
                    tempListOne = new int[4];
                    tempListTwo = new int[1];

                    for (int i = 0; i < cards.Length; i++)
                    {
                        if (i == 0)
                        {
                            tempListTwo[i] = algo.cnvt(cards[i].FaceValue);
                            continue;
                        }
                        tempListOne[i-1] = algo.cnvt(cards[i].FaceValue);
                    }

                    if (tempListOne.Contains(tempListTwo[0])){
                        primaryValue = tempListTwo[0];
                    } else
                    {
                        primaryValue = tempListOne[0];
                    }
                    break;
                /*case "Full House":
                    tempListOne = new int[3];
                    tempListTwo = new int[2];

                    int num;

                    foreach(Card card in cards)
                    {
                        num = algo.cnvt(card.FaceValue);
                        if (Array.IndexOf(cards, card) == 0)
                        {
                            tempListOne
                        }
                    }*/
            }
        }

    }
}
