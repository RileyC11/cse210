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
    public class CollideTankAction : Action
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
        public CollideTankAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
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
    
            if (Raylib.CheckCollisionRecs(tank2rec, bullet1rec))
            {
                bullet1.SetPosition(new Point(0,0));
                ControlActorsAction.velB1 = new Point(0,0);
                bullet1.SetVelocity(new Point(0,0));
                Random random = new Random();
                tank2X = random.Next(0, 60) * 15;
                tank2Y = random.Next(0, 20) * 15;
                tank2.SetPosition(new Point(tank2X, tank2Y));
                score1.AddPoints(100);
                lives2.SubtractPoints(1);
                Constants.LEVEL++;
            }

            if (Raylib.CheckCollisionRecs(tank1rec, bullet2rec))
            {
                bullet2.SetPosition(new Point(0,0));
                ControlActorsAction.velB2 = new Point(0,0);
                bullet2.SetVelocity(new Point(0,0));
                Random random = new Random();
                tank1X = random.Next(0, 60) * 15;
                tank1Y = random.Next(0, 20) * 15;
                tank1.SetPosition(new Point(tank1X, tank1Y));
                score2.AddPoints(100);
                lives1.SubtractPoints(1);
                Constants.LEVEL++;
            }

            score1.DisplayPoints();
            score2.DisplayPoints();
            lives1.DisplayPoints();
            lives2.DisplayPoints();
        }
    }
}