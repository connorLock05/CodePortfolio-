using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    internal class NetworkCMD
    {
        string command;
        string[] args;

        public string Command { get { return command; } }
        public string[] Args { get { return args; } }

        // Command Format : CMD-arg,arg,arg,...,arg;

        public NetworkCMD(string CMDrecieved)
        {
            CMDrecieved = StripBackZero(CMDrecieved);

            string[] tempSplit = CMDrecieved.Split('~');

            command = tempSplit[0];

            if (tempSplit.Length > 1) { args = tempSplit[1].Split(','); }
            
        }

        private string StripBackZero(string CMD)
        {
            int firstOccurence = CMD.IndexOf('\0');
            if (firstOccurence == -1) { return CMD; }
            CMD = CMD.Remove(firstOccurence, CMD.Length - firstOccurence);

            return CMD;
        }
    }
}
