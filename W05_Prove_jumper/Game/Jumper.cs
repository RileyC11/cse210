using System;
using System.Collections.Generic;

namespace W05_Prove_jumper.Game
{
    public class Jumper
    {
        public string[] person = {"  ___  ", " /___\\ ", " \\   / ", "  \\ /  ", "   O   ", "  /|\\  ", "  / \\   "};

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
                        break;
                    }
                    else if (person[i] != "")
                    {
                        person[i] = "";
                        break;
                    }
                }
            }
        }
    }
}