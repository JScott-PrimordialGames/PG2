using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    public class BlackjackCard : Card
    {
        int value = 0;
        public BlackjackCard(CardFace face, CardSuit suit) : base(face, suit)
        {
            if (face == CardFace._J || face == CardFace._K || face == CardFace._Q)
                value = 10;
            else if (face == CardFace._A)
                value = 11;
            else
                value = ((int)face);
        }

        public int GetValue()
            { return value; }
    }
}
