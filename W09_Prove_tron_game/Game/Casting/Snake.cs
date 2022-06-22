using System;
using System.Collections.Generic;
using System.Linq;

namespace W09_Prove_tron_game.Game.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Snake : Actor
    {
        private List<Actor> segments = new List<Actor>(); 

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Snake(Point position, Color color)
        {
            PrepareBody(position, color);
        }

        // public Snake()
        // {
        //     PrepareBody();
        // }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(Point headPos)
        {
            // int numberOfSegments = segments.Count;
            
            // for (int i = numberOfSegments; i >= 0; i--)
            // {
            Actor head = segments[0];
            Actor firstTail = segments[1];
            Point velocity = head.GetVelocity();
            Point position = head.GetPosition();

            Actor segment = new Actor();
            segment.SetPosition(headPos);
            segment.SetVelocity(new Point(0,0));
            segment.SetText("#");
            // segment.SetColor(Constants.HEAVY_ORANGE);
            segments.Insert(1,segment);
            // }
        }
        /// <inheritdoc/>
        public override void MoveNext()
        {
            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = new Point(0,0);
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            segments[0].SetVelocity(direction);
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        private void PrepareBody(Point position, Color color)
        {
            for (int i = 0; i < 4; i++)
            {               
                Point velocity = new Point(1*Constants.CELL_SIZE, 0);

                int x = position.GetX();
                int y = position.GetY() + 5*i*Constants.CELL_SIZE;
                Point newPosition = new Point(x,y);

                string text = i == 0 ? "8" : "#";

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
            }
        }
    }
}