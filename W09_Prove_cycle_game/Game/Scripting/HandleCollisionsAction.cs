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
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();
            Score score1 = (Score)cast.GetFirstActor("score1");

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            List<Actor> body2 = snake2.GetBody();
            Score score2 = (Score)cast.GetFirstActor("score2");

            //  condition if player 1 runs into themselves
            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    // snake1.GrowTail(Constants.WHITE);
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
                    // snake2.GrowTail(Constants.WHITE);
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
                winnerTie = true;
            }

            // condition for Player 1 running into Player 2
            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    winnerIs1 = false;

                    score2.AddPoints(1);
                    // snake2.GrowTail(Constants.LIGHT_BLUE);

                    // snake1.GrowTail(Constants.WHITE);
                    head1.SetColor(Constants.WHITE);
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
                    // snake1.GrowTail(Constants.HEAVY_ORANGE);

                    // snake2.GrowTail(Constants.WHITE);
                    head2.SetColor(Constants.WHITE);
                }
            } 

            score1.DisplayPoints("Player 1");
            score2.DisplayPoints("Player 2");           
        }
        
        public void HandleGameOver(Cast cast)
        {   
            // condition for game over, Player 1 won, and it isn't a tie
            if (isGameOver == true && winnerIs1 == true && winnerTie == false)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");
                List<Actor> segments1 = snake1.GetSegments();

                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments2 = snake2.GetSegments();

                // create a "game over" message at center of the top of screen
                int x = Constants.MAX_X / 2;
                int y = 0;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Player 1 won!");
                message.SetPosition(position);
                cast.AddActor("messages", message);
                
                // make Player 2's head white
                Actor head2 = snake2.GetHead();
                head2.SetColor(Constants.WHITE);

                // make everything white for Player 2
                foreach (Actor segment in segments2)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }

            // condition for game over, Player 2 won, and it isn't a tie
            else if (isGameOver == true && winnerIs1 == false && winnerTie == false)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");
                List<Actor> segments1 = snake1.GetSegments();

                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments2 = snake2.GetSegments();

                // create a "game over" message at center of the top of screen
                int x = Constants.MAX_X / 2;
                int y = 0;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Player 2 won!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                // make Player 1's head white
                Actor head1 = snake1.GetHead();
                head1.SetColor(Constants.WHITE);

                // make everything white for Player 1
                foreach (Actor segment in segments1)
                {
                    segment.SetColor(Constants.WHITE);
                }
            }
            
            // condition for game over and it is a tie
            else if (isGameOver == true && winnerTie == true)
            {
                Snake snake1 = (Snake)cast.GetFirstActor("snake1");
                List<Actor> segments1 = snake1.GetSegments();

                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                List<Actor> segments2 = snake2.GetSegments();

                // create a "game over" message at center of the top of screen
                int x = Constants.MAX_X / 2;
                int y = 0;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Tie!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                Actor head1 = snake1.GetHead();
                Actor head2 = snake2.GetHead();

                // make both player's heads white
                head1.SetColor(Constants.WHITE);                
                head2.SetColor(Constants.WHITE);

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
        }

        public void HandleRestart(Cast cast)
        {
            isGameOver = false;
            winnerIs1 = false;
            winnerTie = false;

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor message = (Actor)cast.GetFirstActor("messages");
            snake1.TurnHead(new Point(15, 0));

            // Uncommenting this causes game to run once and then close.
            // controlActorsAction.direction = new Point(15, 0);
            // controlActorsAction.direction1 = new Point(-15, 0);

            Thread.Sleep(2000);
            message.SetText("");
            message.SetPosition(new Point(0,0));
            cast.RemoveActor("messages", message);

            cast.RemoveActor("snake1", snake1);
            cast.RemoveActor("snake2", snake2);

            snake1 = new Snake(Constants.SNAKE1_INT_POS, Constants.HEAVY_ORANGE, Constants.SNAKE1_INT_VEL);
            snake2 = new Snake(Constants.SNAKE2_INT_POS, Constants.LIGHT_BLUE, Constants.SNAKE2_INT_VEL);

            Point vel = new Point(15, 0);
            Actor head1 = snake1.GetHead();
            head1.SetVelocity(vel);

            cast.AddActor("snake1", snake1);
            cast.AddActor("snake2", snake2);
            
        }


    }
}