using System;


namespace W11_Prove_retry.Game.Casting
{
    /// <summary>
    /// <para>A tasty item that snakes like to eat.</para>
    /// <para>
    /// The responsibility of Food is to select a random position and points that it's worth.
    /// </para>
    /// </summary>
    public class Score : Actor
    {
        public string text = "";
        public int value = 0;

        /// <summary>
        /// Constructs a new instance of an Food.
        /// </summary>
        public Score(string text, int value)
        {
            this.text = text;
            this.value = value;
            SetText($"{text}: {value}");
            AddPoints(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPoints(int value)
        {
            this.value += value;
            // SetText($"{text}: {this.points}");
        }

        public void DisplayPoints()
        {
            SetText($"{this.text}: {this.value}");
        }

        public void SubtractPoints(int value)
        {
            this.value -= value;
        }
    }
}