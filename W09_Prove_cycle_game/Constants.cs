using System;
using Microsoft.VisualBasic;
using W09_Prove_cycle_game.Game.Casting;

namespace W09_Prove_cycle_game
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Constants
    {
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;

        public static int FRAME_RATE = 15;
        public static int FONT_SIZE = 15;
        public static string CAPTION = "Snake";

        public static Color WHITE = new Color(255, 255, 255);
        public static Color LIGHT_BLUE = new Color(111, 195, 223);
        public static Color HEAVY_ORANGE =  new Color(223, 116, 12);

        public static Point SNAKE_INT_POS = new Point(45, 300);
        public static Point SNAKE1_INT_POS = new Point(855, 300);
        public static Point SNAKE_INT_VEL = new Point(15, 0);
        public static Point SNAKE1_INT_VEL = new Point(-15, 0);
    }
}

