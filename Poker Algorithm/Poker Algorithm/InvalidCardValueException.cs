using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker_Algorithm
{
    internal class InvalidCardValueException : Exception
    {
        public InvalidCardValueException()
        {

        }

        public InvalidCardValueException(string message) : base(message)
        {

        }

        public InvalidCardValueException(string message, Exception e) : base(message, e)
        {

        }
    }
}
