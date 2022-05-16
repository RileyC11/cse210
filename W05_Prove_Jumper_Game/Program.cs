using System;

namespace W05_Prove_Jumper_Game
{
    class Program
    {
        static int Main(string[] args)
        {
            Director director = new Director();
            director.StartGame();
            return 0;
        }
    }
}