using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using W12_Final_tanks_game.Game.Casting;
using W12_Final_tanks_game.Game.Services;
using Raylib_cs;


namespace W12_Final_tanks_game.Game.Scripting
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
        private double delay = 5;
        private DateTime start;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public CollideTankAction(DateTime start)
        {
            // this.delay = 5;
            this.start = start;
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

            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(start);

            if (Raylib.CheckCollisionRecs(tank2rec, bullet1rec))
            {
                bullet1.SetText("");
                // bullet1.SetPosition(new Point(0,0));
                ControlActorsAction.velB1 = new Point(0,0);
                // bullet1.SetVelocity(new Point(0,0));
                // if (elapsedTime.Seconds > delay)
                // {
                    bullet1.SetPosition(new Point(0,0));
                    score1.AddPoints(100);
                    lives2.SubtractPoints(1);
                    
                // }
                Constants.LEVEL++;

                if (Constants.LEVEL == 2)
                {
                    tank1.SetPosition(Constants.P1_L2_START_POS);
                    tank2.SetPosition(Constants.P2_L2_START_POS);
                }
                else if (Constants.LEVEL == 3)
                {
                    tank1.SetPosition(Constants.P1_L3_START_POS);
                    tank2.SetPosition(Constants.P2_L3_START_POS);
                }
                
            }

            if (Raylib.CheckCollisionRecs(tank1rec, bullet2rec))
            {
                bullet2.SetText("");
                bullet2.SetPosition(new Point(0,0));
                ControlActorsAction.velB2 = new Point(0,0);
                score2.AddPoints(100);
                lives1.SubtractPoints(1);
                
                Constants.LEVEL++;
                
                if (Constants.LEVEL == 2)
                {
                    tank1.SetPosition(Constants.P1_L2_START_POS);
                    tank2.SetPosition(Constants.P2_L2_START_POS);
                }
                if (Constants.LEVEL == 3)
                {
                    tank1.SetPosition(Constants.P1_L3_START_POS);
                    tank2.SetPosition(Constants.P2_L3_START_POS);
                }
                
            }

            score1.DisplayPoints();
            score2.DisplayPoints();
            lives1.DisplayPoints();
            lives2.DisplayPoints();
        }
    }
}