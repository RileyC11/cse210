using W03_Prove_Hilo_Game.Game;

namespace W03_Prove_Hilo_Game
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