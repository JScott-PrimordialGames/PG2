using BlackjackClassLibrary;
using PG2Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullSailCasino
{
    public class BlackjackGame
    {
        BlackjackHand Dealer;
        BlackjackHand Player;
        BlackjackDeck Deck;
        int PlayerWins;
        int DealerWins;
        bool bPlayerTurnComplete;

        public void PlayRound()
        {
            Deck = new BlackjackDeck();
            Deck.Shuffle();
            Player = new BlackjackHand(false);
            Dealer = new BlackjackHand(true);
            bPlayerTurnComplete = false;
            DealInitialCards();

            if(Player.GetScore() >= 21 || Dealer.GetScore() >= 21)
            {
                DeclareWinner();
            }
            else
            {
                PlayersTurn();
                DealersTurn();
                DeclareWinner();
            }
            DrawTable();

            string[] YesNo = { "1. Yes", "2. No" };
            int Selection;
            Console.WriteLine();
            Input.ReadChoice("Would you like to play Again?", YesNo, out Selection);
            switch (Selection)
            {
                case 1:
                    PlayRound();
                    break;
                case 2:
                    break;
                default:
                    Console.WriteLine("That is not a valid input, please enter a number shown");
                    break;
            }
        }

        public void DealInitialCards()
        {
            for(int i = 0; i < 2; i++)
            {
                Player.AddCard(Deck.Deal());
                Dealer.AddCard(Deck.Deal());
            }
            DrawTable();
        }

        public void PlayersTurn()
        {
            bool bHasStood = false;
            string[] GameMoves = { "1. Hit", "2. Stand" };
            int Selection = 0;
            while (Player.GetScore() < 21 && !bHasStood)
            {
                Input.ReadChoice("Hit or Stand?", GameMoves,out Selection);
                switch(Selection)
                {
                    case 1:
                        Player.AddCard(Deck.Deal());
                        DrawTable();
                        break;
                    case 2:
                        bHasStood = true;
                        break;
                    default:
                        Console.WriteLine("That is not a valid input, please enter a number shown");
                        break;
                }
            }
            bPlayerTurnComplete = true;
        }

        public void DealersTurn()
        {
            while (Dealer.GetScore() <= 17)
            {
                Dealer.AddCard(Deck.Deal());
                DrawTable();
            }
        }

        public void DeclareWinner()
        {
            //If the dealer busts, the player automaticaly wins
            if (Dealer.GetScore() > 21)
            {
                PlayerWins++;
                return;
            }
            if (Player.GetScore() <= 21 && Player.GetScore() > Dealer.GetScore())
                PlayerWins++;
            else if (Player.GetScore() > 21 || Player.GetScore() < Dealer.GetScore() && Dealer.GetScore() <= 21)
                DealerWins++;                     
        }

        public void DrawTable()
        {
            //Table Setup
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.Write("Table");
            Console.CursorLeft = 7;
            Console.Write("|");
            Console.WriteLine("----------------------------");
            Console.SetCursorPosition(0, 2);
            Console.Write("Dealer");
            Console.SetCursorPosition(7, 2);
            Console.Write("|");
            Console.SetCursorPosition(0, 3);
            Console.Write("Player");
            Console.SetCursorPosition(7, 3);
            Console.Write("|");

            Dealer.PrintHand(8, 2, bPlayerTurnComplete);
            Player.PrintHand(8, 3, bPlayerTurnComplete);

            Console.SetCursorPosition(0, 5);
            DrawWins();
        }

        public void DrawWins()
        {
            Console.Write("Player Wins: " + PlayerWins);
            Console.Write(" | ");
            Console.Write("Dealer Wins: " + DealerWins);
            Console.WriteLine();
        }

    }
}
