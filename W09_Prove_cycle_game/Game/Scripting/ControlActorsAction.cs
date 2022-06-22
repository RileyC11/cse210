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
        // Keeping this uncommented and the below one commented is that this one stores the heads last direction,
        //  meaning that it stores the value for the last respective key pressed. HOW WOULD YOU GO ABOUT RESETTING
        //  THE direction and direction1 HERE?? WOULD YOU UPDATE IT IN ANOTHER CLASS SINCE THIS IN CONSIDERED AN 
        //  INPUT CLASS IN PROGRAM AND THUS HAS TO BE UPDATED BY THE OTHER TWO OUTPUT CLASSES??
        // If you keep the values private, then they can't be updated in other class. Thus, the attempt to update them
        //  in HandleRestart() in HandleCollisionsAction class is impossible. Therefore, you have to make them public 
        //  variables.
        public Point direction = new Point(Constants.CELL_SIZE, 0);
        public Point direction1 = new Point(-Constants.CELL_SIZE, 0);
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
            // Uncommenting this and commenting the above direction and direction1 causes the user to have to 
            //  hold down the key to continue in that direction. Then when the game restarts, they start with
            //  the initial velocities they should have of (15, 0) and (-15, 0).
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

            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            snake1.TurnHead(direction1);

            // uncommenting this causes white screen
            // if (handle.isGameOver == true)
            // {
            //     direction = new Point(15, 0);
            //     direction1 = new Point(-15, 0);
            // }
        }
    }
}