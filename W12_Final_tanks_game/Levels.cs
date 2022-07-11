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
                wall.SetPosition(new Point(285, 120 + i*Constants.CELL_SIZE));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelOne", wall);
            }

            for (int i = 0; i < 8; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(285, 360 + i*Constants.CELL_SIZE));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelOne", wall);
            }

            for (int i = 0; i < 28; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(600, 90 + i*Constants.CELL_SIZE));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelOne", wall);
            }
        }

        public void LevelTwo(Cast cast)
        {
            // Top blocks
            for (int i = 0; i < 30; i++)
            {
                Actor wall = new Actor();
                Point pos = new Point(180 + i*Constants.CELL_SIZE, 135);
                wall.SetPosition(pos);
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelTwo", wall);
            }

            // Middle blocks
            for (int i = 0; i < 9; i++)
            {
                Actor wall = new Actor();
                Point pos = new Point(450, 240 + i*Constants.CELL_SIZE);
                wall.SetPosition(pos);
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelTwo", wall);
            }

            // Bottom blocks
            for (int i = 0; i < 30; i++)
            {
                Actor wall = new Actor();
                wall.SetPosition(new Point(270 + i*Constants.CELL_SIZE, 465));
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelTwo", wall);
            }          
        }

        public void LevelThree(Cast cast)
        {
            // Top horizontal blocks
            for (int i = 0; i < 16; i++)
            {
                Actor wall = new Actor();
                Point pos = new Point(225 + i*Constants.CELL_SIZE, 180);
                wall.SetPosition(pos);
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelThree", wall);
            }

            // Middle vertical blocks
            for (int i = 0; i < 12; i++)
            {
                Actor wall = new Actor();
                Point pos = new Point(450, 195 + i*Constants.CELL_SIZE);
                wall.SetPosition(pos);
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelThree", wall);
            }

            // Bottom horizontal blocks
            for (int i = 0; i < 15; i++)
            {
                Actor wall = new Actor();
                Point pos = new Point(450 + i*Constants.CELL_SIZE, 375);
                wall.SetPosition(pos);
                wall.SetText("[ ]");
                wall.SetColor(Constants.HEAVY_ORANGE);
                cast.AddActor("levelThree", wall);
            }
        }
    }
}

