using System;
using Microsoft.VisualBasic;
using W11_Prove_retry.Game.Casting;

namespace W11_Prove_retry
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Levels
    {
        public Levels(Cast cast)
        {
            LevelOne(cast);
            LevelTwo(cast);
            LevelThree(cast);
        }

        public void LevelOne(Cast cast)
        {
            for (int i = 0; i < 8; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(285, 120 + i*15));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelOne", wall);
            }

            for (int i = 0; i < 8; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(285, 360 + i*15));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelOne", wall);
            }

            for (int i = 0; i < 28; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(600, 90 + i*15));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelOne", wall);
            }
        }

        public void LevelTwo(Cast cast)
        {
            for (int i = 0; i < 12; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(180 + i*15, 180));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelTwo", wall);
            }

            for (int i = 0; i < 12; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(225 + i*15, 420));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelTwo", wall);
            }          
        }

        public void LevelThree(Cast cast)
        {
            for (int i = 0; i < 9; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(180 + i*15, 180));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelThree", wall);
            }

            for (int i = 0; i < 6; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(330, 195 + i*15));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelThree", wall);
            }

            for (int i = 0; i < 9; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(330 + i*15, 210));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelThree", wall);
            }
        }
    }
}

