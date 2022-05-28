using System;

namespace W05_Prove_Jumper_Game.Game
{
    public class Director
    {
        private TerminalServices terminalServices = new TerminalServices();
        private Guesser guesser = new Guesser();
        private Jumper jumper = new Jumper();
        private Checker checker = new Checker();
        private bool correctGuess = false;
        private bool isAlive = true;
        private bool hasWon = false;
        private string secretWord = "";
        private char guess;
        private bool alreadyGuessed = false;
        private bool breakLoop = false;
        
        public Director()
        {
            this.secretWord = jumper.secretWord;
        }

        public void StartGame()
        {
            Console.WriteLine(checker.secretWord);

            while (isAlive == true && hasWon == false)
            {
                while (breakLoop == false && isAlive == true && hasWon == false)
                {
                    jumper.CreatePerson();
                    GetInputs();
                    breakLoop = DoChecks();
                    if (breakLoop == true)
                    {
                        terminalServices.WriteText("You already guessed that letter.");
                        break;
                    }
                    DoUpdates();
                    DoOutputs(); 
                }
                // jumper.CreatePerson();
                // GetInputs();
                // DoUpdates();
                // DoOutputs();

                breakLoop = false;
                alreadyGuessed = false;


            // jumper.CreatePerson();

            // guess = terminalServices.ReadChar("Guess a letter: ");
            // guesser.UpdateGuess(guess);
            // Console.WriteLine($"Guess in guesser: {guesser.guess}");

            // this.correctGuess = jumper.CheckGuess(guess);
            // // this.correctGuess = jumper.CheckGuess(guesser.GetGuess());
            // Console.WriteLine($"Correct guess: {correctGuess}");

            // jumper.UpdatePerson(correctGuess);
            // this.isAlive = jumper.CheckAlive();
            // this.hasWon = jumper.CheckWin();
            // Console.WriteLine($"Alive: {isAlive}");
            // Console.WriteLine($"Won: {hasWon}");

            }
            
        }

        private void GetInputs()
        {
            this.guess = terminalServices.ReadChar("Guess a letter: ");     // displays that message in the terminal
        }

        private bool DoChecks()
        {
            guesser.UpdateGuess(guess);                             // updates the guess var in Guesser
            this.alreadyGuessed = checker.CheckLists(guess);        // checks to see if the guess has already been guessed and returns bool. Default is false.
            // this.correctGuess = jumper.CheckGuess(guess);       // checks to see if the guess char is in the secret word. Returns bool. Default is false.
            this.correctGuess = checker.CheckGuess(guess);      // use this one instead of the jumper one.
            checker.WriteLetters();
            Console.WriteLine($"Already Guessed Check: {alreadyGuessed}");
            Console.WriteLine($"Correct Guess Check: {correctGuess}");
            
            breakLoop = (alreadyGuessed == true);
            Console.WriteLine($"Breakloop: {breakLoop}");

            return breakLoop;
        }
        private void DoUpdates()
        {
            jumper.UpdatePerson(correctGuess);      // updates the parachute as needed. No prints.
            this.isAlive = jumper.CheckAlive();     // checks to see if the jumper is alive or has a chute and returns bool. No prints.
            // this.hasWon = jumper.CheckWin();        // checks to see if the guesser has guessed the word and returns bool. No prints.

            this.hasWon = checker.CheckWin();      // use this one instead of jumper

            Console.WriteLine($"Correct Guess Update: {correctGuess}");    // tells me if the program properly compared the guess and secret word. Default bool is false.
            Console.WriteLine($"Is alive Update: {isAlive}");              // tells me if the program properly determined if jumper is alive. Default bool is true.
            Console.WriteLine($"Has won Update: {hasWon}");                // tells me if the program properly compared guessed letters and secret word. Default is false.
        }

        private void DoOutputs()
        {
            if (isAlive == false)
            {
                terminalServices.WriteText("You're dead now. Ka-splat!");
                terminalServices.WriteText($"The secret word was '{secretWord}' just so you know");
                // terminalServices.WriteText("");
            }
            else if (isAlive == true && hasWon == true)
            {
                terminalServices.WriteText($"You're alive! Congrats on guessing the word '{secretWord}'.");
                // terminalServices.WriteText("");
            }
        }
    }
}