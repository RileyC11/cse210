using System;
using Microsoft.VisualBasic;
using Frogger.Game.Casting;

namespace Frogger
{
    public class Constants
    {    
        // SCREEN INFO
        public static int FRAME_RATE = 12;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;
        public static int CELL_SIZE = 15;
        public static int FONT_SIZE = 15;
        public static int COLS = 60;
        public static int ROWS = 40;
        public static string CAPTION = "Frogger";

        // COLORS
        public static Color GREEN = new Color(0, 255, 0);
        public static Color WHITE = new Color(225, 255, 225);
        public static Color BROWN = new Color(181, 101, 29);

        // NUMBER LOGS AND CARS
        public static int LOGS = 20;
        public static int CARS = 20;
    }
}