using System;
using System.Collections.Generic;
using System.Linq;

namespace Frogger.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Logs : Actor
    {
        private int score = -100;
        private List<Actor> logsList = new List<Actor>();

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Logs()
        {
            CreateLogs();
        }

        /// <summary>
        /// Gets the list of logs.
        /// </summary>
        /// <returns>A list of logs as instances of Actors.</returns>
        public List<Actor> GetLogs()
        {
            return logsList;
        }

        /// <summary>
        /// Gets the score of a log.
        /// </summary>
        /// <returns>The score as an int.</returns>
        public int GetScore()
        {
            return score;
        }

        public void MoveLogs(Point direction)
        {
            foreach (Actor log in logsList)
            {
                log.SetVelocity(direction);
            }
        }

        /// <summary>
        /// Prepares the logs for moving.
        /// </summary>
        private void CreateLogs()
        {
            for (int i = 0; i < Constants.LOGS; i++)
            {
                string text = "[][][]";
                int fontSize = Constants.FONT_SIZE;
                Color color = Constants.BROWN;

                Point velocity = new Point(3,0); 

                Random random = new Random();
                int x = random.Next(0,60) * Constants.CELL_SIZE;
                int ymin = random.Next(0,39);
                int y = random.Next(ymin,ymin+5) * Constants.CELL_SIZE;
                Point position = new Point(x,y);

                Actor log = new Actor();
                log.SetVelocity(velocity);
                log.SetText(text);
                log.SetFontSize(fontSize);
                log.SetColor(color);
                log.SetPosition(position);

                logsList.Add(log);
            }
        }
    }
}