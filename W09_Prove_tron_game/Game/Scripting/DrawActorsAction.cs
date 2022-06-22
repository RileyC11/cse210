using System.Collections.Generic;
using W09_Prove_tron_game.Game.Casting;
using W09_Prove_tron_game.Game.Services;


namespace W09_Prove_tron_game.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Actions
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
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Snake snake1 = (Snake)cast.GetFirstActor("snake1");
            snake.SetPosition(new Point(300, 300));
            snake1.SetPosition(new Point(600, 300));
            List<Actor> segments = snake.GetSegments();
            List<Actor> segments1 = snake1.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor score1 = cast.GetFirstActor("score1");
            score.SetPosition(new Point(0,0));
            score1.SetPosition(new Point(800,0));
            Actor food = cast.GetFirstActor("food");
            List<Actor> messages = cast.GetActors("messages");
            
            videoService.ClearBuffer();
            videoService.DrawActors(segments);
            videoService.DrawActors(segments1);
            videoService.DrawActor(score);
            videoService.DrawActor(score1);
            videoService.DrawActor(food);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}