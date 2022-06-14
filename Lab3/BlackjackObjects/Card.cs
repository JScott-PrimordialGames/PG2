using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    public class Card
    {

        CardSuit Suit;
        CardFace Face;
        

        public Card(CardFace face, CardSuit suit)
        {
            Face = face;
            Suit = suit;
        }

        public CardFace GetFace()
        {
            return Face;
        }

        public CardSuit GetCardSuit()
        {
            return Suit;
        }

        public void PrintCard(int PossX, int PossY)
        {
            Console.SetCursorPosition(PossX, PossY);
            Console.BackgroundColor = ConsoleColor.White;
            if (Suit == CardSuit.Hearts || Suit == CardSuit.Daimonds)
                Console.ForegroundColor = ConsoleColor.Red;
            else
                Console.ForegroundColor = ConsoleColor.Black;

            Console.Write(" " + Face + " ");

            switch(Suit)
            {
                case CardSuit.Hearts:
                    Console.Write((char)3);
                    break;
                case CardSuit.Daimonds:
                    Console.Write((char)4);
                    break;
                case CardSuit.Clubs:
                    Console.Write((char)5);
                    break;
                case CardSuit.Spades:
                    Console.Write((char)6);
                    break;
                default:
                    break;
            }
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor= ConsoleColor.Black;
            
        }
    }
}
