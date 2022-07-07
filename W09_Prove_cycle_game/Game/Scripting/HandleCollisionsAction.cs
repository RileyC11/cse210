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
                HandleSegmentCollisions(cast);
                HandleSnakeCollision(cast);
            }
            else if (isGameOver == true)
            {
                HandleGameOver(cast);
                //HandleRestart(cast);
            }

        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        public void HandleSegmentCollisions(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();
            Score score1 = (Score)cast.GetFirstActor("score1");

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            List<Actor> body2 = snake2.GetBody();
            Score score2 = (Score)cast.GetFirstActor("score2");

            // condition if player 1 runs into themselves
            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    score2.AddPoints(1);
                    isGameOver = true;
                    winnerIs1 = false;
                }
            }

            //  condition if player 2 runs into themselves
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    score1.AddPoints(1);
                    isGameOver = true;
                    winnerIs1 = true;
                }
            }

            score1.DisplayPoints("Player 1");
            score2.DisplayPoints("Player 2");
        }


        public void HandleSnakeCollision(Cast cast)
        {
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();
            Score score1 = (Score)cast.GetFirstActor("score1");

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            List<Actor> body2 = snake2.GetBody();
            Score score2 = (Score)cast.GetFirstActor("score2");

            // condition for heads colliding (tie)
            if (head1.GetPosition().Equals(head2.GetPosition()))
            {
                isGameOver = true;
                tie = true;
            }

            else
            {
                // condition for Player 1 running into Player 2
                foreach (Actor segment in body2)
                {
                    if (segment.GetPosition().Equals(head1.GetPosition()))
                    {
                        isGameOver = true;
                        winnerIs1 = false;
                        score2.AddPoints(1);
                   }
                }

                // condition for Player 2 running into Player 1
                foreach (Actor segment in body1)
                {
                    if (segment.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        winnerIs1 = true;
                        score1.AddPoints(1);
                    }
                } 
            }
            
            score1.DisplayPoints("Player 1");
            score2.DisplayPoints("Player 2");           
        }
        
        public void HandleGameOver(Cast cast)
        {   
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            List<Actor> segments1 = snake1.GetSegments();

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            List<Actor> segments2 = snake2.GetSegments();

            int x = Constants.MAX_X / 2;
            int y = 0;
            Point position = new Point(x, y);


            // condition for game over, Player 1 won, and it isn't a tie
            if (isGameOver == true && winnerIs1 == true && tie == false)
            {
                // create a "game over" message at center of the top of screen
                Actor message = new Actor();
                message.SetText("Player 1 won!");
                message.SetPosition(position);
                cast.AddActor("messages", message);
                
                // make everything white for Player 2
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }

            // condition for game over, Player 2 won, and it isn't a tie
            else if (isGameOver == true && winnerIs1 == false && tie == false)
            {
                // create a "game over" message at center of the top of screen
                Actor message = new Actor();
                message.SetText("Player 2 won!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white for Player 1
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
            
            // condition for game over and it is a tie
            else if (isGameOver == true && tie == true)
            {
                // create a "game over" message at center of the top of screen
                Actor message = new Actor();
                message.SetText("Tie!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make everything white for Player 1
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }

                // make everything white for Player 2                
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
            restartGame = true;
        }

        // public void HandleRestart(Cast cast)
        // {
        //     isGameOver = false;
        //     winnerIs1 = false;
        //     tie = false;

        //     Snake snake1 = (Snake)cast.GetFirstActor("snake1");
        //     Snake snake2 = (Snake)cast.GetFirstActor("snake2");
        //     Actor message = (Actor)cast.GetFirstActor("messages");

        //     // Thread.Sleep(2000);
        //     cast.RemoveActor("snake1", snake1);
        //     cast.RemoveActor("snake2", snake2);
        //     cast.RemoveActor("messages", message);

        //     snake1 = new Snake(Constants.SNAKE1_INT_POS, Constants.HEAVY_ORANGE, Constants.SNAKE1_INT_VEL);
        //     snake2 = new Snake(Constants.SNAKE2_INT_POS, Constants.LIGHT_BLUE, Constants.SNAKE2_INT_VEL);

        //     Point vel = new Point(15, 0);
        //     Actor head1 = snake1.GetHead();
        //     head1.SetVelocity(vel);

        //     cast.AddActor("snake1", snake1);
        //     cast.AddActor("snake2", snake2);

        //     Constants.direction1 = new Point(15, 0);
        //     Constants.direction2 = new Point(-15, 0);
        // }
    }
}