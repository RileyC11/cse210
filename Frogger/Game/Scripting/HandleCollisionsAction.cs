using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using Frogger.Game.Casting;
using Frogger.Game.Services;
using Raylib_cs;


namespace Frogger.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        public static bool isGameOver = false;
        public static bool winnerIs1 = false;
        public static bool tie = false;
        public static bool restartGame = false;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
             if (isGameOver == false)
            {
                HandleLogCollision(cast);
                HandleCarCollision(cast);
            }
            else if (isGameOver == true)
            {
                HandleGameOver(cast);
            }

        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        public void HandleLogCollision(Cast cast)
        {
            Frog frog = (Frog)cast.GetFirstActor("frog");

            Logs logs = (Logs)cast.GetFirstActor("logs");
            List<Actor> logsList = logs.GetLogs();

            int frogX = frog.GetPosition().GetX();
            int frogY = frog.GetPosition().GetY();
            Rectangle frogRectangle = new Rectangle(frogX, frogY, Constants.CELL_SIZE, Constants.CELL_SIZE);

            // Condition if frog hops onto a log.
            foreach (Actor log in logsList)
            {
                Point logVelocity = log.GetVelocity();

                int logX = log.GetPosition().GetX();
                int logY = log.GetPosition().GetY();
                Rectangle logRectangle = new Rectangle(logX, logY, 30, 15);

                if (Raylib.CheckCollisionRecs(frogRectangle, logRectangle))
                {
                    frog.SetVelocity(logVelocity);
                }
            }
        }


        public void HandleCarCollision(Cast cast)
        {
            Frog frog = (Frog)cast.GetFirstActor("frog");

            Cars cars = (Cars)cast.GetFirstActor("cars");
            List<Actor> carsList = cars.GetCars();

            int frogX = frog.GetPosition().GetX();
            int frogY = frog.GetPosition().GetY();
            Rectangle frogRectangle = new Rectangle(frogX, frogY, Constants.CELL_SIZE, Constants.CELL_SIZE);

            // Condition if frog is hit by a car.
            foreach (Actor car in carsList)
            {
                Point carVelocity = car.GetVelocity();

                int carX = car.GetPosition().GetX();
                int carY = car.GetPosition().GetY();
                Rectangle carRectangle = new Rectangle(carX, carY, 30, 15);

                if (Raylib.CheckCollisionRecs(frogRectangle, carRectangle))
                {
                    frog.SetVelocity(carVelocity);
                    isGameOver = true;
                }
            }
        }
        
        public void HandleGameOver(Cast cast)
        {   
            Frog frog = (Frog)cast.GetFirstActor("frog");

            Logs logs = (Logs)cast.GetFirstActor("logs");
            List<Actor> logsList = logs.GetLogs();

            Cars cars = (Cars)cast.GetFirstActor("cars");
            List<Actor> carsList = cars.GetCars();

            int x = Constants.MAX_X / 2;
            int y = 0;
            Point position = new Point(x, y);


            // Condition for game over.
            if (isGameOver == true)
            {
                // Create a "game over" message at center of the top of screen.
                Actor banner = new Actor();
                banner.SetText("Game Over!");
                banner.SetPosition(position);
                cast.AddActor("banner", banner);
                
                // Make everything white
                frog.SetColor(Constants.WHITE);

                foreach (Actor log in logsList)
                {
                    log.SetColor(Constants.WHITE);
                }

                foreach (Actor car in carsList)
                {
                    car.SetColor(Constants.WHITE);
                }
            }
        }
    }
}