using System.Collections.Generic;
using W09_Prove_cycle_game.Game.Casting;
using W09_Prove_cycle_game.Game.Services;


namespace W09_Prove_cycle_game.Game.Scripting
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
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            snake1.GrowTail(Constants.HEAVY_ORANGE);
            snake1.SetVelocity(new Point(15, 0));
            List<Actor> segments1 = snake1.GetSegments();
            Actor score1 = cast.GetFirstActor("score1");
            score1.SetPosition(new Point(0,0));

            Snake snake2 = (Snake)cast.GetFirstActor("snake2");
            snake2.GrowTail(Constants.LIGHT_BLUE);
            snake2.SetVelocity(new Point(-15, 0));
            List<Actor> segments2 = snake2.GetSegments();
            Actor score2 = cast.GetFirstActor("score2");   
            score2.SetPosition(new Point(800,0));

            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments1);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score1);
            videoService.DrawActor(score2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}