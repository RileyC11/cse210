using System;
using System.Collections.Generic;

namespace W03_Prove_Hilo_Game.Game
{
    public class Director
    {
        List<Card> cards = new List<Card>();
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
                cards.Add(card);
            }
        }

        public void StartGame()
        {
            while (isPlaying)
            {
                // foreach (Card card in cards)
                // {
                //     Console.WriteLine(card.value);
                // }
                MakeCards();
                DisplayCard();
                GetGuess();
                DisplayCard();
                DoUpdates();
                DisplayScore();
                PlayAgain();
                Console.WriteLine();
                
            }
        }
        
        public void MakeCards()
        {
            foreach (Card card in cards)
                {
                    card.Draw();
                }
        }
        public void DisplayCard()
        {
            if (!isPlaying)
            {
                return;
            }

            int cardOne = cards[0].value;
            int cardTwo = cards[1].value;
            // Console.WriteLine(cardOne);
            // Console.WriteLine(cardTwo);
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
            if (!isPlaying)
            {
                return;
            }
            
            int cardOne = cards[0].value;
            int cardTwo = cards[1].value;
            score = 0;

            if (cardOne == cardTwo)
            {
                score = 0;
                totalScore += score;
            }
            else if (cardOne > cardTwo && guess == "h") //next card was lower and user guessed higher
            {
                score = -75;
                totalScore += score;
            }
            else if (cardOne < cardTwo && guess == "h") //next card was higher and user guess higher
            {
                score = 100;
                totalScore += score;
            }
            else if (cardOne > cardTwo && guess == "l") //next card was lower and user guessed lower
            {
                score = 100;
                totalScore += score;
            }
            else if (cardOne < cardTwo && guess == "l") //next card was higher and user guessed lower 
            {
                score = -75;
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