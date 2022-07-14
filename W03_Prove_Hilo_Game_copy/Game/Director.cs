using System;
using System.Collections.Generic;
using W03_Prove_Hilo_Game_copy.Game;

namespace W03_Prove_Hilo_Game_copy.Game
{
    public class Director
    {
        public bool isPlaying = true;
        public int score = 0;
        public int totalScore = 300;
        public int playCount = 0;
        public string guess = "";
        public string playAgain = "";
        public List<int> cards = new List<int>();

        public Director()
        {
            for (int i = 0; i < 2; i++)
            {
                Deck deck = new Deck(2);
                List<int> cards = deck.GetDeck();
                foreach (int card in cards)
                {
                    Console.WriteLine(card);
                }
            }

            
            Console.WriteLine("Director constructor");
        }

        public void StartGame()
        {
            Console.WriteLine("StartGame");

            while (isPlaying)
            {
                MakeDeck();
                DisplayDeck();
                GetGuess();
                DisplayDeck();
                DoUpdates();
                DisplayScore();
                PlayAgain();
                Console.WriteLine();
            }
        }
        
        public void MakeDeck()
        {
            Console.WriteLine("MakeDeck");
            if (playAgain == "y")
            {
                Deck card = new Deck(1);
                card.Draw(1);
            }
        }
        public void DisplayDeck()
        {
            Console.WriteLine("DisplayDeck");
            Console.WriteLine("Deck");

            // List<int> cards = Deck.GetDeck();
            Console.WriteLine("List");

            Console.WriteLine("No for loop");
            int cardOne = cards[0];
            int cardTwo = cards[1];


            Console.WriteLine(cardOne);
            Console.WriteLine(cardTwo);


            if (!isPlaying)
            {
                return;
            }

            if (guess == "")
            {
                Console.WriteLine($"The card is: {cardOne}");
            }
            else if (guess == "h" || guess == "l")
            {
                Console.WriteLine($"Next card was: {cardTwo}");
            }
            
        }

        public void GetGuess()
        {
            Console.WriteLine("GetGuess");

            if (!isPlaying)
            {
                return;
            }

            Console.Write("Higher or lower? [h/l] ");
            guess = Console.ReadLine();
        }

        public void DoUpdates()
        {
            Console.WriteLine("DoUpdates");

            Deck card = new Deck(0);
            // List<int> cardsList = card.GetDecks();
            int cardOne = card.DeckOne();
            int cardTwo = card.DeckTwo();
            
            if (!isPlaying)
            {
                return;
            }
            
            score = 0;
            if (cardOne == cardTwo) //both cards are the same
            {
                totalScore += 0;
            }
            else if ((cardOne > cardTwo && guess == "h") || (cardOne < cardTwo && guess == "l")) //next card was lower and user guessed higher OR was higher and guessed lower
            {
                totalScore += -75;
            }
            else if ((cardOne < cardTwo && guess == "h") || (cardOne > cardTwo && guess == "l")) //next card was higher and user guess higher OR was lower and guessed lower
            {
                totalScore += 100;
            }
            playCount +=1;
            isPlaying = (totalScore > 0);
        }

        public void DisplayScore()
        {
            Console.WriteLine("DisplayScore");

            Console.WriteLine($"Your score is: {totalScore}");
        }

        public void PlayAgain()
        {
            Console.WriteLine("PlayAgain");

            if (!isPlaying)
            {
                return;
            }

            Console.Write("Play again? [y/n] ");
            playAgain = Console.ReadLine();
            isPlaying = (playAgain == "y");
            guess = "";

            if (playAgain == "n")
            {
                Console.WriteLine($"\nAmount of times played: {playCount}");
            }
        }
    }
}

// want to display amount of times played if their score becomes zero