using W11_Prove_retry.Game.Casting;
using W11_Prove_retry.Game.Directing;
using W11_Prove_retry.Game.Scripting;
using W11_Prove_retry.Game.Services;
using W11_Prove_retry;


namespace W11_Prove_retry
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
            
            // Create score1
            Score score1 = new Score("P1", 0);
            score1.SetPosition(new Point(0,0));

            // Create lives1
            Score lives1 = new Score("Lives", 3);
            lives1.SetPosition(new Point(0,15));
            
            // Create score2
            Score score2 = new Score("P2", 0);
            score2.SetPosition(new Point(810,0));

            // Create lives2
            Score lives2 = new Score("Lives", 3);
            lives2.SetPosition(new Point(810,15));            

            // Create tank1
            Actor tank1 = new Actor();
            tank1.SetPosition(new Point(30,300));
            tank1.SetVelocity(new Point(0,0));
            tank1.SetText("#");
            tank1.SetColor(Constants.WHITE);
            tank1.SetFontSize(Constants.FONT_SIZE);

            // Create tank2
            Actor tank2 = new Actor();
            tank2.SetPosition(new Point(870,300));
            tank2.SetVelocity(new Point(0,0));
            tank2.SetText("#");
            tank2.SetColor(Constants.WHITE);
            tank2.SetFontSize(Constants.FONT_SIZE);

            // Create player 1 bullet
            Actor bullet1 = new Actor();
            bullet1.SetVelocity(new Point(0,0));
            bullet1.SetColor(Constants.HEAVY_ORANGE);
            bullet1.SetFontSize(Constants.FONT_SIZE);

            // Create player 2 bullet
            Actor bullet2 = new Actor();
            bullet2.SetVelocity(new Point(0,0));
            bullet2.SetColor(Constants.LIGHT_BLUE);
            bullet2.SetFontSize(Constants.FONT_SIZE);

            // Create all the walls/levels
            Levels levels = new Levels(cast);

            cast.AddActor("tank1", tank1);
            cast.AddActor("tank2", tank2);
            cast.AddActor("bullet1", bullet1);
            cast.AddActor("bullet2", bullet2);
            cast.AddActor("score1", score1);
            cast.AddActor("score2", score2);
            cast.AddActor("lives1", lives1);
            cast.AddActor("lives2", lives2);


            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
            
            ControlActorsAction controlActorsAction = new ControlActorsAction(keyboardService);
            MoveActorsAction moveActorsAction = new MoveActorsAction();
            HandleCollisionsAction handleCollisionsAction = new HandleCollisionsAction();
            CollideBorderAction collideBorderAction = new CollideBorderAction();
            CollideTankAction collideTankAction = new CollideTankAction();
            CollideWallAction collideWallAction = new CollideWallAction();
            DrawActorsAction drawActorsAction = new DrawActorsAction(videoService);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", controlActorsAction);
            script.AddAction("update", moveActorsAction);
            // script.AddAction("update", handleCollisionsAction);
            script.AddAction("update", collideBorderAction);
            script.AddAction("update", collideTankAction);
            script.AddAction("update", collideWallAction);
            script.AddAction("output", drawActorsAction);

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}