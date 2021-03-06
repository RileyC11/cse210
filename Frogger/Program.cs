using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Frogger.Game.Casting;
using Frogger.Game.Directing;
using Frogger.Game.Services;
using Frogger.Game.Scripting;


namespace Frogger
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
            // Create the cast.
            Cast cast = new Cast();

            // Create the frog.
            // Frog frog = new Frog();
            cast.AddActor("frog", new Frog());
            

            // Create the logs.
            Logs logs = new Logs();
            cast.AddActor("logs", logs);

            // Create the cars.
            // Cars cars = new Cars();
            // cast.AddActor("cars", cars);

            Random random = new Random();
            int ymin = random.Next(0,39);
            for (int i = 0; i < Constants.CARS; i++)
            {
                string text = "8--8";
                int fontSize = Constants.FONT_SIZE;
                Color color = Constants.WHITE;

                Point velocity = new Point(5,0); 

                
                int x = random.Next(0,60) * Constants.CELL_SIZE;
                
                int y = random.Next(ymin,ymin+5) * Constants.CELL_SIZE;
                Point position = new Point(x,y);

                Actor car = new Actor();
                car.SetPosition(position);
                car.SetVelocity(velocity);
                car.SetText(text);
                car.SetFontSize(fontSize);
                car.SetColor(color);
                cast.AddActor("cars", car);
            }

            // Create the banner.
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(Constants.FONT_SIZE);
            banner.SetColor(Constants.WHITE);
            banner.SetPosition(new Point(Constants.CELL_SIZE, 0));
            cast.AddActor("banner", banner);     

            // Create services.
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            // Create the script.
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // Start the game.
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}