using System;

// namespace W05_Prove_Jumper_Game.Game
// {
    public class TerminalServices
    {
        public TerminalServices()
        {
        }

        public string ReadText(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void WriteText(string text)
        {
            Console.WriteLine(text);
        }

    }
// }