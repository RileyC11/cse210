using System;
using System.Collections.Generic;

namespace W03_Prove_Hilo_Game.Game
{
    public class Director
    {
        bool isPlaying = true;
        int score = 0;
        int totalScore = 300;
        int playCount = 0;
        string guess = "";
        string playAgain = "";

        public Director()
        {
            for (int i = 0; i < 2; i++)
            {
                Card card = new Card();
                card.Draw();
            }
        }

        public void StartGame()
        {
            while (isPlaying)
            {
                MakeCard();
                DisplayCard();
                GetGuess();
                DisplayCard();
                DoUpdates();
                DisplayScore();
                PlayAgain();
                Console.WriteLine();
            }
        }
        
        public void MakeCard()
        {
            if (playAgain == "y")
            {
                Card card = new Card();
                card.Draw();
            }
        }
        public void DisplayCard()
        {
            Card card = new Card();
            List<int> cardsList = card.GetCards();
            int cardOne = card.CardOne();
            int cardTwo = card.CardTwo();

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
            if (!isPlaying)
            {
                return;
            }

            Console.Write("Higher or lower? [h/l] ");
            guess = Console.ReadLine();
        }

        public void DoUpdates()
        {
            Card card = new Card();
            List<int> cardsList = card.GetCards();
            int cardOne = card.CardOne();
            int cardTwo = card.CardTwo();
            
            if (!isPlaying)
            {
                return;
            }
            
            score = 0;
            if (cardOne == cardTwo) //both cards are the same
            {
                score = 0;
                totalScore += score;
            }
            else if ((cardOne > cardTwo && guess == "h") || (cardOne < cardTwo && guess == "l")) //next card was lower and user guessed higher OR was higher and guessed lower
            {
                score = -75;
                totalScore += score;
            }
            else if ((cardOne < cardTwo && guess == "h") || (cardOne > cardTwo && guess == "l")) //next card was higher and user guess higher OR was lower and guessed lower
            {
                score = 100;
                totalScore += score;
            }
            playCount +=1;
            isPlaying = (totalScore > 0);
        }

        public void DisplayScore()
        {
            Console.WriteLine($"Your score is: {totalScore}");
        }

        public void PlayAgain()
        {
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