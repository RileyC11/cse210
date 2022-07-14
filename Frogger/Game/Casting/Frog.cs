using System;
using System.Collections.Generic;
using System.Linq;

namespace Frogger.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Frog : Actor
    {
        /// <summary>
        /// Constructs a new instance of a Frog.
        /// </summary>
        public Frog()
        {
            PrepareBody();
        }

        /// <summary>
        /// Prepares the frog's body for moving.
        /// </summary>
        private void PrepareBody()
        {
            string text = "#";
            int fontSize = Constants.FONT_SIZE;
            Point position = new Point(Constants.MAX_X / 2, Constants.MAX_Y - Constants.CELL_SIZE);
            Point velocity = new Point(0,0);
            Color color = Constants.GREEN;
            
            Actor frog = new Actor();
            frog.SetText(text);
            frog.SetFontSize(fontSize);
            // frog.SetPosition(position);
            frog.SetPosition(new Point(450,300));
            frog.SetVelocity(velocity);
            frog.SetColor(color);

        }
    }
}