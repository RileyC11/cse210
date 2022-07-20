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
        public static Color GREEN = new Color(111, 195, 223);
        public static Color WHITE = new Color(225, 255, 225);
        public static Color BROWN = new Color(181, 101, 29);

        // NUMBER LOGS AND CARS
        public static int LOGS = 20;
        public static int CARS = 20;

        // INITIAL DIRECTIONS
        public static Point FROG_DIRECTION = new Point(0,0);
        public static Point LOG_DIRECTION = new Point(3,0);
        public static Point CAR_DIRECTION = new Point(5,0);

    }
}