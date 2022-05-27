using System;
using System.Collections.Generic;

namespace W05_Prove_jumper.Game
{
    public class Checker
    {
        public TerminalServices terminalServices = new TerminalServices();
        public string filePath = @"C:\Users\HP\OneDrive - BYU-Idaho\CSE 210\cse210\W05_Prove_Jumper_Game\Game\Words.txt";
        public List<char> correctGuessList = new List<char>();
        public List<char> incorrectGuessList = new List<char>();
        public char[] secretLetters = {'_', '_', '_', '_', '_'};
        public string[] words = new string[100];

        public string secretWord = "";

        public bool alreadyGuessed = false;
        public bool correctGuess = false;
        public bool hasWon = false;

        public Checker()
        {
            if (File.Exists(filePath))
            {
                words = File.ReadAllLines(filePath);
            }
            
            Random random = new Random();
            int randIndex = random.Next(100);
            secretWord = words[randIndex];
        }

        public bool CheckLists(char userGuess)
        {
            if (incorrectGuessList.Contains(userGuess) || correctGuessList.Contains(userGuess))
            {
               alreadyGuessed = true;
            }
            else
            {
                alreadyGuessed = false;
            }

            return alreadyGuessed;
        }

        public bool CheckGuess(char userGuess)
        {
            
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

        public void WriteLetters()
        {
            foreach (char c in secretLetters)
            {
                Console.Write(c);
            }
            Console.WriteLine();
        }

        public bool CheckWin()
        {
            if (secretLetters.Contains('_') == false)
            {
                hasWon = true;
            }

            return hasWon;
        }
    }
}