using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Algorithm
{
    internal class Algorithms
    {

        public int cnvt(string num)
        {
            return Convert.ToInt32(num);
        }

        
        public bool Sorted(Card[] cardsAvailable, bool highLow = false)
        {
            Card previous = cardsAvailable[0];

            for (int i = 1; i < cardsAvailable.Length; i++)
            {
                if (highLow)
                {
                    if (cardsAvailable[i] > previous)
                    {
                        return false;
                    }

                }
                else
                {
                    if (cardsAvailable[i] < previous)
                    {
                        return false;
                    }
                }
                previous = cardsAvailable[i];
            }

            return true;
        }

        public bool Sorted(CardCollection?[] cardCollections, bool highLow = false)
        {
            CardCollection? previous = cardCollections[0];

            for (int i = 1; i < cardCollections.Length; i++)
            {
                if (highLow)
                {
                    if (cardCollections[i] > previous)
                    {
                        return false;
                    }
                } else
                {
                    if (cardCollections[i] < previous)
                    {
                        return false;
                    }
                }
                previous = cardCollections[i];
            }
            return true;
        }

        public Card?[] straightFlushEval(List<Card> available)
        {
            Card?[] cardsUsed = new Card[5];

            Card[] cardsAvailable = available.ToArray();

            for(int i = 0; i < cardsAvailable.Length; i++)
            {
                if (cardsAvailable[i].FaceValueLetter == "A")
                {
                    cardsAvailable[i].FaceValue = "1";
                }
            }

            cardsAvailable = BubbleSort(cardsAvailable);

            if (cnvt(cardsAvailable[2].FaceValue) - cnvt(cardsAvailable[3].FaceValue) != -1)
            {
                
                return new Card?[] { null };
            }
            else
            {
                Card[] firstSequence = new Card[5];
                Card[] secondSequence = new Card[5];
                Card[] thirdSequence = new Card[5];
                

                if (cardsAvailable.Length == 7)
                {
                    // Seven cards given => 3 possible hands once ordered
                    

                    firstSequence = cardsAvailable[0..5];
                    secondSequence = cardsAvailable[1..6];
                    thirdSequence = cardsAvailable[2..7];

                    int previous = cnvt(firstSequence[0].FaceValue);

                    int checks = 0;

                    for (int i = 1; i < firstSequence.Length; i++)
                    {
                        if (cnvt(firstSequence[i].FaceValue) - previous == 1)
                        {
                            previous = cnvt(firstSequence[i].FaceValue);
                            checks++;
                        }
                        else
                        {
                            break;
                        }
                        
                        if (checks == 4)
                        {
                            
                            cardsUsed = firstSequence;
                            return cardsUsed;
                        }
                    }

                    previous = cnvt(secondSequence[0].FaceValue);

                    checks = 0;

                    for (int i = 1; i < secondSequence.Length; i++)
                    {
                        if (cnvt(secondSequence[i].FaceValue) - previous == 1)
                        {
                            previous = cnvt(secondSequence[i].FaceValue);
                            checks++;
                        }
                        else
                        {
                            break;
                        }
                        if (checks == 4)
                        {
                            
                            cardsUsed = secondSequence;
                            return cardsUsed;
                        }
                    }

                    previous = cnvt(thirdSequence[0].FaceValue);

                    checks = 0;

                    for (int i = 1; i < thirdSequence.Length; i++)
                    {
                        if (cnvt(thirdSequence[i].FaceValue) - previous == 1)
                        {
                            previous = cnvt(thirdSequence[i].FaceValue);
                            checks++;
                        }
                        else
                        {
                            break;
                        }
                        if (checks == 4)
                        {
                            
                            cardsUsed = thirdSequence;
                            return cardsUsed;
                        }
                    }

                    
                    return new Card?[] { null };

                } else if (cardsAvailable.Length == 6) {
                    // Six Cards Given => 2 possible hands once ordered

                    firstSequence = cardsAvailable[0..5];
                    secondSequence = cardsAvailable[1..6];

                    int previous = cnvt(firstSequence[0].FaceValue);

                    int checks = 0;

                    for (int i = 1; i < firstSequence.Length; i++)
                    {
                        if (cnvt(firstSequence[i].FaceValue) - previous == 1)
                        {
                            previous = cnvt(firstSequence[i].FaceValue);
                            checks++;
                        }
                        else
                        {
                            break;
                        }
                        if (checks == 4)
                        {
                            cardsUsed = firstSequence;
                            return cardsUsed;
                        }
                    }

                    previous = cnvt(secondSequence[0].FaceValue);

                    checks = 0;

                    for (int i = 1; i < secondSequence.Length; i++)
                    {
                        if (cnvt(secondSequence[i].FaceValue) - previous == 1)
                        {
                            previous = cnvt(secondSequence[i].FaceValue);
                            checks++;
                        }
                        else
                        {
                            break;
                        }
                        if (checks == 4)
                        {
                            cardsUsed = secondSequence;
                            return cardsUsed;
                        }
                    }

                    return new Card?[] { null };

                } else if (cardsAvailable.Length == 5)
                {
                    // Five Cards Given => One possible hand once ordered

                    firstSequence = cardsAvailable[0..5];

                    int previous = cnvt(firstSequence[0].FaceValue);

                    int checks = 0;

                    for (int i = 1; i < firstSequence.Length; i++)
                    {
                        if (cnvt(firstSequence[i].FaceValue) - previous == 1)
                        {
                            previous = cnvt(firstSequence[i].FaceValue);
                            checks++;
                        }
                        else
                        {
                            break;
                        }
                        if (checks == 4)
                        {
                            cardsUsed = firstSequence;
                            return cardsUsed;
                        }
                    }

                    return new Card?[] { null };
                }

                return new Card?[] { null };
            }

        }


        public Card?[] straightEval(Array[] cardsAvailableArray)
        {
            Card?[] cardsUsed;

            foreach(Card[] cardsAvailable in cardsAvailableArray)
            {
                int previous = cnvt(cardsAvailable[0].FaceValue);

                int checks = 0;

                Card[] firstSequence;
                Card[] secondSequence;
                Card[] thirdSequence;

                firstSequence = cardsAvailable[0..4];
                secondSequence = cardsAvailable[1..5];
                thirdSequence = cardsAvailable[2..6];

                previous = cnvt(firstSequence[0].FaceValue);
                checks = 0;

                for (int i = 1; i < firstSequence.Length; i++)
                {
                    if (cnvt(firstSequence[i].FaceValue) - previous == 1)
                    {
                        previous = cnvt(firstSequence[i].FaceValue);
                        checks++;
                    }
                    else
                    {
                        break;
                    }
                    if (checks == 5)
                    {
                        cardsUsed = firstSequence;
                        return cardsUsed;
                    }
                }

                previous = cnvt(secondSequence[0].FaceValue);

                checks = 0;

                for (int i = 1; i < secondSequence.Length; i++)
                {
                    if (cnvt(secondSequence[i].FaceValue) - previous == 1)
                    {
                        previous = cnvt(secondSequence[i].FaceValue);
                        checks++;
                    }
                    else
                    {
                        break;
                    }
                    if (checks == 5)
                    {
                        cardsUsed = secondSequence;
                        return cardsUsed;
                    }
                }

                previous = cnvt(thirdSequence[0].FaceValue);

                checks = 0;

                for (int i = 1; i < thirdSequence.Length; i++)
                {
                    if (cnvt(thirdSequence[i].FaceValue) - previous == 1)
                    {
                        previous = cnvt(thirdSequence[i].FaceValue);
                        checks++;
                    }
                    else
                    {
                        break;
                    }
                    if (checks == 5)
                    {
                        cardsUsed = thirdSequence;
                        return cardsUsed;
                    }
                }

                
            }
            return new Card?[] { null };
        }
        
        public Card[] BubbleSort(Card[] cardsAvailable, bool highLow = false)
        {
            Card previous;

            while (!Sorted(cardsAvailable, highLow))
            {
                previous = cardsAvailable[0];

                for (int i = 1; i < cardsAvailable.Length; i++)
                {
                    if (highLow)
                    {
                        if (cardsAvailable[i] > previous)
                        {
                            Card temp = cardsAvailable[i];
                            cardsAvailable[i] = previous;
                            cardsAvailable[i-1] = temp;
                        }

                    }
                    else
                    {
                        if (cardsAvailable[i] < previous)
                        {
                            Card temp = cardsAvailable[i];
                            cardsAvailable[i] = previous;
                            cardsAvailable[i - 1] = temp;
                        }
                    }
                    previous = cardsAvailable[i];
                }

            }
            return cardsAvailable;
        }

        public CardCollection?[] BubbleSort(CardCollection?[] cardCollections, bool highLow = false)
        {
            CardCollection? previous;

            while (!Sorted(cardCollections, highLow)){
                previous = cardCollections[0];

                for (int i = 1; i < cardCollections.Length; i++)
                {
                    if (highLow)
                    {
                        if (cardCollections[i] > previous)
                        {
                            CardCollection? temp = cardCollections[i];
                            cardCollections[i] = previous;
                            cardCollections[i - 1] = temp;
                        }
                    } else
                    {
                        if (cardCollections[i] < previous)
                        {
                            CardCollection? temp = cardCollections[i];
                            cardCollections[i] = previous;
                            cardCollections[i - 1] = temp;
                        }
                    }
                    previous = cardCollections[i];
                }
            }
            return cardCollections;
        }
        
    }
}
