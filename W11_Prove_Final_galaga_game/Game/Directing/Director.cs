using System.Collections.Generic;
using W11_Prove_Final_galaga_game.Game.Casting;
using W11_Prove_Final_galaga_game.Game.Services;


namespace W11_Prove_Final_galaga_game.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        private int score = 0;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor bullet = cast.GetFirstActor("bullet");
            Point velBull = keyboardService.GetDirectionBullet();
            // bullet.SetPosition(posRob);
            bullet.SetVelocity(velBull);    

            // Actor robot = cast.GetFirstActor("robot");
            // Point velRob = keyboardService.GetDirectionRobot();
            // robot.SetVelocity(velRob);
            // Point posRob = (Point)robot.GetPosition();

            // Actor bullet = cast.GetFirstActor("bullet");
            // Point velBull = keyboardService.GetDirectionBullet();
            // // bullet.SetPosition(posRob);
            // bullet.SetVelocity(velBull);     
            
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            // Actor bullet = cast.GetFirstActor("bullet");
            List<Actor> artifacts = cast.GetActors("artifacts");

            banner.SetText($"Score: {score}");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            robot.MoveNext(maxX, maxY);

            foreach (Actor actor in artifacts)
            {
                actor.MoveNext(maxX, maxY);

                if (robot.GetPosition().Equals(actor.GetPosition()))
                {
                    Artifact artifact = (Artifact) actor;                 
                    this.score += artifact.GetScore();
                    // cast.RemoveActor("artifacts", actor);
                }
                
                if (actor.GetPosition().GetY() == (maxY-10))
                {
                    Artifact artifact = (Artifact) actor;

                    int x = artifact.GetPosition().GetX();
                    int y = artifact.GetPosition().GetY();

                    Random random = new Random();
                    int randX = random.Next(0, maxX) * 15;   
                    // x = x + randX;

                    Point position = new Point(randX,y);
                    // Point position = new Point(x,y);
                    artifact.SetPosition(position);                    
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}