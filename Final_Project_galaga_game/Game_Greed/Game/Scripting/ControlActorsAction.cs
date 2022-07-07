using FINAL_Project_galaga_game.Game.Casting;
using FINAL_Project_galaga_game.Game.Services;
using FINAL_Project_galaga_game.Game.Scripting;


namespace FINAL_Project_galaga_game.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Operation
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

            Actor ship = (Actor)cast.GetFirstActor("ship");
            ship.SetVelocity(direction1);
            
        }
    }
}