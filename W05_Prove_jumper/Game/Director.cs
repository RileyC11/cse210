using System;

namespace W05_Prove_jumper.Game
{
    public class Director
    {
        private TerminalServices terminalServices = new TerminalServices();
        private Guesser guesser = new Guesser();
        private Jumper jumper = new Jumper();
        private Checker checker = new Checker();
        private bool isAlive = true;
        private bool hasWon = false;
        private bool alreadyGuessed = false;
        private bool correctGuess = false;
        private bool breakLoop = false;
        private bool continueUpdates = true;
        private string secretWord = "";
        private char guess;
        
        public Director()
        {
        }

        public void StartGame()
        {            
            checker.WriteLetters();

            while (isAlive == true && hasWon == false)
            {
                while (breakLoop == false && isAlive == true && hasWon == false)
                {
                    jumper.CreatePerson();
                    GetInputs();
                    breakLoop = DoUpdates();
                    if (breakLoop == true)
                    {
                        break;
                    }
                    DoOutputs(); 
                }

                alreadyGuessed = false;
                breakLoop = false;
            }
            
        }

        private void GetInputs()
        {
            this.guess = terminalServices.ReadChar("Guess a letter: ");
        }

        private bool DoUpdates()
        {
            this.secretWord = checker.secretWord;
            // Console.WriteLine(secretWord);
            guesser.UpdateGuess(guess);
            this.alreadyGuessed = checker.CheckLists(guess);
            this.correctGuess = checker.CheckGuess(guess);
            
            breakLoop = (alreadyGuessed == true);

            continueUpdates = !breakLoop;
            if (continueUpdates == true)
            {
                jumper.UpdatePerson(correctGuess);
                this.isAlive = jumper.CheckAlive();
                this.hasWon = checker.CheckWin();
                checker.WriteLetters();
            }
            else
            {
                terminalServices.WriteText($"You already guessed the letter '{guess}'.\n");
                checker.WriteLetters();
            }

            return breakLoop;  
        }

        private void DoOutputs()
        {
            if (isAlive == false)
            {
                jumper.CreatePerson();
                terminalServices.WriteText("You're dead now. Ka-splat!");
                terminalServices.WriteText($"The secret word was '{secretWord}' just so you know.\n");
            }

            else if (isAlive == true && hasWon == true)
            {
                terminalServices.WriteText($"\nYou're alive! Congrats on guessing the word '{secretWord}'.\n");

            }
        }
    }
}