using System;
using System.Collections.Generic;

namespace W05_Prove_jumper.Game
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
            Console.WriteLine(text);
        }

    }
}