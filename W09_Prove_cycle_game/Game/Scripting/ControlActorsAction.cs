using W09_Prove_cycle_game.Game.Casting;
using W09_Prove_cycle_game.Game.Services;
using W09_Prove_cycle_game.Game.Scripting;


namespace W09_Prove_cycle_game.Game.Scripting
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
        private HandleCollisionsAction handle;
        public Point direction = new Point(Constants.CELL_SIZE, 0);
        public Point direction1 = new Point(-Constants.CELL_SIZE, 0);
        private bool keyDown = false;
        private bool gameOver = false;

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
            // Point direction = new Point(Constants.CELL_SIZE, 0);
            // Point direction1 = new Point(-Constants.CELL_SIZE, 0);

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
                keyDown = true;
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("s"))
            {
                keyDown = true;
                direction = new Point(0, Constants.CELL_SIZE);
            }

            // left
            if (keyboardService.IsKeyDown("j"))
            {
                keyDown = true;
                direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                keyDown = true;
                direction1 = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                keyDown = true;
                direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                keyDown = true;
                direction1 = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake = (Snake)cast.GetFirstActor("snake");
            snake.TurnHead(direction);
            snake.GrowTail(Constants.HEAVY_ORANGE);

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            snake1.TurnHead(direction1);
            snake1.GrowTail(Constants.LIGHT_BLUE);
        
            // if (handle.isGameOver == true)
            // {
            //     direction = new Point(15, 0);
            //     direction1 = new Point(-15, 0);
            // }
        }
    }
}