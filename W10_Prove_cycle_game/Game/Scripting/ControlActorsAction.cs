using W10_Prove_cycle_game.Game.Casting;
using W10_Prove_cycle_game.Game.Services;
using W10_Prove_cycle_game.Game.Scripting;


namespace W10_Prove_cycle_game.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Actions
    {
        private KeyboardService keyboardService;
        public Point direction1 = new Point(Constants.CELL_SIZE, 0);
        public Point direction2 = new Point(-Constants.CELL_SIZE, 0);

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
            // Uncommenting this and commenting the above direction and direction1 causes the user to have to 
            //  hold down the key to continue in that direction. Then when the game restarts, they start with
            //  the initial velocities they should have of (15, 0) and (-15, 0).
            // Point direction1 = new Point(Constants.CELL_SIZE, 0);
            // Point direction2 = new Point(-Constants.CELL_SIZE, 0);

            // left player 1
            if (keyboardService.IsKeyDown("a"))
            {
                direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right player 1
            if (keyboardService.IsKeyDown("d"))
            {
                direction1 = new Point(Constants.CELL_SIZE, 0);

            }

            // up player 1
            if (keyboardService.IsKeyDown("w"))
            {
                direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down player 1
            if (keyboardService.IsKeyDown("s"))
            {
                direction1 = new Point(0, Constants.CELL_SIZE);
            }

            // left player 2
            if (keyboardService.IsKeyDown("j"))
            {
                direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right player 2
            if (keyboardService.IsKeyDown("l"))
            {
                direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up player 2
            if (keyboardService.IsKeyDown("i"))
            {
                direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down player 2
            if (keyboardService.IsKeyDown("k"))
            {
                direction2 = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            snake1.TurnHead(direction1);

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            snake2.TurnHead(direction2);
        }
    }
}