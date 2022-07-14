using System;


namespace Frogger.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        public int points = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score(string text)
        {
            SetText($"{text}: {this.points}");
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int points)
        {
            this.points += points;
            // SetText($"{text}: {this.points}");
        }

        public void DisplayPoints(string text)
        {
            SetText($"{text}: {this.points}");
        }
    }
}