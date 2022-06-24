using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using W09_Prove_cycle_game.Game.Casting;
using W09_Prove_cycle_game.Game.Services;
using W09_Prove_cycle_game.Game.Scripting;


namespace W09_Prove_cycle_game.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class  RestartGame : Action
    {
        private HandleCollisionsAction handleCollisionsAction;
        private ControlActorsAction ControlActorsAction;
        private bool isGameOver = false;
        private bool winnerIs1 = false;
        private bool winnerTie = false;
        private bool restart = false;
        public RestartGame(HandleCollisionsAction handleCollisionsAction, ControlActorsAction controlActorsAction)
        {   
            this.handleCollsionsAction = handleCollisionsAction;
            this.controlActorsAction = controlActorsAction;
            // this.isGameOver = handle.isGameOver;
            // this.winnerIs1 = handle.winnerIs1;
            // this.winnerTie = handle.winnerTie;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            this.isGameOver = handle.isGameOver;
            this.winnerIs1 = handle.winnerIs1;
            this.winnerTie = handle.winnerTie;
            HandleGameOver(cast);
            HandleRestart(cast);
        }

        public void HandleGameOver(Cast cast)
        {   
            // this.isGameOver = handle.isGameOver;
            // this.winnerIs1 = handle.winnerIs1;
            // this.winnerTie = handle.winnerTie;
           
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

                restart = true;
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

                restart = true;
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

                restart = true;
            }
        }

        public void HandleRestart(Cast cast)
        {
            if (restart == true)
            {
                isGameOver = false;
                winnerIs1 = false;
                winnerTie = false;

                Snake snake1 = (Snake)cast.GetFirstActor("snake1");
                Snake snake2 = (Snake)cast.GetFirstActor("snake2");
                Actor message = (Actor)cast.GetFirstActor("messages");
                snake1.TurnHead(new Point(15, 0));

                Thread.Sleep(2000);
                message.SetText("");
                message.SetPosition(new Point(0,0));
                cast.RemoveActor("messages", message);

                cast.RemoveActor("snake1", snake1);
                cast.RemoveActor("snake2", snake2);

                snake1 = new Snake(Constants.SNAKE1_INT_POS, Constants.HEAVY_ORANGE, Constants.SNAKE1_INT_VEL);
                snake2 = new Snake(Constants.SNAKE2_INT_POS, Constants.LIGHT_BLUE, Constants.SNAKE2_INT_VEL);

                cast.AddActor("snake1", snake1);
                cast.AddActor("snake2", snake2);
            }
            
        }
    }
}