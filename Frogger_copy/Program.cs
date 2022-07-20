using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Frogger_copy.Game.Casting;
using Frogger_copy.Game.Directing;
using Frogger_copy.Game.Services;


namespace Frogger_copy
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Frogger";
        private static Color WHITE = new Color(255,255,255);
        private static Color BROWN = new Color(150,75,0);
        private static Color RED = new Color(255,0,0);
        private static Color GREEN = new Color(144,238,144);
        private static int DEFAULT_CARS = 20;
        private static int DEFAULT_LOGS = 20;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor totalScore = new Actor();
            totalScore.SetText("Score: 0");
            totalScore.SetFontSize(FONT_SIZE);
            totalScore.SetColor(WHITE);
            totalScore.SetPosition(new Point(0,0));
            cast.AddActor("score", totalScore);

            // Create the level
            Actor level = new Actor();
            level.SetText("Level: 0");
            level.SetFontSize(FONT_SIZE);
            level.SetColor(WHITE);
            level.SetPosition(new Point(0, 30));
            cast.AddActor("level", level);


            // create the frog
            Actor frog = new Actor();
            frog.SetText("#");
            frog.SetFontSize(FONT_SIZE);
            frog.SetColor(GREEN);
            frog.SetPosition(new Point(MAX_X / 2, MAX_Y - 15));
            cast.AddActor("frog", frog);

            // create the cars
            Random random = new Random();
            int ymin = random.Next(0,39);
            for (int i = 0; i < DEFAULT_CARS; i++)
            {
                string text = "8--8";
                int points = -100;
                int dx = 5;
                int dy = 0;

                Point velocity = new Point(dx, dy);

                int x = random.Next(0,60) * CELL_SIZE;
                int y = random.Next(ymin,ymin+5) * CELL_SIZE;
                Point position = new Point(x,y);

                Artifact car = new Artifact();
                car.SetText(text);
                car.SetFontSize(FONT_SIZE);
                car.SetColor(RED);
                car.SetPosition(position);
                car.SetScore(points);
                car.SetVelocity(velocity);
                cast.AddActor("cars", car);
            }

            // create the logs
            int yminLogs = random.Next(0,39);
            for (int i = 0; i < DEFAULT_LOGS; i++)
            {
                string text = "[][][]";
                int points = 100;
                int dx = 5;
                int dy = 0;

                // use the scale factor to decide how many pixels they move which changes velocity

                // Point direction = new Point(dx, dy);
                // direction = direction.Scale(CELL_SIZE);

                Point direction = new Point(dx, dy);
                Point velocity = direction;

                int x = random.Next(0,60) * CELL_SIZE;
                int y = random.Next(yminLogs,yminLogs+5) * CELL_SIZE;
                Point position = new Point(x,y);

                Artifact log = new Artifact();
                log.SetText(text);
                log.SetFontSize(FONT_SIZE);
                log.SetColor(BROWN);
                log.SetPosition(position);
                log.SetScore(points);
                log.SetVelocity(velocity);
                cast.AddActor("logs", log);
            }            

            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);

            // test comment
        }
    }
}