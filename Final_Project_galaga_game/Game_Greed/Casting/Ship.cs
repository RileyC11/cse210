using System;

namespace Final_Project_galaga_game.Game.Casting
{
    public class Ship : Actor
    {
        public Ship()
        {
        }

        public void Shoot(Cast cast)
        {
            Ship ship = (Ship)cast.GetFirstActor("ship");
            Actor bullet = new Actor();
            Point posBullet = ship.GetPosition();
            Point velBullet = new Point(0,-15);

            bullet.SetPosition(posBullet);
            bullet.SetVelocity(velBullet);
            cast.AddActor("bullet", bullet);
        }

    }
}