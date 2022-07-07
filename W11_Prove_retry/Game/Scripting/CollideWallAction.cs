using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using W11_Prove_retry.Game.Casting;
using W11_Prove_retry.Game.Services;
using Raylib_cs;


namespace W11_Prove_retry.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class CollideWallAction : Action
    {
        public bool collision = false;
        public int bounces = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public CollideWallAction()
        {
            this.bounces = 0;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Actor tank1 = (Actor)cast.GetFirstActor("tank1");
            Actor tank2 = (Actor)cast.GetFirstActor("tank2");
            Actor bullet1 = (Actor)cast.GetFirstActor("bullet1");
            Score score1 = (Score)cast.GetFirstActor("score1");
            Score score2 = (Score)cast.GetFirstActor("score2");
            List<Actor> levelOne = cast.GetActors("levelOne");

            Point velB1 = bullet1.GetVelocity();
            int xVelB1 = velB1.GetX();
            int yVelB1 = velB1.GetY();

            Point bullet1Pos = bullet1.GetPosition();
            int bullet1X = bullet1Pos.GetX();
            int bullet1Y = bullet1Pos.GetY();
            Rectangle bullet1Rec = new Rectangle(bullet1X, bullet1Y, Constants.CELL_SIZE, Constants.CELL_SIZE);
            // int bounces = 0;            
            // Console.WriteLine($"HBWC b1 pos {bullet1X} {bullet1Y}");
            foreach (Actor wall in levelOne)
            {
                Point wallPos = wall.GetPosition();
                int wallX = wallPos.GetX();
                int wallY = wallPos.GetY();
                Rectangle wallRec = new Rectangle(wallX, wallY, Constants.CELL_SIZE, Constants.CELL_SIZE);

                if (bounces == 1 && Raylib.CheckCollisionRecs(bullet1Rec, wallRec))
                {
                    Console.WriteLine($"Bounces with one {bounces}");
                    bullet1.SetPosition(new Point(0,0));
                    ControlActorsAction.velB1 = new Point(0,0);
                    bounces = 0;
                    Console.WriteLine($"Bounces reset {bounces}");
                }
                else if (Raylib.CheckCollisionRecs(bullet1Rec, wallRec))
                {
                    if ((yVelB1 == -Constants.CELL_SIZE || yVelB1 == Constants.CELL_SIZE) && xVelB1 == 0)
                    {
                        yVelB1 = yVelB1 * -1;
                    }
                    else if ((xVelB1 == -Constants.CELL_SIZE || xVelB1 == Constants.CELL_SIZE) && yVelB1 == 0)
                    {
                        xVelB1 = xVelB1 * -1;
                    }
                    
                    // {
                    //     xVelB1 = xVelB1 * -1;
                    // }
           
                    else if (xVelB1 == -15 && yVelB1 == 15)
                    {
                        xVelB1 = 15;
                        bullet1.SetText("\\");
                    }
                    else if (xVelB1 == -15 && yVelB1 == -15)
                    {
                        xVelB1 = 15;
                        bullet1.SetText("/");
                    }
                    else if (xVelB1 == 15 && yVelB1 == 15)
                    {
                        xVelB1 = -15;
                        bullet1.SetText("/");
                    }
                    else if (xVelB1 == 15 && yVelB1 == -15)
                    {
                        xVelB1 = -15;
                        bullet1.SetText("\\");
                    }
                    
                    Console.WriteLine($"Bounces with zero {bounces}");
                    bounces = 1;
                    Console.WriteLine($"Bounces add one {bounces}");
                    velB1 = new Point(xVelB1, yVelB1);
                    bullet1.SetVelocity(velB1);
                    ControlActorsAction.velB1 = velB1;
                }
            }        
        }
    }
}