using W09_Prove_cycle_game.Game.Casting;
using W09_Prove_cycle_game.Game.Directing;
using W09_Prove_cycle_game.Game.Scripting;
using W09_Prove_cycle_game.Game.Services;
using W09_Prove_cycle_game;


namespace W09_Prove_cycle_game
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            Snake snake1 = new Snake(Constants.SNAKE1_INT_POS, Constants.HEAVY_ORANGE, Constants.SNAKE1_INT_VEL);
            Snake snake2 = new Snake(Constants.SNAKE2_INT_POS, Constants.LIGHT_BLUE, Constants.SNAKE2_INT_VEL);
            Score score1 = new Score("Player 1");
            Score score2 = new Score("Player 2");

            cast.AddActor("snake1", snake1);
            cast.AddActor("snake2", snake2);
            cast.AddActor("score1", score1);
            cast.AddActor("score2", score2);

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
            
            ControlActorsAction controlActorsAction = new ControlActorsAction(keyboardService);
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(videoService);
            // RestartGame restartGame = new RestartGame(handleCollisionsAction, controlActorsAction);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", controlActorsAction);
            script.AddAction("update", moveActorsAction);
            script.AddAction("update", handleCollisionsAction);
            script.AddAction("output", drawActorsAction);
            // script.AddAction("restart", restartGame);

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}