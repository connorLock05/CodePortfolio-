using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerGameNEAProj
{
    internal class CardPosObj
    {
        Card card;
        int tablePos; // Number 0 - 4  (0: Community Cards, 1-4: references Player)
        int cardSlot; // Number 1-5    (References Card Position in Specified TablePos    Only 1 or 2 for Player Locations)

        public int TablePos { get { return tablePos; } }
        public int CardSlot { get { return cardSlot; } }
        public Card Card { get { return card; } }

        public CardPosObj(Card card, int tablePos, int cardSlot)
        {
            this.card = card;
            this.tablePos = tablePos;
            this.cardSlot = cardSlot;
        }

        
    }
}
