using System;
using Microsoft.VisualBasic;
using W09_Prove_tron_game.Game.Casting;

namespace W09_Prove_tron_game.Game
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
        public static int SNAKE_LENGTH = 8;

        public static Color RED = new Color(255, 0, 0);
        public static Color ORANGE = new Color(255, 127, 0);
        public static Color YELLOW = new Color(255, 255, 0);
        public static Color GREEN = new Color(0, 255, 0);
        public static Color BLUE = new Color(0, 0, 255);
        public static Color INDIGO = new Color(75, 0, 130);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color LIGHT_BLUE = new Color(111, 195, 223);
        public static Color HEAVY_ORANGE =  new Color(223, 116, 12);
    }
}

