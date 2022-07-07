namespace W11_Prove_retry.Game.Casting
{
    /// <summary>
    /// A thing that participates in the game.
    /// </summary>
    public class Tank : Actor
    {
        private Body body;
        // private Animation animation;
        
        /// <summary>
        /// Constructs a new instance of Actor.
        /// </summary>
        // public Tank(Body body, Animation animation, bool debug) : base(debug)
        public Tank(Body body, bool debug) : base(debug)
        {
            this.body = body;
            this.animation = animation;
        }

        /// <summary>
        /// Gets the animation.
        /// </summary>
        /// <returns>The animation.</returns>
        // public Animation GetAnimation()
        // {
        //     return animation;
        // }

        /// <summary>
        /// Gets the body.
        /// </summary>
        /// <returns>The body.</returns>
        public Body GetBody()
        {
            return body;
        }

        /// <summary>
        /// Moves the tank to its next position.
        /// </summary>
        public void MoveNext()
        {
            Point position = body.GetPosition();
            Point velocity = body.GetVelocity();
            Point newPosition = position.Add(velocity);
            body.SetPosition(newPosition);
        }

        /// <summary>
        /// Moves the tank left.
        /// </summary>
        public void MoveLeft()
        {
            Point velocity = new Point(-Constants.RACKET_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Moves the tank right.
        /// </summary>
        public void MoveRight()
        {
            Point velocity = new Point(Constants.RACKET_VELOCITY, 0);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Moves the tank up.
        /// </summary>
        public void MoveUp()
        {
            Point velocity = new Point(0, -Constants.RACKET_VELOCITY);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Moves the tank down.
        /// </summary>
        public void MoveDown()
        {
            Point velocity = new Point(0, Constants.RACKET_VELOCITY);
            body.SetVelocity(velocity);
        }

        /// <summary>
        /// Stops the racket from moving.
        /// </summary>
        public void StopMoving()
        {
            Point velocity = new Point(0, 0);
            body.SetVelocity(velocity);
        }
        
    }
}