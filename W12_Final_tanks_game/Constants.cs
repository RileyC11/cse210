using System;
using Microsoft.VisualBasic;
using W12_Final_tanks_game.Game.Casting;

namespace W12_Final_tanks_game
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Constants
    {
        // GAME
        public static string GAME_NAME = "Tanks";
        public static int FRAME_RATE = 15;
        public static bool BOUNCED = false;

        public static int LEVEL = 1;
        public static string LEVEL_ONE = "levelOne";
        public static string LEVEL_TWO = "levelTwo";
        public static string LEVEL_THREE = "levelThree";

        // STARTING POSITIONS
        public static Point P1_L1_START_POS = new Point(30, 300);
        public static Point P1_L2_START_POS = new Point(60, 450);
        public static Point P1_L3_START_POS = new Point(180, 300);
        public static Point P2_L1_START_POS = new Point(870, 300);
        public static Point P2_L2_START_POS = new Point(840, 150);
        public static Point P2_L3_START_POS = new Point(720, 300);

        // SCREEN
        public static int COLUMNS = 40;
        public static int ROWS = 20;
        public static int CELL_SIZE = 15;
        public static int MAX_X = 900;
        public static int MAX_Y = 600;


        // COLORS
        public static Color BLACK = new Color(0, 0, 0);
        public static Color WHITE = new Color(255, 255, 255);
        public static Color PURPLE = new Color(255, 0, 255);
        public static Color LIGHT_BLUE = new Color(111, 195, 223);
        public static Color HEAVY_ORANGE =  new Color(223, 116, 12);

        // SCREEN
        public static int SCREEN_WIDTH = 1040;
        public static int SCREEN_HEIGHT = 680;
        public static int CENTER_X = SCREEN_WIDTH / 2;
        public static int CENTER_Y = SCREEN_HEIGHT / 2;

        // FIELD
        public static int FIELD_TOP = 30;
        public static int FIELD_BOTTOM = SCREEN_HEIGHT;
        public static int FIELD_LEFT = 0;
        public static int FIELD_RIGHT = SCREEN_WIDTH;

        // FONT
        public static string FONT_FILE = "Font/ARIAL.TTF";
        public static int FONT_SIZE = 15;

        // SOUND
        // public static string BOUNCE_SOUND = "Assets/Sounds/boing.wav";
        // public static string WELCOME_SOUND = "Assets/Sounds/start.wav";
        // public static string OVER_SOUND = "Assets/Sounds/over.wav";

        // TEXT
        public static int ALIGN_LEFT = 0;
        public static int ALIGN_CENTER = 1;
        public static int ALIGN_RIGHT = 2;


        // KEYS
        public static string LEFT = "left";
        public static string RIGHT = "right";
        public static string SPACE = "space";
        public static string ENTER = "enter";
        public static string PAUSE = "p";

        // SCENES
        public static string NEW_GAME = "new_game";
        public static string TRY_AGAIN = "try_again";
        public static string NEXT_LEVEL = "next_level";
        public static string IN_PLAY = "in_play";
        public static string GAME_OVER = "game_over";

        // LEVELS
        // public static string LEVEL_FILE = "Assets/Data/level-{0:000}.txt";
        public static int BASE_LEVELS = 5;

        // ----------------------------------------------------------------------------------------- 
        // SCRIPTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // PHASES
        public static string INITIALIZE = "initialize";
        public static string LOAD = "load";
        public static string INPUT = "input";
        public static string UPDATE = "update";
        public static string OUTPUT = "output";
        public static string UNLOAD = "unload";
        public static string RELEASE = "release";

        // ----------------------------------------------------------------------------------------- 
        // CASTING CONSTANTS
        // ----------------------------------------------------------------------------------------- 

        // STATS
        public static string STATS_GROUP = "stats";
        public static int DEFAULT_LIVES = 3;
        // public static int MAXIMUM_LIVES = 5;

        // HUD
        public static int HUD_MARGIN = 15;
        public static string LEVEL_GROUP = "level";
        public static string LIVES_GROUP = "lives";
        public static string SCORE_GROUP = "score";
        public static string LEVEL_FORMAT = "LEVEL: {0}";
        public static string LIVES_FORMAT = "LIVES: {0}";
        public static string SCORE_FORMAT = "SCORE: {0}";

        // BULLET
        public static string BULLET_GROUP = "bullet";
        public static int BULLET_WIDTH = 15;
        public static int BULLET_HEIGHT = 15;
        public static int BULLET_VELOCITY = 0;

        // TANK
        public static string TANK_GROUP = "tank";
        public static int TANK_WIDTH = 106;
        public static int TANK_HEIGHT = 28;
        public static int TANK_VELOCITY = 0;

        // WALL
        public static string WALL_GROUP = "wall";
        public static int WALL_WIDTH = 15;
        public static int WALL_HEIGHT = 15;

        // DIALOG
        public static string DIALOG_GROUP = "dialogs";
        public static string ENTER_TO_START = "PRESS ENTER TO START";
        public static string PREP_TO_LAUNCH = "PREPARING TO LAUNCH";
        public static string WAS_GOOD_GAME = "GAME OVER";

    }
}

