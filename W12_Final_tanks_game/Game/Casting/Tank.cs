using System;
using System.Collections.Generic;
using System.Linq;

namespace W12_Final_tanks_game.Game.Casting
{
    public class Tank : Actor
    {
        private List<Actor> bullets = new List<Actor>();
        public Point pos = new Point(0,0);

        public Tank(Point position, Color color, int player)
        {
            PrepareTank(position, color, player);
        }

        public List<Actor> GetBullets()
        {
            return bullets;
        }

        public void PrepareTank(Point position, Color color, int player)
        {
            Actor tank = new Actor();
            tank.SetPosition(position);
            tank.SetText("#");
            

            if (player == 1)
            {
                tank.SetColor(Constants.HEAVY_ORANGE);
                for (int i = 0; i < 3; i++)
                {
                    Actor bullet = new Actor();
                    bullet.SetColor(Constants.HEAVY_ORANGE);
                    bullets.Add(bullet);
                }
            }
            else
            {
                tank.SetColor(Constants.LIGHT_BLUE);
            }
        }
    }
}