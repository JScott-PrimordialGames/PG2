using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BlackjackClassLibrary
{
    public class Deck
    {
        public List<Card> cards;

        public Deck()
        {
            cards = new List<Card>();
            CreateAllCards();
        }

        public virtual void CreateAllCards()
        {
            foreach(CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach(CardFace face in Enum.GetValues(typeof(CardFace)))
                {
                    Card card = Factory.CreateCard(face, suit);
                    cards.Add(card);
                }
            }
            Shuffle();
        }

        public Card Deal()
        {
            if (cards.Count == 0)
                CreateAllCards();
            Card DealtCard = cards[0];
            cards.RemoveAt(0);
            return DealtCard;

        }

        public void Shuffle()
        {
            Random random = new Random();
            int i = cards.Count;
            while (i > 1)
            {
                i--;
                int j = random.Next(i + 1);
                Card card = cards[j];
                cards[j] = cards[i];
                cards[i] = card;
            }
        }

        public void PrintDeck()
        {
            int x = 0;
            int y = 2;
            foreach (Card card in cards)
            {
                if (x >= 48)
                {
                    y +=2;
                    x = 0;
                }
                card.PrintCard(x, y);
                x += 8;
            }
            Console.WriteLine();
            Console.WriteLine("Complete");
        }

    }
}
