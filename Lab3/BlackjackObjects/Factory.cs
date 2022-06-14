using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    static class Factory
    {
        public static Card CreateCard(CardFace face, CardSuit suit)
        {
            Card card = new Card(face, suit);
            return card;
        }

        public static BlackjackCard CreateBlackjackCard(CardFace face, CardSuit suit)
        {
            BlackjackCard card = new BlackjackCard(face, suit);
            return card;
        }

    }
}
