using System;
using System.Collections.Generic;

// namespace W05_Prove_Jumper_Game.Game
// {
    public class Jumper
    {
        // public string[] secretWord = {"_", "_", "_", "_", "_"};
        public string secretWord = "";
        public string[] words = new string[100];
        public char[] secretLetters = {'_', '_', '_', '_', '_'};
        public string[] person = {"  ___  ", " /___\\ ", " \\   / ", "  \\ /  ", "   O   ", "  /|\\  ", "  / \\   "};
        public char guess;
        public string filePath = @"C:\Users\HP\OneDrive - BYU-Idaho\CSE 210\cse210\W05_Prove_Jumper_Game\Game\Words.txt";
        public bool correctGuess = false;
        public int correctGuesses = 0;
        public int incorrectGuesses = 0;
        public bool isAlive = true;
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
            Console.WriteLine(secretWord);
            // secretLetters = secretWord.ToCharArray();
            // foreach (char c in secretLetters)
            // {
            //     Console.WriteLine(c);
            // }



            while (isAlive == true)
            {
                Console.WriteLine(secretLetters);
                Console.Write("Guess a letter: ");
                guess = char.Parse(Console.ReadLine());

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (guess == secretWord[i])
                    {
                        secretLetters[i] = guess;
                    }
                }

                Console.WriteLine(secretLetters);


                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (secretLetters[i] != '_')
                    {
                        correctGuesses += 1;
                    }
                }

                Console.WriteLine(correctGuesses);

                if (correctGuesses == 5)
                {
                    Console.WriteLine("You won!");
                    isAlive = false;
                    break;
                }
                

                for (int i = 0; i < secretWord.Length; i++)
                {
                    if (guess == secretWord[i])
                    {
                        // Console.WriteLine($"guessed right: {guess}");
                        correctGuess = true;
                        break;
                    }
                    else
                    {
                        // Console.WriteLine($"not guessed yet: {secretWord[i]}");
                        correctGuess = false;
                    }
                }

                for (int i = 0; i < person.Length; i++)
                {
                    Console.WriteLine(person[i]);
                }

                Console.WriteLine(guess);

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

                for (int i = 0; i < person.Length; i++)
                {
                    Console.WriteLine(person[i]);
                }

                if (incorrectGuesses == 5)
                {
                    isAlive = false;
                    Console.WriteLine("You're dead now.");
                }

                correctGuesses = 0;
            }

        }

        public void CreatePerson()
        {
            // Console.WriteLine("  ___  ");
            // Console.WriteLine(" /___\ ");
            // Console.WriteLine(" \   / ");
            // Console.WriteLine("  \ /  ");
            // Console.WriteLine("   O   ");
            // Console.WriteLine("  /|\  ");
            // Console.WriteLine("  / \   ");

        }
    }
// }