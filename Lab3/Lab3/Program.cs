using System;
using PG2Input;
using FullSailCasino;
using BlackjackClassLibrary;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] SortingOptions = { "1. Play Blackjack", "2. Shuffle and Show Deck", "3. Sample Hands", "4. Exit" };
            BlackjackGame blackjackGame = new BlackjackGame();

            Deck deck = new Deck();

            bool bHasExit = false;
            while (!bHasExit)
            {
                int input = 0;
                Input.ReadChoice("Please select an option below. \n", SortingOptions, out input);

                switch (input)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Starting Game");
                        blackjackGame.PlayRound();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Shuffling and Printing Deck");
                        deck.Shuffle();
                        deck.PrintDeck();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Dealing a simple hand");
                        BlackjackDeck blackjackDeck = new BlackjackDeck();
                        blackjackDeck.Shuffle();
                        BlackjackHand PlayerHand = new BlackjackHand(false);
                        BlackjackHand DealerHand = new BlackjackHand(true);
                        for(int i = 0; i < 2; i++)
                        {
                            PlayerHand.AddCard(blackjackDeck.Deal());
                            DealerHand.AddCard(blackjackDeck.Deal());
                        }
                        PlayerHand.PrintHand(0, 2, false);
                        DealerHand.PrintHand(0, 3, false);
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        bHasExit = true;
                        break;
                    default:
                        Console.WriteLine("That is not a valid input, please enter a number shown");
                        break;
                }

            }
            Console.WriteLine("You have exited the program. \n -- press any key to close this window --");
            Console.ReadKey();
        }
    }
}
