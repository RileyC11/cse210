using System.Collections.Generic;
using Frogger_copy.Game.Casting;
using Frogger_copy.Game.Services;
using Raylib_cs;


namespace Frogger_copy.Game.Directing
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
        private int level = 1;
        private int yMinLogs = 0;
        private int yMinCars = 0;
        private bool gameOver = false;
        private bool logCollision = false;
        private bool carCollision = false;
        private Casting.Color WHITE = new Casting.Color(255,255,255);
        private Casting.Color BROWN = new Casting.Color(150,75,0);
        private Casting.Color RED = new Casting.Color(255,0,0);
        private Casting.Color GREEN = new Casting.Color(144,238,144);


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
            Actor frog = cast.GetFirstActor("frog");
            Point velocity = keyboardService.GetDirection();

            frog.SetVelocity(velocity);          
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            Actor totalScore = cast.GetFirstActor("score");
            Actor levelBanner = cast.GetFirstActor("level");
            Actor frog = cast.GetFirstActor("frog");
            List<Actor> carsList = cast.GetActors("cars");
            List<Actor> logsList = cast.GetActors("logs");

            totalScore.SetText($"Score: {score}");
            levelBanner.SetText($"Level: {level}");

            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            frog.MoveNext(maxX, maxY);

            int frogX = frog.GetPosition().GetX();
            int frogY = frog.GetPosition().GetY();
            Rectangle frogRectangle = new Rectangle(frogX, frogY, 15, 15);

            Random random = new Random();

            Point logVelocity = new Point(0,0);
            foreach (Actor log in logsList)
            {
                log.MoveNext(maxX, maxY);

                int logX = log.GetPosition().GetX();
                int logY = log.GetPosition().GetY();
                Rectangle logRectangle = new Rectangle(logX, logY, 30, 15);

                if (Raylib.CheckCollisionRecs(frogRectangle, logRectangle))
                {
                    Artifact logLog = (Artifact) log;                 
                    this.score += logLog.GetScore();
                    logVelocity = log.GetVelocity();
                    // frog.SetVelocity(logVelocity);

                    // logCollision = true;
                }
                else
                {
                    logCollision = false;
                }
            } 

            foreach (Actor car in carsList)
            {
                car.MoveNext(maxX, maxY);

                int carX = car.GetPosition().GetX();
                int carY = car.GetPosition().GetY();
                Rectangle carRectangle = new Rectangle(carX, carY, 30, 15);

                if (Raylib.CheckCollisionRecs(frogRectangle, carRectangle))
                {
                    Artifact carCar = (Artifact) car;                 
                    this.score += carCar.GetScore();
                    carCollision = true;
                }
            } 

            // Create the new minimum y-level for logs and cars.
            yMinLogs = random.Next(0,32);

            if (yMinLogs <= 20 && yMinLogs >= 8)
            {
                yMinCars = random.Next(0,yMinLogs-7);
            }
            else if (yMinLogs < 8)
            {
                yMinCars = random.Next(yMinLogs+10, 32);
            }
            else if (yMinLogs >= 20 && yMinLogs <= 31)
            {
                yMinCars = random.Next(yMinLogs-10,32);
            }
            else if (yMinLogs > 31)
            {
                yMinCars = random.Next(0,yMinLogs-10);
            }           

            // If the frog hits top of screen, then cars and logs reset and level increases.
            if (frog.GetPosition().GetY() <= 10 && carCollision == false)
            {
                foreach (Actor car in carsList)
                {
                    int x = random.Next(0,60) * 15;
                    int y = random.Next(yMinCars,yMinCars+5) * 15;
                    Point position = new Point(x,y);
                    car.SetPosition(position); 
                    
                    int xVel = car.GetVelocity().GetX() + 1;
                    int yVel = car.GetVelocity().GetY();
                    Point newCarVel = new Point(xVel, yVel);
                    car.SetVelocity(newCarVel);
                }   

                foreach (Actor log in logsList)
                {
                    int x = random.Next(0,60) * 15;
                    int y = random.Next(yMinLogs, yMinLogs+5) * 15;
                    Point position = new Point(x,y);
                    log.SetPosition(position); 

                    int xVel = log.GetVelocity().GetX() + 1;
                    int yVel = log.GetVelocity().GetY();
                    Point newLogVel = new Point(xVel, yVel);
                    log.SetVelocity(newLogVel);  
                }   

                level++;            
            }

            // If the frog hops onto a log, then the frog gets the logs velocity until it hops off.
            if (logCollision)
            {
                frog.SetVelocity(logVelocity);
            }

            // If the frog is hit by a car, then everything becomes white.
            if (carCollision)
            {
                frog.SetColor(WHITE);

                foreach (Actor car in carsList)
                {
                    car.SetColor(WHITE);
                }
                foreach (Actor log in logsList)
                {
                    log.SetColor(WHITE);
                }

                carCollision = false;
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