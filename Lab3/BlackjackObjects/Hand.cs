using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    public class Hand
    {
        protected List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        public virtual void AddCard(Card card0)
        {
            cards.Add(card0);
        }

        public virtual void PrintHand(int PosX, int PosY)
        {
            foreach (Card card in cards)
            {
                card.PrintCard(PosX, PosY);
                PosX += 8;
            }
        }
    }
}
