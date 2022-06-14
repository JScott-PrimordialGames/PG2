using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackjackClassLibrary
{
    public class BlackjackHand : Hand
    {
        int Score;
        bool bIsDealer = false;

        public BlackjackHand(bool isDealer)
        {
            bIsDealer = isDealer;
        }

        public override void AddCard(Card card)
        {
            base.AddCard(card);
            Score = 0;
            foreach (BlackjackCard card1 in cards)
            {
                if (card1.GetFace() == CardFace._A && cards.Count > 2)
                {
                    Score++;
                }
                else if (card1.GetFace() == CardFace._A && cards.Count <= 2)
                {
                    Score += 11;
                }
                else if (card1.GetFace() == CardFace._J || card1.GetFace() == CardFace._Q || card1.GetFace() == CardFace._K)
                {
                    Score += 10;
                }
                else
                {
                    Score += card1.GetValue() + 1;
                }
            }
        }

        public void PrintHand(int PosX, int PosY, bool ShowAll)
        {
            if (bIsDealer)
            {
                bool bFirst = true;
                foreach (Card card in cards)
                {
                    if (bFirst && !ShowAll)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write("XXXXXX");
                        Console.BackgroundColor = ConsoleColor.Black;
                        PosX += 8;
                        bFirst = false;
                    }
                    else
                    {
                        card.PrintCard(PosX, PosY);
                        PosX += 8;
                    }
                }
                if (ShowAll)
                    Console.WriteLine(" " + Score);
                else
                    Console.WriteLine(" ??");
            }
            else
            {
                base.PrintHand(PosX, PosY);
                Console.WriteLine(" " + Score);
            }

        }

        public int GetScore()
            {return Score;}
        public void SetScore(int score)
            {Score = score;}
    }
}
