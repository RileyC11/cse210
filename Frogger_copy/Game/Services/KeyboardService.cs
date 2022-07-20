using Raylib_cs;
using Frogger_copy.Game.Casting;

// Created it to where the player can only move left and right, not all four directions

namespace Frogger_copy.Game.Services
{
    /// <summary>
    /// <para>Detects player input.</para>
    /// <para>
    /// The responsibility of a KeyboardService is to detect player key presses and translate them 
    /// into a point representing a direction.
    /// </para>
    /// </summary>
    public class KeyboardService
    {
        private int cellSize = 15;
        // public bool keyPressed = false;

        /// <summary>
        /// Constructs a new instance of KeyboardService using the given cell size.
        /// </summary>
        /// <param name="cellSize">The cell size (in pixels).</param>
        public KeyboardService(int cellSize)
        {
            this.cellSize = cellSize;
        }

        /// <summary>
        /// Gets the selected direction based on the currently pressed keys.
        /// </summary>
        /// <returns>The direction as an instance of Point.</returns>
        public Point GetDirection()
        {
            int dx = 0;
            int dy = 0;
            // keyPressed = false;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                dx = -1;
                // keyPressed = true;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                dx = 1;
                // keyPressed = true;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                dy = -1;
                // keyPressed = true;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                dy = 1;
                // keyPressed = true;
            }

            Point direction = new Point(dx, dy);
            direction = direction.Scale(cellSize);
            // Console.WriteLine(keyPressed);


            return direction;
        }
    }
}
