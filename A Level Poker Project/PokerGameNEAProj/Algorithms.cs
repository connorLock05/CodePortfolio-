using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    static class Algorithms
    {

        #region Constant Hand Type Labels
        static string RF = "RF";
        static string SF = "SF";
        static string FK = "FK";
        static string FH = "FH";
        static string F = "Fl";
        static string S = "St";
        static string TK = "TK";
        static string TP = "TP";
        static string OP = "OP";
        static string HC = "HC";
        #endregion
        static public Hand SevenCardEval(Card[] cardsAvail)
        {

            // Test Flush True
            Card[] isFlush = testFlush(cardsAvail);

            if (isFlush != null)
            {

                // Possible hands are
                // Royal FLush, Straight Flush, Flush

                // Test for royal flush (Ace High)

                Card[] highLowList = MergeSort(isFlush);
                Card ace, king, queen, jack, ten;
                ace = listContainsCard(highLowList, "A");
                king = listContainsCard(highLowList, "K");
                queen = listContainsCard(highLowList, "Q");
                jack = listContainsCard(highLowList, "J");
                ten = listContainsCard(highLowList, "10");

                Card[] RFrequirements = new Card[] { ace, king, queen, jack, ten };

                if (RFrequirements.All(card => card != null))
                {
                    return new Hand(RFrequirements, RF);
                }

                // Test Straight Flush

                Card[] LowerAceCopy = new Card[highLowList.Length];
                highLowList.CopyTo(LowerAceCopy, 0);

                foreach (Card card in LowerAceCopy)
                {
                    card.LowerAce();
                }
                LowerAceCopy = MergeSort(LowerAceCopy);
                Card[] firstSequence = SubArray(LowerAceCopy, 0, 4);
                Card[] secondSequence = LowerAceCopy.Length >= 6 ? SubArray(LowerAceCopy, 1, 5) : null;
                Card[] thirdSequence = LowerAceCopy.Length == 7 ? SubArray(LowerAceCopy, 2, 6) : null;

                bool firstSequenceStraight = straightEval(firstSequence);
                bool secondSequenceStraight = secondSequence != null ? straightEval(secondSequence) : false;
                bool thirdSequenceStraight = thirdSequence != null ? straightEval(thirdSequence) : false;

                

                if (firstSequenceStraight)
                {
                    return new Hand(firstSequence, SF);
                }
                else if (secondSequenceStraight)
                {
                    return new Hand(secondSequence, SF);
                }
                else if (thirdSequenceStraight)
                {
                    return new Hand(thirdSequence, SF);
                }

                // Flush Remains

                return new Hand(SubArray(highLowList, 0, 4), F);
            }
            else
            {
                // No 5+ of same suit
                // Possible Hands:
                // Four Of A Kind, Full House, Straight, Three Of A Kind, Two Pair, One Pair, High Card

                Card[] sortedCards = MergeSort(cardsAvail);

                Dictionary<int, int> valueCount = new Dictionary<int, int>();

                foreach (Card card in sortedCards)
                {
                    try
                    {
                        valueCount[card.Number]++;
                    }
                    catch
                    {
                        valueCount[card.Number] = 1;
                    }
                }
                List<Card> CardsUsed = new List<Card>();
                // Test Four of a Kind

                int? cardNum = null;
                foreach (KeyValuePair<int, int> kvp in valueCount)
                {
                    if (kvp.Value == 4)
                    {
                        cardNum = kvp.Key;
                    }
                }
                if (cardNum != null)
                {
                    foreach (Card card in sortedCards)
                    {
                        if (card.Number == cardNum)
                        {
                            CardsUsed.Add(card);
                        }
                    }
                    foreach (Card card in sortedCards)
                    {
                        if (CardsUsed.Contains(card))
                        {
                            continue;
                        }
                        else
                        {
                            CardsUsed.Add(card);
                            break;
                        }
                    }

                    return new Hand(CardsUsed.ToArray(), FK);
                }
                CardsUsed.Clear();
                // Test Full House

                List<List<Card>> threeCountLists = new List<List<Card>>();
                List<List<Card>> twoCountLists = new List<List<Card>>();

                List<Card> temp = new List<Card>();
                int numtemp;
                foreach (KeyValuePair<int, int> kvp in valueCount)
                {
                    if (kvp.Value == 3)
                    {
                        numtemp = kvp.Key;
                        foreach (Card card in sortedCards)
                        {
                            if (card.Number == numtemp)
                            {
                                temp.Add(card);
                            }
                        }
                        threeCountLists.Add(temp);
                        temp = new List<Card>();
                    }
                    else if (kvp.Value == 2)
                    {
                        numtemp = kvp.Key;
                        foreach (Card card in sortedCards)
                        {
                            if (card.Number == numtemp)
                            {
                                temp.Add(card);
                            }
                        }
                        twoCountLists.Add(temp);
                        temp = new List<Card>();
                    }
                }
                if (threeCountLists.Count > 0)
                {
                    if (threeCountLists.Count > 1 || twoCountLists.Count > 0)
                    {
                        // Full House Possible
                        if (threeCountLists.Count == 2)
                        {
                            if (threeCountLists[0][0].Number > threeCountLists[1][0].Number)
                            {
                                foreach (Card card in threeCountLists[0])
                                {
                                    CardsUsed.Add(card);
                                }
                                CardsUsed.Add(threeCountLists[1][0]);
                                CardsUsed.Add(threeCountLists[1][1]);

                                return new Hand(CardsUsed.ToArray(), FH);
                            }
                            else
                            {
                                foreach (Card card in threeCountLists[1])
                                {
                                    CardsUsed.Add(card);
                                }
                                CardsUsed.Add(threeCountLists[0][0]);
                                CardsUsed.Add(threeCountLists[0][1]);

                                return new Hand(CardsUsed.ToArray(), FH);
                            }
                        }
                        else
                        {

                            foreach (Card card in threeCountLists[0])
                            {
                                CardsUsed.Add(card);
                            }
                            if (twoCountLists.Count == 2)
                            {
                                if (twoCountLists[0][0].Number > twoCountLists[1][0].Number)
                                {
                                    foreach (Card card in twoCountLists[0])
                                    {
                                        CardsUsed.Add(card);
                                    }
                                    return new Hand(CardsUsed.ToArray(), FH);
                                }
                                else
                                {
                                    foreach (Card card in twoCountLists[1])
                                    {
                                        CardsUsed.Add(card);
                                    }
                                    return new Hand(CardsUsed.ToArray(), FH);
                                }
                            }
                            else
                            {
                                foreach (Card card in twoCountLists[0])
                                {
                                    CardsUsed.Add(card);
                                }
                                return new Hand(CardsUsed.ToArray(), FH);
                            }
                        }
                    }
                }
                // Test Straight
                // Ace can be high or low

                

                Card[] firstSequence = SubArray(sortedCards, 0, 4);
                Card[] secondSequence = SubArray(sortedCards, 1, 5);
                Card[] thirdSequence = SubArray(sortedCards, 2, 6);

                bool firstStraight = straightEval(firstSequence);
                bool secondStraight = straightEval(secondSequence);
                bool thirdStraight = straightEval(thirdSequence);

                if (firstStraight)
                {
                    return new Hand(firstSequence, S);
                }
                else if (secondStraight)
                {
                    return new Hand(secondSequence, S);
                }
                else if (thirdStraight)
                {
                    return new Hand(thirdSequence, S);
                }

                // If nothing for higher value set test ace low set
                Card[] LowerAceCopy = new Card[sortedCards.Length];
                sortedCards.CopyTo(LowerAceCopy, 0);
                foreach(Card c in LowerAceCopy)
                {
                    c.LowerAce();
                }

                firstSequence = SubArray(LowerAceCopy, 0, 4);
                secondSequence = SubArray(LowerAceCopy, 1, 5);
                thirdSequence = SubArray(LowerAceCopy, 2, 6);

                firstStraight = straightEval(firstSequence);
                secondStraight = straightEval(secondSequence);
                thirdStraight = straightEval(thirdSequence);

                if (firstStraight)
                {
                    return new Hand(firstSequence, S);
                }
                else if (secondStraight)
                {
                    return new Hand(secondSequence, S);
                }
                else if (thirdStraight)
                {
                    return new Hand(thirdSequence, S);
                }

                foreach (Card c in sortedCards)
                {
                    c.HigherAce();
                }

                // Test Three of a Kind

                if (threeCountLists.Count > 0)
                {
                    if (threeCountLists.Count == 2)
                    {
                        if (threeCountLists[0][0].Number > threeCountLists[1][0].Number)
                        {
                            foreach (Card card in threeCountLists[0])
                            {
                                CardsUsed.Add(card);
                            }
                        }
                        else
                        {
                            foreach (Card card in threeCountLists[1])
                            {
                                CardsUsed.Add(card);
                            }
                        }
                    }
                    else
                    {
                        foreach (Card card in threeCountLists[0])
                        {
                            CardsUsed.Add(card);
                        }
                    }
                    return new Hand(fillRemainder(CardsUsed, cardsAvail), TK);
                }
                //if (twoCountLists.Count > 1) { twoCountLists = sortCardLists(twoCountLists); }

                // Test Two Pair

                if (twoCountLists.Count >= 2)
                {
                    foreach (Card card in twoCountLists[0])
                    {
                        CardsUsed.Add(card);
                    }
                    foreach (Card card in twoCountLists[1])
                    {
                        CardsUsed.Add(card);
                    }
                    return new Hand(fillRemainder(CardsUsed, cardsAvail), TP);
                }

                // Test One Pair

                if (twoCountLists.Count >= 1)
                {
                    foreach (Card card in twoCountLists[0])
                    {
                        CardsUsed.Add(card);
                    }
                    return new Hand(fillRemainder(CardsUsed, cardsAvail), OP);
                }
                // High Card Return

                return new Hand(fillRemainder(new List<Card>(), cardsAvail), HC);
            }

        }

        static private Card[] fillRemainder(List<Card> CardsUsed, Card[] available)
        {
            Card[] sortedCards = MergeSort(available);
            List<Card> used = CardsUsed;
            while (CardsUsed.Count < 5)
            {
                foreach (Card card in sortedCards)
                {
                    if (used.Contains(card))
                    {
                        continue;
                    }
                    else
                    {
                        used.Add(card);
                        break;
                    }
                }
            }
            return used.ToArray();
        }

        static private bool straightEval(Card[] sequence)
        {
            Card previous = sequence[0];

            for (int i = 1; i < sequence.Length; i++)
            {
                if (sequence[i].Number == previous.Number - 1)
                {
                    previous = sequence[i];
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        static private Card listContainsCard(Card[] cardsList, string letter)
        {
            foreach (Card card in cardsList)
            {
                if (card.Letter == letter)
                {
                    return card;
                }
            }
            return null;
        }
        
        // Suits : ♠ ♣ ♥ ♦

        static private Card[] testFlush(Card[] cardsAvail)
        {
            Dictionary<char, int> suitCount = new Dictionary<char, int>();

            foreach (Card card in cardsAvail)
            {
                try
                {
                    suitCount[card.Suit]++;
                }
                catch
                {
                    suitCount[card.Suit] = 1;
                }
            }
            char? flushSuit = null;
            foreach (KeyValuePair<char, int> kvp in suitCount)
            {
                int count = kvp.Value;
                if (count >= 5)
                {
                    flushSuit = kvp.Key;
                    break;
                }
                else
                {
                    flushSuit = null;
                }
            }
            List<Card> cardsFlush = new List<Card>();
            if (flushSuit != null)
            {
                foreach (Card card in cardsAvail)
                {
                    if (card.Suit == flushSuit)
                    {
                        cardsFlush.Add(card);
                    }
                }
            }
            else
            {
                return null;
            }
            return cardsFlush.ToArray();
        }

        static private Card[] SubArray(Card[] initial, int index1, int index2)
        {
            int length = (index2 - index1) + 1;

            Card[] res = new Card[length];

            for (int i = index1; i <= index2; i++)
            {
                res[i - index1] = initial[i];
            }

            return res;
        }

        
        static public Player[] DetermineWinner(Player[] potentialWinners)
        {
            // All potential winners have the same hand type
            // Use card values to determine winner
            // potentialWinners.Length = 2, 3 or 4
            Player[] winner;
            
            if (potentialWinners.Length == 1)
            {
                return potentialWinners;
            }

            Player compare12 = CompareHands(potentialWinners[0], potentialWinners[1]);
            if (potentialWinners.Length > 2)
            {
                Player compare23 = CompareHands(compare12 == null ? potentialWinners[1] : compare12, potentialWinners[2]);
                if (potentialWinners.Length == 4)
                {
                    Player compare34 = CompareHands(compare23 == null ? potentialWinners[2] : compare23, potentialWinners[3]);
                    if (compare34 == null && compare23 == null && compare12 == null)
                    {
                        return potentialWinners; // 4 Way split
                    }
                    else
                    {
                        if (compare34 == null)
                        {
                            if (compare23 == null)
                            {
                                winner = new Player[] { potentialWinners[3], potentialWinners[2], compare12 };
                            }
                            else
                            {
                                winner = new Player[] { potentialWinners[3], compare23 };
                            }
                        }
                        else
                        {
                            winner = new Player[] { compare34 };
                        }

                        return winner;
                    }
                }
                if (compare12 == null && compare23 == null)
                {
                    return potentialWinners;
                }
                else
                {
                    if (compare23 == null)
                    {
                        winner = new Player[] { potentialWinners[2], compare12 };
                        return winner;
                    }
                    else
                    {
                        return new Player[] { compare23 };
                    }
                }
            }
            if (compare12 == null)
            {
                return potentialWinners;

            }
            else
            {
                winner = new Player[] { compare12 };
                return winner;
            }



            
        }
        

        static public Player CompareHands(Player player1, Player player2)
        {
            if (player1.EndHand.primary > player2.EndHand.primary)
            {
                // Player 1 wins comparision
                return player1;
            }else if (player1.EndHand.primary < player2.EndHand.primary)
            {
                return player2;
            }
            // Primarys equal
            if (player1.EndHand.secondary > player2.EndHand.secondary)
            {
                // Player 1 wins comparision
                return player1;
            }
            else if (player1.EndHand.secondary < player2.EndHand.secondary)
            {
                return player2;
            }
            // Secondaries equal
            if (player1.EndHand.tertiary > player2.EndHand.tertiary)
            {
                // Player 1 wins comparision
                return player1;
            }
            else if (player1.EndHand.tertiary < player2.EndHand.tertiary)
            {
                return player2;
            }
            // Tertiaries Equal
            if (player1.EndHand.quaternary > player2.EndHand.quaternary)
            {
                // Player 1 wins comparision
                return player1;
            }
            else if (player1.EndHand.quaternary < player2.EndHand.quaternary)
            {
                return player2;
            }
            // Quarternaries Equal
            if (player1.EndHand.quiternary > player2.EndHand.quiternary)
            {
                // Player 1 wins comparision
                return player1;
            }
            else if (player1.EndHand.quiternary < player2.EndHand.quiternary)
            {
                return player2;
            }
            // Quinternaries Equal => Tie
            return null;

        }

        // Merge Sort Algorithms
        #region Merge Sort Algorithms
        static public Card[] MergeSort(Card[] cards)
        {
            if (cards.Length == 1)
            {
                return cards;
            }

            Card[] left;
            Card[] right;

            SplitArray(cards, out left, out right);
            left = MergeSort(left);
            right = MergeSort(right);

            return MergeArrays(left, right);
        }

        static private void SplitArray(Card[] cards, out Card[] left, out Card[] right)
        {
            int middle = (cards.Length) / 2;
            left = SpliceArray(cards, 0, middle);
            right = SpliceArray(cards, middle, cards.Length);
        }

        static private Card[] MergeArrays(Card[] left, Card[] right)
        {
            Card[] res = new Card[left.Length + right.Length];

            int ptrLeft = 0;
            int ptrRight = 0;
            int ptrRes = 0;

            while (ptrLeft < left.Length && ptrRight < right.Length)
            {
                if (left[ptrLeft].Number > right[ptrRight].Number)
                {
                    res[ptrRes] = left[ptrLeft];
                    ptrLeft++;
                }
                else
                {
                    res[ptrRes] = right[ptrRight];
                    ptrRight++;
                }

                ptrRes++;
            }

            if (ptrLeft == left.Length)
            {
                for (int i=ptrRight; i<right.Length; i++)
                {
                    res[ptrRes++] = right[i];

                }
            }
            else
            {
                for (int i = ptrLeft; i < left.Length; i++)
                {
                    res[ptrRes++] = left[i];

                }
            }

            return res;
        }

        static private Card[] SpliceArray(Card[] cards, int start, int end)
        {
            Card[] res = new Card[end - start];

            for(int i=start; i<end; i++)
            {
                res[i-start] = cards[i];
            }

            return res;
        }

        #endregion
    }
}


