using System;
using System.Collections.Generic;

namespace W05_Prove_Jumper_Game.Game
{
    public class Checker
    {
        public TerminalServices terminalServices = new TerminalServices();
        public Jumper jumper = new Jumper();
        public List<char> correctGuessList = new List<char>();
        public List<char> incorrectGuessList = new List<char>();
        public char[] secretLetters = {'_', '_', '_', '_', '_'};
        public string secretWord = "";

        public bool alreadyGuessed = false;

        public Checker()
        {
            this.secretWord = jumper.secretWord;
        }

        public bool CheckLists(char userGuess)
        {
            if (incorrectGuessList.Contains(userGuess) == true)
            {
               alreadyGuessed = true;
            }

            return alreadyGuessed;
        }
        public bool CheckGuess(char userGuess)
        {
            if (incorrectGuessList.Contains(userGuess) == false)
                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (userGuess == secretWord[i])
                    {
                        secretLetters[i] = userGuess;
                    }
                }
            






            if (secretLetters.Contains(userGuess))
            {
                correctGuess = true;
                correctGuessList.Add(userGuess);
            }
            else
            {
                correctGuess = false;
                incorrectGuessList.Add(userGuess);
            }
            return correctGuess;            
        }


    }
}