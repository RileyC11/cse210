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
            if (File.Exists(filePath))
            {
                words = File.ReadAllLines(filePath);
            }
            
            Random random = new Random();
            int randIndex = random.Next(100);
            secretWord = words[randIndex];
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

        public bool CheckGuess(char guess)
        {
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (guess == secretWord[i])
                {
                    secretLetters[i] = guess;
                    correctGuess = true;
                    break;
                }
                else
                {
                    correctGuess = false;
                }
            }

            foreach (char c in secretLetters)
            {
                Console.Write($"{c} ");
            }
            Console.WriteLine();

            return correctGuess;
        }

        public void UpdatePerson(bool correctGuess)
        {
            if (correctGuess == false)
            {
                for (int i = 0; i < person.Length; i++)
                {
                    if (person[i] == "   O   ")
                    {
                        person[i] = "   X   ";
                        incorrectGuesses +=1;
                        break;
                    }
                    else if (person[i] != "")
                    {
                        person[i] = "";
                        incorrectGuesses +=1;
                        break;                 
                    }
                }
            }
        }

        public bool CheckAlive()
        {
            for (int i = 0; i < secretWord.Length; i++)
            {
                if (secretLetters[i] != '_')
                {
                    correctGuesses += 1;
                }
            }

            if (correctGuesses == 5)
            {
                Console.WriteLine("You won!");
                hasWon = true;
            }

            else if (incorrectGuesses == 5)
            {
                Console.WriteLine("You're dead now.");
                isAlive = false;
            }

            return isAlive;
        }
    }
}