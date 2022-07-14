using System.Collections.Generic;
using Frogger.Game.Casting;
using Frogger.Game.Services;


namespace Frogger.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Frog frog = (Frog)cast.GetFirstActor("frog");

            Logs logs = (Logs)cast.GetFirstActor("logs");
            List<Actor> logsList = logs.GetLogs();

            Cars cars = (Cars)cast.GetFirstActor("cars");
            List<Actor> carsList = cars.GetCars();

            Actor banner = cast.GetFirstActor("banner");
            
            videoService.ClearBuffer();
            videoService.DrawActor(frog);
            videoService.DrawActors(logsList);
            videoService.DrawActors(carsList);
            videoService.DrawActor(banner);
            videoService.FlushBuffer();
        }
    }
}