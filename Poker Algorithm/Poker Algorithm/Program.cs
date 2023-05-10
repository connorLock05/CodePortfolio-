// See https://aka.ms/new-console-template for more information

namespace Poker_Algorithm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card[] cards = new Card[7];

            string num;
            char suit;


            for (int i = 0; i < cards.Length; i++)
            {
                Console.Write("Number: ");
                num = Console.ReadLine();

                Console.Write("Suit: ");
                suit = Convert.ToChar(Console.ReadLine().ToUpper());

                Console.WriteLine();

                cards[i] = new Card(num, suit);
            }

            Table table = new Table();
            Hand hand = table.SevenCardEvaluation(cards);

            foreach(Card card in hand.Cards)
            {
                Console.WriteLine(card.GetCardTextPrettify());
            }
        }
    }
}