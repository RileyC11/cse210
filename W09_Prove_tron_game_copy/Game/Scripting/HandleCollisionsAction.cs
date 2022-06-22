using System;
using System.Collections.Generic;
using System.Data;
using W09_Prove_tron_game.Game.Casting;
using W09_Prove_tron_game.Game.Services;


namespace W09_Prove_tron_game.Game.Scripting
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
        private bool isGameOver = false;
        private bool winnerIs1 = false;

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
                // HandleFoodCollisions(cast);
                HandleSegmentCollisions(cast);
                HandleSnakeCollision(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score nd moves the food if the snake collides with it.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        // private void HandleFoodCollisions(Cast cast)
        // {
        //     Snake snake = (Snake)cast.GetFirstActor("snake");
        //     Snake snake1 = (Snake)cast.GetFirstActor("snake1");
        //     Score score = (Score)cast.GetFirstActor("score");
        //     Score score1 = (Score)cast.GetFirstActor("score1");
        //     Food food = (Food)cast.GetFirstActor("food");
            
        //     if (snake.GetHead().GetPosition().Equals(food.GetPosition()))
        //     {
        //         int points = food.GetPoints();
        //         snake.GrowTail(points);
        //         score.AddPoints(points);
        //         food.Reset();

        //         List<Actor> segments = snake.GetSegments();
        //         int totalSegments = segments.Count;
        //         int startSeg = totalSegments - points;
        //         int stopSeg = totalSegments - 1;

        //         // Random random = new Random();
        //         // int r = random.Next(256);
        //         // int g = random.Next(256);
        //         // int b = random.Next(256);
        //         // Color color = new Color(r, g, b);

        //         for (int i = startSeg; i <= stopSeg; i++)
        //         {
        //             segments[i].SetColor(Constants.HEAVY_ORANGE);
        //         }                
        //     }
        //     else if (snake1.GetHead().GetPosition().Equals(food.GetPosition()))
        //     {
        //         int points = food.GetPoints();
        //         snake1.GrowTail(points);
        //         score1.AddPoints(points);
        //         food.Reset();

        //         List<Actor> segments1 = snake1.GetSegments();
        //         int totalSegments = segments1.Count;
        //         int startSeg = totalSegments - points;
        //         int stopSeg = totalSegments - 1;

        //         // Random random = new Random();
        //         // int r = random.Next(256);
        //         // int g = random.Next(256);
        //         // int b = random.Next(256);
        //         // Color color = new Color(r, g, b);

        //         for (int i = startSeg; i <= stopSeg; i++)
        //         {
        //             segments1[i].SetColor(Constants.LIGHT_BLUE);
        //         }
        //     }
        // }
        
        // private void HandleTime(Cast cat)
        // {
        //     Snake snake = 
        // }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head = snake.GetHead();
            Actor head1 = snake1.GetHead();
            List<Actor> body = snake.GetBody();
            List<Actor> body1 = snake1.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    winnerIs1 = true;
                }
            }

            foreach (Actor segment1 in body1)
            {
                if (segment1.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    winnerIs1 = false;
                }
            }
        }

        private void HandleSnakeCollision(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head = snake.GetHead();
            Actor head1 = snake1.GetHead();
            List<Actor> body = snake.GetBody();
            List<Actor> body1 = snake1.GetBody();

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    winnerIs1 = false;
                }
            }

            foreach (Actor segment1 in body1)
            {
                if (segment1.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    winnerIs1 = true;
                }
            }            
        }
        
        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true && winnerIs1 == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");

                List<Actor> segments = snake.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
            }

            else if (isGameOver == true && winnerIs1 == false)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");

                List<Actor> segments1 = snake1.GetSegments();
                Food food = (Food)cast.GetFirstActor("food");

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }
                food.SetColor(Constants.WHITE);
            }            
        }

    }
}