using W05_Prove_Jumper_Game.Game;

namespace W05_Prove_Jumper_Game
{
    public class Program
    {
        static int Main(string[] args)
        {
            Director director = new Director();
            director.StartGame();
            return 0;
        }
    }
}