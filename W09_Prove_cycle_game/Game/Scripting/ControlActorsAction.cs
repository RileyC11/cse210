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
        public static Point direction1 = new Point(0, 0);
        public static Point direction2 = new Point(0, 0);

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
            direction1 = Constants.direction1;
            direction2 = Constants.direction2;

            // left player 1
            if (keyboardService.IsKeyDown("a"))
            {
                Constants.direction1 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right player 1
            if (keyboardService.IsKeyDown("d"))
            {
                Constants.direction1 = new Point(Constants.CELL_SIZE, 0);

            }

            // up player 1
            if (keyboardService.IsKeyDown("w"))
            {
                Constants.direction1 = new Point(0, -Constants.CELL_SIZE);
            }

            // down player 1
            if (keyboardService.IsKeyDown("s"))
            {
                Constants.direction1 = new Point(0, Constants.CELL_SIZE);
            }

            // left player 2
            if (keyboardService.IsKeyDown("j"))
            {
               Constants.direction2 = new Point(-Constants.CELL_SIZE, 0);
            }

            // right player 2
            if (keyboardService.IsKeyDown("l"))
            {
                Constants.direction2 = new Point(Constants.CELL_SIZE, 0);
            }

            // up player 2
            if (keyboardService.IsKeyDown("i"))
            {
                Constants.direction2 = new Point(0, -Constants.CELL_SIZE);
            }

            // down player 2
            if (keyboardService.IsKeyDown("k"))
            {
                Constants.direction2 = new Point(0, Constants.CELL_SIZE);
            }

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            Actor head1 = snake1.GetHead();
            snake1.lastHead1 = head1.GetPosition();
            snake1.TurnHead(direction1);

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            Actor head2 = snake2.GetHead();
            snake2.lastHead2 = head2.GetPosition();
            snake2.TurnHead(direction2);
        }
    }
}