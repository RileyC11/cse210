using System;

namespace W05_Prove_Jumper_Game.Game
{
    public class TerminalServices
    {
        public TerminalServices()
        {
        }

        public char ReadChar(string prompt)
        {
            Console.Write(prompt);
            return char.Parse(Console.ReadLine());
        }

        public void WriteText(string text)
        {
            Console.WriteLine($"{text}\n");
        }

    }
}