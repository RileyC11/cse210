using System;
using System.Collections.Generic;

namespace W05_Prove_jumper.Game
{
    public class Director
    {
        public TerminalServices terminalServices = new TerminalServices();
        public Guesser guesser = new Guesser();
        public Jumper jumper = new Jumper();
        public bool isAlive = true;
        public bool correctGuess = true;
        public bool hasWon = true;
        public string secretWord = "";
        public char guess;

        public void StartGame()
        {
            Console.WriteLine(jumper.secretWord);

            while (isAlive == true)
            {
            // GetInputs();
            // DoUpdates();
            // DoOutputs();


            jumper.CreatePerson();

            guess = terminalServices.ReadChar("Guess a letter: ");
            guesser.UpdateGuess(guess);
            Console.WriteLine(guesser.guess);

            this.correctGuess = jumper.CheckGuess(guess);
            // this.correctGuess = jumper.CheckGuess(guesser.GetGuess());
            Console.WriteLine(correctGuess);

            jumper.UpdatePerson(correctGuess);
            this.isAlive = jumper.CheckAlive();
            Console.WriteLine(isAlive);

            if (isAlive == false)
            {
                jumper.CreatePerson();
            }
            }
            
        }

        public void GetInputs()
        {
            guess = terminalServices.ReadChar("Guess a letter: ");
        }

        public void DoUpdates()
        {
            guesser.UpdateGuess(guess);
            this.correctGuess = jumper.CheckGuess(guess);
            jumper.UpdatePerson(correctGuess);       
            this.isAlive = jumper.CheckAlive(); 
        }

        public void DoOutputs()
        {

        }
    }
}