using System;
using System.Collections.Generic;

namespace W05_Prove_jumper.Game
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
            return guess;
        }

        public void UpdateGuess(char guess)
        {
            this.guess = guess;
        }
    }
}