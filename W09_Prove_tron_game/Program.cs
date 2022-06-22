using W09_Prove_tron_game.Game.Casting;
using W09_Prove_tron_game.Game.Directing;
using W09_Prove_tron_game.Game.Scripting;
using W09_Prove_tron_game.Game.Services;


namespace W09_Prove_tron_game
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
            cast.AddActor("food", new Food());
            cast.AddActor("snake", new Snake(new Point(90,300), new Color(223, 116, 12)));
            cast.AddActor("snake1", new Snake(new Point(750,300), new Color(111, 195, 223)));
            cast.AddActor("score", new Score());
            cast.AddActor("score1", new Score());

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}