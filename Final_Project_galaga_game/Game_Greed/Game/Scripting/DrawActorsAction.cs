using System.Collections.Generic;
using FINAL_Project_galaga_game.Game.Casting;
using FINAL_Project_galaga_game.Game.Services;


namespace FINAL_Project_galaga_game.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Operation
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
            Actor ship = (Actor)cast.GetFirstActor("ship");
            Actor score = cast.GetFirstActor("score");
            score.SetPosition(new Point(0,0));

            List<Actor> messages = cast.GetActors("messages");

            videoService.ClearBuffer();
            videoService.DrawActor(ship);
            videoService.DrawActor(score);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}