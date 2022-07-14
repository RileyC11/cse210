using System;
using System.Collections.Generic;
using System.Linq;

namespace Frogger.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Cars : Actor
    {
        private List<Actor> carsList = new List<Actor>(); 

        /// <summary>
        /// Constructs a new instance of Cars.
        /// </summary>
        public Cars()
        {
            CreateCars();
        }

        /// <summary>
        /// Gets the cars.
        /// </summary>
        /// <returns>A list of cars as instances of Actors.</returns>
        public List<Actor> GetCars()
        {
            return carsList;
        }


        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void CreateCars()
        {
            for (int i = 0; i < Constants.CARS; i++)
            {
                string text = "8--8";
                int fontSize = Constants.FONT_SIZE;
                Color color = Constants.WHITE;

                Point velocity = new Point(5,0); 

                Random random = new Random();
                int x = random.Next(0,60) * Constants.CELL_SIZE;
                int ymin = random.Next(0,39);
                int y = random.Next(ymin,ymin+10) * Constants.CELL_SIZE;
                Point position = new Point(x,y);

                Actor car = new Actor();
                car.SetPosition(position);
                car.SetVelocity(velocity);
                car.SetText(text);
                car.SetFontSize(fontSize);
                car.SetColor(color);
                carsList.Add(car);
            }
        }
    }
}