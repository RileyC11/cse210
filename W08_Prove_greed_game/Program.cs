using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using W08_Prove_greed_game.Game.Casting;
using W08_Prove_greed_game.Game.Directing;
using W08_Prove_greed_game.Game.Services;


namespace W08_Prove_greed_game
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
        private static string CAPTION = "Greed";
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ROCKS = 20;
        private static int DEFAULT_GEMS = 20;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();

            // create the banner
            Actor banner = new Actor();
            banner.SetText("Score: 0");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            // create the robot
            Actor robot = new Actor();
            robot.SetText("#");
            robot.SetFontSize(FONT_SIZE);
            robot.SetColor(WHITE);
            robot.SetPosition(new Point(MAX_X / 2, MAX_Y - 15));
            cast.AddActor("robot", robot);

            // create the rocks
            Random random = new Random();
            for (int i = 0; i < DEFAULT_ROCKS; i++)
            {
                string text = "o";
                int score = -100;
                int dx = 0;
                int dy = 1;

                Point direction = new Point(dx, dy);
                direction = direction.Scale(CELL_SIZE);
                Point velocity = direction;

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetScore(score);
                artifact.SetVelocity(velocity);
                cast.AddActor("artifacts", artifact);
            }

            // create the gems
            for (int i = 0; i < DEFAULT_GEMS; i++)
            {
                string text = "*";
                int score = 100;
                int dx = 0;
                int dy = 1;

                Point direction = new Point(dx, dy);
                direction = direction.Scale(CELL_SIZE);
                Point velocity = direction;

                int x = random.Next(1, COLS);
                int y = random.Next(1, ROWS);
                Point position = new Point(x, y);
                position = position.Scale(CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Artifact artifact = new Artifact();
                artifact.SetText(text);
                artifact.SetFontSize(FONT_SIZE);
                artifact.SetColor(color);
                artifact.SetPosition(position);
                artifact.SetScore(score);
                artifact.SetVelocity(velocity);
                cast.AddActor("artifacts", artifact);
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