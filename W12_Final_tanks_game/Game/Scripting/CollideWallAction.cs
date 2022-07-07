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
        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public CollideWallAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            CollisionTop(cast);
            CollisionBottom(cast);
            CollisionLeft(cast);
            CollisionRight(cast);
        }
        public void CollisionTop(Cast cast)
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

            foreach (Actor wall in levelOne)
            {
                Point wallPos = wall.GetPosition();
                int wallX = wallPos.GetX();
                int wallY = wallPos.GetY();

                if (bullet1Y == wallY - Constants.CELL_SIZE && bullet1X == wallX)
                {
                    // 0 or 180 collision
                    if (xVelB1 == 0 || yVelB1 == 0)
                    {
                        xVelB1 = xVelB1 * -1;
                        yVelB1 = yVelB1 * -1;
                    }

                    // 45 collision
                    else if ((xVelB1 == -15 && yVelB1 == 15))
                    {
                        yVelB1 = yVelB1 * -1;
                        bullet1.SetText("\\");
                    }
                    
                    // 135 collision
                    else if (xVelB1 == 15 && yVelB1 == 15)
                    {
                        yVelB1 = yVelB1 * -1;
                        bullet1.SetText("/");
                    }
                    
                    velB1 = new Point(xVelB1, yVelB1);
                    bullet1.SetVelocity(velB1);
                    ControlActorsAction.velB1 = velB1;
                }
            }        
        }

        public void CollisionBottom(Cast cast)
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

            foreach (Actor wall in levelOne)
            {
                Point wallPos = wall.GetPosition();
                int wallX = wallPos.GetX();
                int wallY = wallPos.GetY();

                if (bullet1Y == wallY + Constants.CELL_SIZE && bullet1X == wallX)
                {
                    // 0 or 180 collision
                    if (xVelB1 == 0 || yVelB1 == 0)
                    {
                        xVelB1 = xVelB1 * -1;
                        yVelB1 = yVelB1 * -1;
                    }

                    // -45 collision
                    else if ((xVelB1 == -15 && yVelB1 == -15))
                    {
                        yVelB1 = yVelB1 * -1;
                        bullet1.SetText("/");
                    }
                    
                    // -135 collision
                    else if (xVelB1 == 15 && yVelB1 == -15)
                    {
                        yVelB1 = yVelB1 * -1;
                        bullet1.SetText("\\");
                    }
                    
                    velB1 = new Point(xVelB1, yVelB1);
                    bullet1.SetVelocity(velB1);
                    ControlActorsAction.velB1 = velB1;
                }
            }
        }

        public void CollisionLeft(Cast cast)
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

            foreach (Actor wall in levelOne)
            {
                Point wallPos = wall.GetPosition();
                int wallX = wallPos.GetX();
                int wallY = wallPos.GetY();

                if (bullet1X == wallX - Constants.CELL_SIZE && bullet1Y == wallY)
                {
                    // 0 or 180 collision
                    if (xVelB1 == 0 || yVelB1 == 0)
                    {
                        xVelB1 = xVelB1 * -1;
                        yVelB1 = yVelB1 * -1;
                    }

                    // 45 collision
                    else if ((xVelB1 == 15 && yVelB1 == -15))
                    {
                        xVelB1 = xVelB1 * -1;
                        bullet1.SetText("\\");
                    }
                    
                    // -45 collision
                    else if (xVelB1 == 15 && yVelB1 == 15)
                    {
                        xVelB1 = xVelB1 * -1;
                        bullet1.SetText("/");
                    }
                    
                    velB1 = new Point(xVelB1, yVelB1);
                    bullet1.SetVelocity(velB1);
                    ControlActorsAction.velB1 = velB1;
                }
            }
        }

        public void CollisionRight(Cast cast)
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

            foreach (Actor wall in levelOne)
            {
                Point wallPos = wall.GetPosition();
                int wallX = wallPos.GetX();
                int wallY = wallPos.GetY();

                if (bullet1X == wallX + Constants.CELL_SIZE && bullet1Y == wallY)
                {
                    // 0 or 180 collision
                    if (xVelB1 == 0 || yVelB1 == 0)
                    {
                        xVelB1 = xVelB1 * -1;
                        yVelB1 = yVelB1 * -1;
                    }

                    // 45 collision
                    else if ((xVelB1 == -15 && yVelB1 == 15))
                    {
                        xVelB1 = xVelB1 * -1;
                        bullet1.SetText("\\");
                    }
                    
                    // -45 collision
                    else if (xVelB1 == -15 && yVelB1 == -15)
                    {
                        xVelB1 = xVelB1 * -1;
                        bullet1.SetText("/");
                    }
                    
                    velB1 = new Point(xVelB1, yVelB1);
                    bullet1.SetVelocity(velB1);
                    ControlActorsAction.velB1 = velB1;
                }
            }
        }
    }
}