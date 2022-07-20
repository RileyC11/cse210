using W12_Final_tanks_game.Game.Casting;
using W12_Final_tanks_game.Game.Services;
using W12_Final_tanks_game.Game.Scripting;
using System;

// Want to create a constant for the level number and use that for which walls to load
namespace W12_Final_tanks_game.Game.Scripting
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
        // public static Point velP1 = new Point(0,0);
        // public static Point velP2 = new Point(0,0);
        public static Point velB1 = new Point(0,0);
        public static Point velB2 = new Point(0,0);

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
            // Allows me to press the key and only move one space
            Point velP1 = new Point(0,0);
            Point velP2 = new Point(0,0);

            Actor tank1 = (Actor)cast.GetFirstActor("tank1");
            Actor tank2 = (Actor)cast.GetFirstActor("tank2");
            Actor bullet1 = (Actor)cast.GetFirstActor("bullet1");
            Actor bullet2 = (Actor)cast.GetFirstActor("bullet2");

            Point pos1 = tank1.GetPosition();
            Point pos2 = tank2.GetPosition();


            // left player 1
            if (keyboardService.IsKeyDown("a"))
            {
                velP1 = new Point(-Constants.CELL_SIZE, 0);
            }
            // right player 1
            if (keyboardService.IsKeyDown("d"))
            {
                velP1 = new Point(Constants.CELL_SIZE, 0);
            }
            // up player 1
            if (keyboardService.IsKeyDown("w"))
            {
                velP1 = new Point(0, -Constants.CELL_SIZE);
            }
            // down player 1
            if (keyboardService.IsKeyDown("s"))
            {
                velP1 = new Point(0, Constants.CELL_SIZE);
            }
            // left player 1 bullet
            if (keyboardService.IsKeyDown("j"))
            {
                bullet1.SetText("-");
                bullet1.SetPosition(pos1);
                velB1 = new Point(-Constants.CELL_SIZE,0);
            }
            // right player 1 bullet
            if (keyboardService.IsKeyDown("l"))
            {
                bullet1.SetText("-");
                bullet1.SetPosition(pos1);
                velB1 = new Point(Constants.CELL_SIZE,0);
            }
            // up player 1 bullet
            if (keyboardService.IsKeyDown("i"))
            {
                bullet1.SetText("|");
                bullet1.SetPosition(pos1);
                velB1 = new Point(0,-Constants.CELL_SIZE);
            }
            // down player 1 bullet
            if (keyboardService.IsKeyDown("k"))
            {
                bullet1.SetText("|");
                bullet1.SetPosition(pos1);
                velB1 = new Point(0,Constants.CELL_SIZE);
            }
            // 45 degree player 1 bullet
            if (keyboardService.IsKeyDown("i") && keyboardService.IsKeyDown("l"))
            {
                // string ball = "\x21D4";
                // string ball = "↑";
                // bullet1.SetText(ball);
                bullet1.SetText("/");
                bullet1.SetPosition(pos1);
                velB1 = new Point(Constants.CELL_SIZE, -Constants.CELL_SIZE);
            }
            // 135 degree player 1 bullet
            if (keyboardService.IsKeyDown("i") && keyboardService.IsKeyDown("j"))
            {
                bullet1.SetText("\\");
                bullet1.SetPosition(pos1);
                velB1 = new Point(-Constants.CELL_SIZE, -Constants.CELL_SIZE);
            }
            // -135 degree player 1 bullet
            if (keyboardService.IsKeyDown("j") && keyboardService.IsKeyDown("k"))
            {
                bullet1.SetText("/");
                bullet1.SetPosition(pos1);
                velB1 = new Point(-Constants.CELL_SIZE, Constants.CELL_SIZE);
            }
            // -45 degree player 1 bullet
            if (keyboardService.IsKeyDown("k") && keyboardService.IsKeyDown("l"))
            {
                bullet1.SetText("\\");
                bullet1.SetPosition(pos1);
                velB1 = new Point(Constants.CELL_SIZE, Constants.CELL_SIZE);
            }

            /////////////////////////////////////////////////////////////////////////////////////////////////

            // left player 2
            if (keyboardService.IsKeyDown("left"))
            {
                velP2 = new Point(-Constants.CELL_SIZE,0);
            }
            // right player 2
            if (keyboardService.IsKeyDown("right"))
            {
                velP2 = new Point(Constants.CELL_SIZE, 0);
            }
            // up player 2
            if (keyboardService.IsKeyDown("up"))
            {
                velP2 = new Point(0, -Constants.CELL_SIZE);
            }
            // down player 2
            if (keyboardService.IsKeyDown("down"))
            {
                velP2 = new Point(0, Constants.CELL_SIZE);
            }
             // left player 1 bullet
            if (keyboardService.IsKeyDown("1"))
            {
                bullet2.SetText("-");
                bullet2.SetPosition(pos2);
                velB2 = new Point(-Constants.CELL_SIZE,0);
            }
            // right player 1 bullet
            if (keyboardService.IsKeyDown("3"))
            {
                bullet2.SetText("-");
                bullet2.SetPosition(pos2);
                velB2 = new Point(Constants.CELL_SIZE,0);
            }
            // up player 1 bullet
            if (keyboardService.IsKeyDown("5"))
            {
                bullet2.SetText("|");
                bullet2.SetPosition(pos2);
                velB2 = new Point(0,-Constants.CELL_SIZE);
            }
            // down player 1 bullet
            if (keyboardService.IsKeyDown("2"))
            {
                bullet2.SetText("|");
                bullet2.SetPosition(pos2);
                velB2 = new Point(0,Constants.CELL_SIZE);
            }
            // 45 degree player 2 bullet
            if (keyboardService.IsKeyDown("5") && keyboardService.IsKeyDown("3"))
            {
                bullet2.SetText("/");
                bullet2.SetPosition(pos2);
                velB2 = new Point(Constants.CELL_SIZE, -Constants.CELL_SIZE);
            }
            // 135 degree player 2 bullet
            if (keyboardService.IsKeyDown("5") && keyboardService.IsKeyDown("1"))
            {
                bullet2.SetText("\\");
                bullet2.SetPosition(pos2);
                velB2 = new Point(-Constants.CELL_SIZE, -Constants.CELL_SIZE);
            }
            // -135 degree player 2 bullet
            if (keyboardService.IsKeyDown("2") && keyboardService.IsKeyDown("1"))
            {
                bullet2.SetText("/");
                bullet2.SetPosition(pos2);
                velB2 = new Point(-Constants.CELL_SIZE, Constants.CELL_SIZE);
            }
            // -45 degree player 2 bullet
            if (keyboardService.IsKeyDown("2") && keyboardService.IsKeyDown("3"))
            {
                bullet2.SetText("\\");
                bullet2.SetPosition(pos2);
                velB2 = new Point(Constants.CELL_SIZE, Constants.CELL_SIZE);
            }

            tank1.SetVelocity(velP1);
            tank2.SetVelocity(velP2);
            bullet1.SetVelocity(velB1);
            bullet2.SetVelocity(velB2);
        }
    }
}