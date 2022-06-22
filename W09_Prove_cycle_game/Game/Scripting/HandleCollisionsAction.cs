using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using W09_Prove_cycle_game.Game.Casting;
using W09_Prove_cycle_game.Game.Services;


namespace W09_Prove_cycle_game.Game.Scripting
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
        public bool isGameOver = false;
        private bool winnerIs1 = false;
        private bool winnerTie = false;
        public ControlActorsAction controlActorsAction;


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
                HandleSegmentCollisions(cast);
                HandleSnakeCollision(cast);
                HandleGameOver(cast);
                // HandleRestart(cast);
            }

            else if (isGameOver == true)
            {
            //     HandleGameOver(cast);
                HandleRestart(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        public void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();
            Score score = (Score)cast.GetFirstActor("score");

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();
            Score score1 = (Score)cast.GetFirstActor("score1");

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head.GetPosition()))
                {
                    snake.GrowTail(Constants.WHITE);
                    score1.AddPoints(1);
                    isGameOver = true;
                    winnerIs1 = true;
                }
            }

            foreach (Actor segment1 in body1)
            {
                if (segment1.GetPosition().Equals(head1.GetPosition()))
                {
                    snake1.GrowTail(Constants.WHITE);
                    score.AddPoints(1);
                    isGameOver = true;
                    winnerIs1 = false;
                }
            }

            score.DisplayPoints("Player 1");
            score1.DisplayPoints("Player 2");
        }


        public void HandleSnakeCollision(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head = snake.GetHead();
            List<Actor> body = snake.GetBody();
            Score score = (Score)cast.GetFirstActor("score");

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();
            Score score1 = (Score)cast.GetFirstActor("score1");

            if (head.GetPosition().Equals(head1.GetPosition()))
            {
                isGameOver = true;
                winnerTie = true;
            }

            foreach (Actor segment in body)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    winnerIs1 = false;
                    score.AddPoints(1);
                    snake.GrowTail(Constants.HEAVY_ORANGE);
                    snake1.GrowTail(Constants.WHITE);
                }
            }

            foreach (Actor segment1 in body1)
            {
                if (segment1.GetPosition().Equals(head.GetPosition()))
                {
                    isGameOver = true;
                    winnerIs1 = true;
                    score1.AddPoints(1);
                    snake.GrowTail(Constants.WHITE);
                    snake1.GrowTail(Constants.LIGHT_BLUE);
                }
            } 

            score.DisplayPoints("Player 1");
            score1.DisplayPoints("Player 2");           
        }
        
        public void HandleGameOver(Cast cast)
        {   
            if (isGameOver == true && winnerIs1 == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");
        
                List<Actor> segments = snake.GetSegments();
                List<Actor> segments1 = snake1.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Player 2 won!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }

            else if (isGameOver == true && winnerIs1 == false)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");

                List<Actor> segments1 = snake1.GetSegments();

                // create a "game over" message
                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Player 1 won!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }              
        }

        public void HandleRestart(Cast cast)
        {
            isGameOver = false;
            winnerIs1 = false;

            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor message = (Actor)cast.GetFirstActor("messages");
            snake.TurnHead(new Point(15, 0));

            // Uncommenting this causes game to run once and then close.
            // controlActorsAction.direction = new Point(15, 0);
            // controlActorsAction.direction1 = new Point(-15, 0);

            Thread.Sleep(2000);
            message.SetText("");
            message.SetPosition(new Point(0,0));
            cast.RemoveActor("messages", message);

            cast.RemoveActor("snake", snake);
            cast.RemoveActor("snake1", snake1);

            snake = new Snake(Constants.SNAKE_INT_POS, Constants.HEAVY_ORANGE, Constants.SNAKE_INT_VEL);
            snake1 = new Snake(Constants.SNAKE1_INT_POS, Constants.LIGHT_BLUE, Constants.SNAKE1_INT_VEL);

            Point vel = new Point(15, 0);
            Actor head = snake.GetHead();
            head.SetVelocity(vel);

            cast.AddActor("snake", snake);
            cast.AddActor("snake1", snake1);
            
        }


    }
}