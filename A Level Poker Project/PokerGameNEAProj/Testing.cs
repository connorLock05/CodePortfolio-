using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGameNEAProj
{
    public partial class Testing : Form
    {

        Deck deck;
        Card[] sevenCard;
        Random rnd;

        public Testing()
        {
            InitializeComponent();
            rnd = new Random();
        }

        public string GenerateArrayToText(Card[] array)
        {
            string res = "";

            for(int i=0; i<array.Length - 1; i++)
            {
                res += array[i].CardToString() + ", ";
            }

            res += array.Last().CardToString();


            return res += Environment.NewLine;
        }

        

        private void RunTest(object sender, EventArgs e)
        {
            
            textBox1.Text = "";

            this.deck = new Deck();

            sevenCard = new Card[] { deck.PopCard(), deck.PopCard(), deck.PopCard(), deck.PopCard(), deck.PopCard(), deck.PopCard(), deck.PopCard() };

            // Show Deck shuffle works
            // If cards are not in order of same suit => works
            // Also shows functionality of deck.PopCard() and Card.CardToString()

            textBox1.Text += "Generated Cards : " + GenerateArrayToText(sevenCard);

            // Show Merge Sort Functionality
            // Sorts high to low (ace high)

            sevenCard = Algorithms.MergeSort(sevenCard);
            textBox1.Text += "Merge Sorted : " + GenerateArrayToText(sevenCard);

            // Show Hand Evaluator Works
            Hand hand = Algorithms.SevenCardEval(sevenCard);

                

            textBox1.Text += "Selected Cards : " + GenerateArrayToText(hand.Cards);
            textBox1.Text += "Hand Type : " + hand.Ranking.ToString() + ConvertRankingToText(hand.Ranking) + Environment.NewLine;
            textBox1.Text += $"Order of cards : {hand.primary} {hand.secondary} {hand.tertiary} {hand.quaternary} {hand.quiternary}" + Environment.NewLine;
            
			
            
        }

        private void DisplayResultsEvaluator(Card[] sevenCard, string handName)
        {
            
            textBox1.Text += $"========== {handName} ==========" + Environment.NewLine;

            textBox1.Text += "Generated Cards : " + GenerateArrayToText(sevenCard);

            sevenCard = Algorithms.MergeSort(sevenCard);
            textBox1.Text += "Merge Sorted : " + GenerateArrayToText(sevenCard);

            Hand hand = Algorithms.SevenCardEval(sevenCard);

            textBox1.Text += "Selected Cards : " + GenerateArrayToText(hand.Cards);
            textBox1.Text += "Hand Type : " + hand.Ranking.ToString() + ConvertRankingToText(hand.Ranking) + Environment.NewLine;
            textBox1.Text += $"Order of cards : {hand.primary} {hand.secondary} {hand.tertiary} {hand.quaternary} {hand.quiternary}" + Environment.NewLine + Environment.NewLine;
        }

        private void DisplayResultsPlayer(Player p, Card[] options)
        {
            textBox1.Text += $"========== {p.Username} ==========" + Environment.NewLine;

            textBox1.Text += "Cards : " + GenerateArrayToText(options);

            textBox1.Text += "Hand : " + GenerateArrayToText(p.EndHand.Cards);
            textBox1.Text += "Hand Rank : " + p.EndHand.Ranking.ToString() + ConvertRankingToText(p.EndHand.Ranking) + Environment.NewLine + Environment.NewLine;


        }

        private void DisplayResultsWinner(Player[] winner)
        {
            textBox1.Text += "========== Determined Winner ==========" + Environment.NewLine;

            textBox1.Text += $"There are {winner.Length} winner(s)" + Environment.NewLine;

            textBox1.Text += "Winners are: " + Environment.NewLine;

            foreach (Player p in winner)
            {
                textBox1.Text += $"{p.Username}" + Environment.NewLine;
            }

        }

        public string ConvertRankingToText(int rank)
        {
            string res = " ";
            switch (rank)
            {
                case 1:
                    res += "High Card";
                    break;
                case 2:
                    res += "One Pair";
                    break;
                case 3:
                    res += "Two Pair";
                    break;
                case 4:
                    res += "Three Of A Kind";
                    break;
                case 5:
                    res += "Straight";
                    break;
                case 6:
                    res += "Flush";
                    break;
                case 7:
                    res += "Full House";
                    break;
                case 8:
                    res += "Four Of A Kind";
                    break;
                case 9:
                    res += "Straight Flush";
                    break;
                case 10:
                    res += "Royal Flush";
                    break;

            }

            return res;
        }

        private void RunFixed(object sender, EventArgs e)
        {

            /*
            * Clubs : ♣
            * Hearts : ♥
            * Spades : ♠
            * Diamonds : ♦
            * Values : 2 <= value <= 14   ( 2 - A ) 
            */

            Card[] RFExample;
            Card[] SFExample;
            Card[] FKExample;
            Card[] FHExample;
            Card[] FlExample;
            Card[] StExample;
            Card[] TKExample;
            Card[] TPExample;
            Card[] OPExample;
            Card[] HCExample;

            RFExample = new Card[] { new Card(10, '♦'), new Card(11, '♦'), new Card(12, '♦'), new Card(13, '♦'), new Card(14, '♦'), new Card(2, '♠'), new Card(5, '♠') };
            SFExample = new Card[] { new Card(2, '♦'), new Card(3, '♦'), new Card(4, '♦'), new Card(5, '♦'), new Card(1, '♦'), new Card(6, '♠'), new Card(12, '♠') };
            FKExample = new Card[] { new Card(10, '♦'), new Card(10, '♥'), new Card(10, '♣'), new Card(10, '♠'), new Card(14, '♦'), new Card(2, '♠'), new Card(5, '♠') };
            FHExample = new Card[] { new Card(10, '♦'), new Card(10, '♥'), new Card(10, '♣'), new Card(14, '♠'), new Card(14, '♦'), new Card(2, '♠'), new Card(5, '♠') };
            FlExample = new Card[] { new Card(2, '♦'), new Card(4, '♦'), new Card(6, '♦'), new Card(8, '♦'), new Card(10, '♦'), new Card(2, '♠'), new Card(5, '♠') };
            StExample = new Card[] { new Card(2, '♦'), new Card(3, '♥'), new Card(4, '♥'), new Card(5, '♠'), new Card(1, '♠'), new Card(13, '♣'), new Card(12, '♣') };
            TKExample = new Card[] { new Card(10, '♦'), new Card(10, '♥'), new Card(10, '♣'), new Card(8, '♠'), new Card(14, '♦'), new Card(2, '♠'), new Card(5, '♠') };
            TPExample = new Card[] { new Card(10, '♦'), new Card(10, '♥'), new Card(14, '♠'), new Card(14, '♦'), new Card(12, '♦'), new Card(2, '♠'), new Card(5, '♠') };
            OPExample = new Card[] { new Card(10, '♦'), new Card(10, '♥'), new Card(7, '♠'), new Card(14, '♦'), new Card(12, '♦'), new Card(2, '♠'), new Card(5, '♠') };
            HCExample = new Card[] { new Card(2, '♦'), new Card(4, '♥'), new Card(6, '♠'), new Card(8, '♦'), new Card(10, '♦'), new Card(12, '♠'), new Card(5, '♠')};

            textBox1.Text = "";

            DisplayResultsEvaluator(RFExample, CONSTANTS.HSCols.RF);
            DisplayResultsEvaluator(SFExample, CONSTANTS.HSCols.SF);
            DisplayResultsEvaluator(FKExample, CONSTANTS.HSCols.FK);
            DisplayResultsEvaluator(FHExample, CONSTANTS.HSCols.FH);
            DisplayResultsEvaluator(FlExample, CONSTANTS.HSCols.Fl);
            DisplayResultsEvaluator(StExample, CONSTANTS.HSCols.St);
            DisplayResultsEvaluator(TKExample, CONSTANTS.HSCols.TK);
            DisplayResultsEvaluator(TPExample, CONSTANTS.HSCols.TP);
            DisplayResultsEvaluator(OPExample, CONSTANTS.HSCols.OP);
            DisplayResultsEvaluator(HCExample, CONSTANTS.HSCols.HC);

        }

        private void PasswordHashTest(object sender, EventArgs e)
        {
            string passwordGen = "";
            string hashedPassword = "";

            string validChars = CONSTANTS.LowerCaseChars + CONSTANTS.UpperCaseChars + CONSTANTS.Numbers + CONSTANTS.SymbolsAllowed;


            int length = rnd.Next(8, 32);

            for (int i=0; i<length; i++)
            {
                int index = rnd.Next(0, validChars.Length);
                passwordGen += validChars[index];
            }

            hashedPassword = Hashing.HashStr(passwordGen);

            textBox1.Text = "";

            textBox1.Text += "Generated Password: " + passwordGen + Environment.NewLine;
            textBox1.Text += "Hashed Password: " + hashedPassword + Environment.NewLine;
        }

        private void DetermineWinnerTest(object sender, EventArgs e)
        {
            Player p1 = new Player(0, 0, "Player 1", 0, null, null);
            Player p2 = new Player(0, 0, "Player 2", 0, null, null);
            Player p3 = new Player(0, 0, "Player 3", 0, null, null);
            Player p4 = new Player(0, 0, "Player 4", 0, null, null);

            deck = new Deck();

            Card[] first8Deal = new Card[8];

            for(int i=0; i<8; i++)
            {
                first8Deal[i] = deck.PopCard();
            }

            /*
             * Player 1 has cards 0 and 4
             * Next player has +1 to both values
             */

            p1.SetPocketCards(first8Deal[0], 0);
            p2.SetPocketCards(first8Deal[1], 0);
            p3.SetPocketCards(first8Deal[2], 0);
            p4.SetPocketCards(first8Deal[3], 0);

            p1.SetPocketCards(first8Deal[4], 1);
            p2.SetPocketCards(first8Deal[5], 1);
            p3.SetPocketCards(first8Deal[6], 1);
            p4.SetPocketCards(first8Deal[7], 1);

            Card[] community = new Card[5];
            for(int i=0; i< 5; i++)
            {
                community[i] = deck.PopCard();
            }

            // Calculate each players hand
            Card[] p1Options;
            Card[] p2Options;
            Card[] p3Options;
            Card[] p4Options;

            p1Options = p1.PocketCards.Concat(community).ToArray();
            p2Options = p2.PocketCards.Concat(community).ToArray();
            p3Options = p3.PocketCards.Concat(community).ToArray();
            p4Options = p4.PocketCards.Concat(community).ToArray();

            p1.EndHand = Algorithms.SevenCardEval(p1Options);
            p2.EndHand = Algorithms.SevenCardEval(p2Options);
            p3.EndHand = Algorithms.SevenCardEval(p3Options);
            p4.EndHand = Algorithms.SevenCardEval(p4Options);

            Player[] players = new Player[] { p1, p2, p3, p4 };

            // Get same largest hands

            List<Player> potentialTies = new List<Player>();
            foreach (Player p in players)
            {
                if (potentialTies.Count == 0)
                {
                    potentialTies.Add(p);
                }
                else
                {
                    if (potentialTies[0].EndHand.Ranking < p.EndHand.Ranking)
                    {
                        potentialTies.Clear();
                        potentialTies.Add(p);
                    }
                    else if (potentialTies[0].EndHand.Ranking == p.EndHand.Ranking)
                    {
                        potentialTies.Add(p);
                    }
                }
            }

            textBox1.Text = "";

            DisplayResultsPlayer(p1, p1Options);
            DisplayResultsPlayer(p2, p2Options);
            DisplayResultsPlayer(p3, p3Options);
            DisplayResultsPlayer(p4, p4Options);

            Player[] winners = Algorithms.DetermineWinner(potentialTies.ToArray());

            DisplayResultsWinner(winners);

        }
    }
}
