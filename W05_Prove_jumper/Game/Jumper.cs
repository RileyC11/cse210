using System;
using System.Collections.Generic;

namespace W05_Prove_jumper.Game
{
    public class Jumper
    {
        public string filePath = @"C:\Users\HP\OneDrive - BYU-Idaho\CSE 210\cse210\W05_Prove_Jumper_Game\Game\Words.txt";
        
        public string secretWord = "";
        public string[] words = new string[100];
        public char[] secretLetters = {'_', '_', '_', '_', '_'};
        public string[] person = {"  ___  ", " /___\\ ", " \\   / ", "  \\ /  ", "   O   ", "  /|\\  ", "  / \\   "};
        public char guess;
        
        public bool correctGuess = false;
        public int correctGuesses = 0;
        public int incorrectGuesses = 0;
        public bool isAlive = true;
        public bool hasWon = false;
        public bool arraysEqual = false;

        public Jumper()
        {
        }

        public void CreatePerson()
        {
            Console.WriteLine();
            for (int i = 0; i < person.Length; i++)
            {
                if (person[i] == "")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine(person[i]);
                }
            }
            Console.WriteLine();
        }

        public void UpdatePerson(bool correctGuess)
        {
            if (correctGuess == false)
            {
                for (int i = 0; i < person.Length; i++)
                {
                    if (person[i] != "" && person[i+1] == "   O   ")
                    {
                        person[i] = "";
                        person[i+1] = "   X   ";
                        incorrectGuesses += 1;
                        break;
                    }
                    else if (person[i] != "")
                    {
                        person[i] = "";
                        incorrectGuesses += 1;
                        break;                 
                    }
                }
            }
        }

        public bool CheckAlive()
        {
            if (person.Contains("   X   "))
            {
                isAlive = false;
            }

            return isAlive;
        }
    }
}