using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    internal static class Hashing
    {
        public static string HashStr(string toHash)
        {
            char[] charsFromText = toHash.ToCharArray();

            int[] UTF8fromText = new int[charsFromText.Length];

            for(int i=0; i<charsFromText.Length; i++)
            {
                UTF8fromText[i] = (int)charsFromText[i];
            }

            int total = UTF8fromText[0];

            for (int i = 1; i < UTF8fromText.Length; i++)
            {
                if (i % 4 == 0)
                {
                    total /= UTF8fromText[i];
                }
                else if (i % 3 == 0)
                {
                    total *= UTF8fromText[i];
                }
                else if (i % 2 == 0)
                {
                    total += UTF8fromText[i];
                }
                else
                {
                    total -= UTF8fromText[i];
                }

                total *= UTF8fromText.Length - i;
            }

            Random rnd = new Random(total);

            int[] UTF8Gen = new int[150];
            char[] charFromUTF8 = new char[150];

            for (int i = 0; i < 150; i++)
            {
                int tempGen;
                do
                {
                    tempGen = rnd.Next(32, 127);
                } while (tempGen == 34 || tempGen == 39 || tempGen == 44 || tempGen == 126 || tempGen == 59);

                UTF8Gen[i] = tempGen;
            }

            for(int i=0; i<150; i++)
            {
                charFromUTF8[i] = (char)UTF8Gen[i];
            }

            string join = "";

            foreach (char character in charFromUTF8)
            {
                join += character;
            }

            return join;
        }

    }
}
