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
    public class CollideBorderAction : Action
    {
        public static bool isGameOver = false;
        public static bool winnerIs1 = false;
        public static bool tie = false;
        public static bool restartGame = false;
        public bool collision = false;
        public int bounces = 0;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public CollideBorderAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Actor bullet1 = (Actor)cast.GetFirstActor("bullet1");
            Point bullet1Pos = bullet1.GetPosition();
            int bullet1X = bullet1Pos.GetX();
            int bullet1Y = bullet1Pos.GetY();

            Actor bullet2 = (Actor)cast.GetFirstActor("bullet1");
            Point bullet2Pos = bullet2.GetPosition();
            int bullet2X = bullet2Pos.GetX();
            int bullet2Y = bullet2Pos.GetY();

            if (bullet1X <= 0)
            {
                bullet1.SetPosition(new Point(0,0));
                ControlActorsAction.velB1 = new Point(0,0);
            }
            else if (bullet1X >= 885)
            {
                bullet1.SetPosition(new Point(0,0));
                ControlActorsAction.velB1 = new Point(0,0);
            }

            if (bullet1Y <=0)
            {
                bullet1.SetPosition(new Point(0,0));
                ControlActorsAction.velB2 = new Point(0,0);
            }
            else if (bullet1Y >= 585 )
            {
                bullet1.SetPosition(new Point(0,0));
                ControlActorsAction.velB1 = new Point(0,0);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        
        public void HandleBulletTankCollision(Cast cast)
        {
            Actor tank1 = (Actor)cast.GetFirstActor("tank1");
            Actor tank2 = (Actor)cast.GetFirstActor("tank2");
            Actor bullet1 = (Actor)cast.GetFirstActor("bullet1");
            Actor bullet2 = (Actor)cast.GetFirstActor("bullet2");
            Score score1 = (Score)cast.GetFirstActor("score1");
            Score score2 = (Score)cast.GetFirstActor("score2");
            Score lives1 = (Score)cast.GetFirstActor("lives1");
            Score lives2 = (Score)cast.GetFirstActor("lives2");

            Point tank1Pos = tank1.GetPosition();
            int tank1X = tank1Pos.GetX();
            int tank1Y = tank1Pos.GetY();
            Rectangle tank1rec = new Rectangle(tank1X, tank1Y, 15, 15);

            Point bullet1Pos = bullet1.GetPosition();
            int bullet1X = bullet1Pos.GetX();
            int bullet1Y = bullet1Pos.GetY();
            Rectangle bullet1rec = new Rectangle(bullet1X, bullet1Y, 15, 15);

            Point tank2Pos = tank2.GetPosition();
            int tank2X = tank2Pos.GetX();
            int tank2Y = tank2Pos.GetY();
            Rectangle tank2rec = new Rectangle(tank2X, tank2Y, 15, 15);

            Point bullet2Pos = bullet2.GetPosition();
            int bullet2X = bullet2Pos.GetX();
            int bullet2Y = bullet2Pos.GetY();
            Rectangle bullet2rec = new Rectangle(bullet2X, bullet2Y, 15, 15);
    
            Console.WriteLine($"HBTC b1 pos {bullet1X} {bullet1Y}");
            Console.WriteLine("Pre collision");

            if (Raylib.CheckCollisionRecs(tank2rec, bullet1rec))
            {
                Console.WriteLine("True tank 2 collision");
                bullet1.SetPosition(new Point(0,0));
                ControlActorsAction.velB1 = new Point(0,0);
                bullet1.SetVelocity(new Point(0,0));
                Random random = new Random();
                tank2X = random.Next(0, 60) * 15;
                tank2Y = random.Next(0, 20) * 15;
                tank2.SetPosition(new Point(tank2X, tank2Y));
                score1.AddPoints(100);
                lives2.SubtractPoints(1);
            }

            if (Raylib.CheckCollisionRecs(tank1rec, bullet2rec))
            {
                Console.WriteLine("True tank 1 collision");
                bullet2.SetPosition(new Point(0,0));
                ControlActorsAction.velB2 = new Point(0,0);
                bullet2.SetVelocity(new Point(0,0));
                Random random = new Random();
                tank1X = random.Next(0, 60) * 15;
                tank1Y = random.Next(0, 20) * 15;
                tank1.SetPosition(new Point(tank1X, tank1Y));
                score2.AddPoints(100);
                lives1.SubtractPoints(1);
            }

            score1.DisplayPoints();
            score2.DisplayPoints();
            lives1.DisplayPoints();
            lives2.DisplayPoints();
        }

        

        
        public void HandleBulletWallCollision(Cast cast)
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

            // Console.WriteLine($"HBWC b1 pos {bullet1X} {bullet1Y}");
            foreach (Actor wall in levelOne)
            {
                

                Point wallPos = wall.GetPosition();
                int wallX = wallPos.GetX();
                int wallY = wallPos.GetY();
                Rectangle wallRec = new Rectangle(wallX, wallY, Constants.CELL_SIZE, Constants.CELL_SIZE);

                // Console.WriteLine($"HBWC b1 pos {bullet1X} {bullet1Y}");

                // if (bounces == 1 && Raylib.CheckCollisionRecs(bullet1Rec, wallRec))
                // {
                //     bullet1.SetPosition(new Point(0,0));
                //     ControlActorsAction.velB1 = new Point(0,0);
                //     bounces = 0;
                //     break;
                // }
                if (Raylib.CheckCollisionRecs(bullet1Rec, wallRec))
                {
                    if ((yVelB1 == -Constants.CELL_SIZE || yVelB1 == Constants.CELL_SIZE) && xVelB1 == 0)
                    {
                        yVelB1 = yVelB1 * -1;
                    }
                    if ((xVelB1 == -Constants.CELL_SIZE || xVelB1 == Constants.CELL_SIZE) && yVelB1 == 0)
                    {
                        xVelB1 = xVelB1 * -1;
                    }
                    
                    // {
                    //     xVelB1 = xVelB1 * -1;
                    // }
           
                    if (xVelB1 == -15 && yVelB1 == 15)
                    {
                        xVelB1 = 15;
                        bullet1.SetText("\\");
                    }
                    if (xVelB1 == -15 && yVelB1 == -15)
                    {
                        xVelB1 = 15;
                        bullet1.SetText("\\");
                    }
                    if (xVelB1 == 15 && yVelB1 == 15)
                    {
                        bullet1.SetText("\\");
                    }
                    if (xVelB1 == 15 && yVelB1 == -15)
                    {
                        bullet1.SetText("/");
                    }
                    
                    bounces += 1;
                    velB1 = new Point(xVelB1, yVelB1);
                    bullet1.SetVelocity(velB1);
                    ControlActorsAction.velB1 = velB1;
                }
            }        
        }

    }
}