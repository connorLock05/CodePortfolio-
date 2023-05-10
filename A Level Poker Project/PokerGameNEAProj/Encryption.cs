using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    static class Encryption
    {
        static public string VernamEncryption(string plaintext, int seed)
        {
            Random rnd = new Random(seed);
            string key = "";

            foreach (char c in plaintext)
            {
                key += (char)rnd.Next(33, 127);
            }

            return $"{Process(plaintext, key)}{key}";
        }

        static private string Process(string text, string key)
        {
            string res = "";

            for (int i = 0; i < text.Length; i++)
            {
                res += (char)((int)text[i] | (int)key[i]);
            }

            return res;
        }

        static public string VernamDecrypt(string encryptedMessage)
        {
            string encryptedText = encryptedMessage.Substring(0, encryptedMessage.Length / 2);
            string key = encryptedMessage.Substring(encryptedText.Length / 2);

            return Process(encryptedText, key);
        }
    }
}
