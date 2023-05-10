using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Algorithm
{
    internal class Table
    {
        private Card[] communityCards;
        private Card[] discard;
        private Deck deck;
        private Algorithms algo;
        private Player[] players;

        public Table()
        {
            communityCards = new Card[5];
            discard = new Card[3];
            deck = new Deck();
            algo = new Algorithms();
        }

        /*
         * Poker Hand Heirarchy :
         * Royal Flush - (A, K, Q, J, 10 of same suit)
         * Straight Flush - (Run of 5 cards all of same suit )
         * 
         * Ace is High OR Low on straight and only low on straight Flush. It is high everywhere else
         * 
         * Four of a Kind - (4 of same face value card + 1 other card)
         * Full House - (3 of same face value card + 2 of other face value card)
         * Flush - (5 cards of same suit)
         * Straight - (Run of 5 cards)
         * Three of a Kind - (3 of same face value cards + 2 other cards)
         * Two Pair - (2 of the same face value card + 2 of other face value card + 1 other card)
         * One Pair - (2 of the same face value card + 3 other cards)
         * High Card - Anything else
         */
        
        public Hand SevenCardEvaluation(Card[] cardsAvailable)
        {
            Card[] cardsUsed = new Card[5];
            List<Card> cardsUsedList = new List<Card>();

            Card[] tempArrayCards;

            int noClubs = 0;
            int noHearts = 0;
            int noDiamonds = 0;
            int noSpades = 0;

            List<Card> clubs = new List<Card>();
            List<Card> hearts = new List<Card>();
            List<Card> diamonds = new List<Card>();
            List<Card> spades = new List<Card>();

            foreach(Card card in cardsAvailable)
            {
                char suit = card.SuitLetter;

                switch (suit)
                {
                    case 'C':
                        noClubs++;
                        clubs.Add(card);
                        break;
                    case 'H':
                        noHearts++;
                        hearts.Add(card);
                        break;
                    case 'D':
                        noDiamonds++;
                        diamonds.Add(card);
                        break;
                    case 'S':
                        noSpades++;
                        spades.Add(card);
                        break;
                }
            }

            if (noClubs >= 5 || noHearts >= 5 || noDiamonds >= 5 || noSpades >= 5)
            {
                // At least A flush (Cant be full house or four of a kind)
                
                // Find Common Suit
                if (noClubs >= 5)
                {
                    
                    // Test Royal Flush
                    bool ace = false;
                    bool king = false;
                    bool queen = false;
                    bool jack = false;
                    bool ten = false;

                    foreach (Card card in clubs)
                    {
                        string value = card.FaceValueLetter;
                        switch (value)
                        {
                            case "A":
                                ace = true;
                                cardsUsedList.Add(card);
                                break;
                            case "K":
                                king = true;
                                cardsUsedList.Add(card);
                                break;
                            case "Q":
                                queen = true;
                                cardsUsedList.Add(card);
                                break;
                            case "J":
                                jack = true;
                                cardsUsedList.Add(card);
                                break;
                            case "10":
                                ten = true;
                                cardsUsedList.Add(card);
                                break;
                        }
                    }

                    if (ace && king && queen && jack && ten)
                    {
                        Console.WriteLine("Royal Flush Verified");
                        return new Hand(cardsUsedList.ToArray(), "Royal Flush");
                    }
                    // Here - Not Riyal flush in clubs
                    // Test Straight flush
                    cardsUsed = new Card[5];

                    

                    Card?[] straightFlushTest = algo.straightFlushEval(clubs);

                    if (straightFlushTest[0] != null)
                    {
                        
                        cardsUsed = straightFlushTest;

                        return new Hand(cardsUsed, "Straight Flush");
                    }

                    // Cant be Four of A Kind due to majority same suit
                    // Cannot be Full House due to majority same suit
                    // Has to be flush 
                    tempArrayCards = algo.BubbleSort(clubs.ToArray(), true);
                    // Sorted high to low
                    // Use first 5 cards
                    return new Hand(tempArrayCards[0..5], "Flush");
                    
                }
                else if (noHearts >= 5)
                {

                    cardsUsed = new Card[5];
                    cardsUsedList = new List<Card>();

                    // Test Royal Flush
                    bool ace = false;
                    bool king = false;
                    bool queen = false;
                    bool jack = false;
                    bool ten = false;

                    foreach (Card card in hearts)
                    {
                        string value = card.FaceValueLetter;
                        switch (value)
                        {
                            case "A":
                                ace = true;
                                cardsUsedList.Add(card);
                                break;
                            case "K":
                                king = true;
                                cardsUsedList.Add(card);
                                break;
                            case "Q":
                                queen = true;
                                cardsUsedList.Add(card);
                                break;
                            case "J":
                                jack = true;
                                cardsUsedList.Add(card);
                                break;
                            case "10":
                                ten = true;
                                cardsUsedList.Add(card);
                                break;
                        }
                    }

                    if (ace && king && queen && jack && ten)
                    {
                        return new Hand(cardsUsedList.ToArray(), "Royal Flush");
                    }
                    // Here - Not Riyal flush in clubs
                    // Test Straight flush
                    



                    Card?[] straightFlushTest = algo.straightFlushEval(hearts);

                    if (straightFlushTest[0] != null)
                    {

                        cardsUsed = straightFlushTest;

                        return new Hand(cardsUsed, "Straight Flush");
                    }

                    // Cant be Four of A Kind due to majority same suit
                    // Cannot be Full House due to majority same suit
                    // Has to be flush 
                    tempArrayCards = algo.BubbleSort(hearts.ToArray(), true);
                    // Sorted high to low
                    // Use first 5 cards
                    return new Hand(tempArrayCards[0..5], "Flush");

                }
                else if (noDiamonds >= 5)
                {

                    cardsUsed = new Card[5];
                    cardsUsedList = new List<Card>();

                    // Test Royal Flush
                    bool ace = false;
                    bool king = false;
                    bool queen = false;
                    bool jack = false;
                    bool ten = false;

                    foreach (Card card in diamonds)
                    {
                        string value = card.FaceValueLetter;
                        switch (value)
                        {
                            case "A":
                                ace = true;
                                cardsUsedList.Add(card);
                                break;
                            case "K":
                                king = true;
                                cardsUsedList.Add(card);
                                break;
                            case "Q":
                                queen = true;
                                cardsUsedList.Add(card);
                                break;
                            case "J":
                                jack = true;
                                cardsUsedList.Add(card);
                                break;
                            case "10":
                                ten = true;
                                cardsUsedList.Add(card);
                                break;
                        }
                    }

                    if (ace && king && queen && jack && ten)
                    {
                        return new Hand(cardsUsedList.ToArray(), "Royal Flush");
                    }
                    // Here - Not Riyal flush in clubs
                    // Test Straight flush




                    Card?[] straightFlushTest = algo.straightFlushEval(diamonds);

                    if (straightFlushTest[0] != null)
                    {

                        cardsUsed = straightFlushTest;

                        return new Hand(cardsUsed, "Straight Flush");
                    }

                    // Cant be Four of A Kind due to majority same suit
                    // Cannot be Full House due to majority same suit
                    // Has to be flush 
                    tempArrayCards = algo.BubbleSort(diamonds.ToArray(), true);
                    // Sorted high to low
                    // Use first 5 cards
                    return new Hand(tempArrayCards[0..5], "Flush");

                }
                else if (noSpades >= 5)
                {

                    cardsUsed = new Card[5];
                    cardsUsedList = new List<Card>();

                    // Test Royal Flush
                    bool ace = false;
                    bool king = false;
                    bool queen = false;
                    bool jack = false;
                    bool ten = false;

                    foreach (Card card in spades)
                    {
                        string value = card.FaceValueLetter;
                        switch (value)
                        {
                            case "A":
                                ace = true;
                                cardsUsedList.Add(card);
                                break;
                            case "K":
                                king = true;
                                cardsUsedList.Add(card);
                                break;
                            case "Q":
                                queen = true;
                                cardsUsedList.Add(card);
                                break;
                            case "J":
                                jack = true;
                                cardsUsedList.Add(card);
                                break;
                            case "10":
                                ten = true;
                                cardsUsedList.Add(card);
                                break;
                        }
                    }

                    if (ace && king && queen && jack && ten)
                    {
                        return new Hand(cardsUsedList.ToArray(), "Royal Flush");
                    }
                    // Here - Not Riyal flush in clubs
                    // Test Straight flush




                    Card?[] straightFlushTest = algo.straightFlushEval(spades);

                    if (straightFlushTest[0] != null)
                    {

                        cardsUsed = straightFlushTest;

                        return new Hand(cardsUsed, "Straight Flush");
                    }

                    // Cant be Four of A Kind due to majority same suit
                    // Cannot be Full House due to majority same suit
                    // Has to be flush 
                    tempArrayCards = algo.BubbleSort(spades.ToArray(), true);
                    // Sorted high to low
                    // Use first 5 cards
                    return new Hand(tempArrayCards[0..5], "Flush");

                }
            } else
            {
                // Not at least 5 of one suit
                /* Order of testing
                 * Four of a Kind
                 * Full House
                 * Straight
                 * Three of a Kind
                 * Two Pair
                 * One Pair
                 * High Card
                 */
                Dictionary<string, int> valueCount = new Dictionary<string, int>();

                foreach(Card card in cardsAvailable)
                {
                    try
                    {
                        valueCount[card.FaceValue]++;
                    } catch (Exception e)
                    {
                        valueCount.Add(card.FaceValue, 1);
                    }
                }

                List<CardCollection?> cardGroups = new List<CardCollection?>();
                
                
                foreach(KeyValuePair<string, int> kvp in valueCount)
                {
                    cardGroups.Add(new CardCollection(algo.cnvt(kvp.Key), kvp.Value));
                }
                foreach(CardCollection? cardCollection in cardGroups)
                {
                    foreach(Card card in cardsAvailable)
                    {
                        if (algo.cnvt(card.FaceValue) == cardCollection.Value)
                        {
                            cardCollection.Add(card);
                        }
                    }
                }
                CardCollection? [] cardCollections = cardGroups.ToArray();

                cardCollections = algo.BubbleSort(cardCollections, true);

                List<CardCollection> fours = new List<CardCollection>();
                List<CardCollection> threes = new List<CardCollection>();
                List<CardCollection> twos = new List<CardCollection>();

                // Test Four of a Kind
                foreach (CardCollection cardCollection in cardCollections)
                {
                    if(cardCollection.Count == 4)
                    {
                        fours.Add(cardCollection);                        
                    } else if (cardCollection.Count == 3)
                    {
                        threes.Add(cardCollection);
                    }
                    else if (cardCollection.Count == 2)
                    {
                        twos.Add(cardCollection);
                    }
                }
            }

            return new Hand(cardsAvailable[0..5], "High Card");
        }
        
    }
}
