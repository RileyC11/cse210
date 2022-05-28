using System;
using System.Collections.Generic;

namespace W05_Prove_Jumper_Game.Game
{
    public class Guesser
    {
        public char guess;
        public char[] secretLetters = {'_', '_', '_', '_', '_'};

        public Guesser()
        {
        }

        public char GetGuess()
        {
            // Console.Write("Guess a letter: ");
            // guess = char.Parse(Console.ReadLine());
            return guess;
        }

        public void UpdateGuess(char guess)
        {
            this.guess = guess;
        }
    }
}