using W09_Prove_tron_game.Game.Casting;
using W09_Prove_tron_game.Game.Services;


namespace W09_Prove_tron_game.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(0, -Constants.CELL_SIZE);
        private Point directionOne = new Point(0, -Constants.CELL_SIZE);
        private bool keyDown = false;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
                keyDown = true;
            }

            // right
            if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
                keyDown = true;
            }

            // up
            if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
                keyDown = true;
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
                keyDown = true;
            }

            // left
            if (keyboardService.IsKeyDown("j"))
            {
                directionOne = new Point(-Constants.CELL_SIZE, 0);
                keyDown = true;
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                directionOne = new Point(Constants.CELL_SIZE, 0);
                keyDown = true;
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                directionOne = new Point(0, -Constants.CELL_SIZE);
                keyDown = true;
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                directionOne = new Point(0, Constants.CELL_SIZE);
                keyDown = true;
            }

            // while (keyDown == false)
            // {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                snake.TurnHead(direction);
                snake.GrowTail(cast);
                Snake snakeOne = (Snake)cast.GetFirstActor("snake1");
                snakeOne.TurnHead(directionOne);
            // }
            
        }
    }
}