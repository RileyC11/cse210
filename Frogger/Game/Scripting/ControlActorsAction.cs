using Frogger.Game.Casting;
using Frogger.Game.Services;
using Frogger.Game.Scripting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Frogger.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        public static Point frog_direction = new Point(0,0);
        public static Point log_direction = new Point(0,0);
        public static Point car_direction = new Point(0,0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            frog_direction = Constants.FROG_DIRECTION;
            log_direction = Constants.LOG_DIRECTION;
            car_direction = Constants.CAR_DIRECTION;

            // left player 1
            if (keyboardService.IsKeyDown("a"))
            {
                Constants.FROG_DIRECTION = new Point(-Constants.CELL_SIZE, 0);
            }

            // right player 1
            if (keyboardService.IsKeyDown("d"))
            {
                Constants.FROG_DIRECTION = new Point(Constants.CELL_SIZE, 0);

            }

            // up player 1
            if (keyboardService.IsKeyDown("w"))
            {
                Constants.FROG_DIRECTION = new Point(0, -Constants.CELL_SIZE);
            }

            // down player 1
            if (keyboardService.IsKeyDown("s"))
            {
                Constants.FROG_DIRECTION = new Point(0, Constants.CELL_SIZE);
            }

            Frog frog = (Frog)cast.GetFirstActor("frog");
            

            Logs logs = (Logs)cast.GetFirstActor("logs");
            List<Actor> logsList = logs.GetLogs();
            foreach (Actor log in logsList)
            {
                log.SetVelocity(Constants.LOG_DIRECTION);
            }

            // Cars cars = (Cars)cast.GetFirstActor("cars");
            // List<Actor> carsList = cars.GetCars();
            // foreach (Actor car in carsList)
            // {
            //     car.DriveCars(Constants.CAR_DIRECTION);
            // }
            // cars.DriveCars(Constants.CAR_DIRECTION);

            List<Actor> carsList = (Actor)cast.GetActors("cars");

        }
    }
}