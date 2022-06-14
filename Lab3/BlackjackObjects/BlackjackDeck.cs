using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    public class BlackjackDeck : Deck
    {
        public override void CreateAllCards()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardFace face in Enum.GetValues(typeof(CardFace)))
                {
                    BlackjackCard card = Factory.CreateBlackjackCard(face, suit);
                    cards.Add(card);
                }
            }
        }
    }
}
