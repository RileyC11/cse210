using System.Collections.Generic;
using W12_Final_tanks_game.Game.Casting;
using W12_Final_tanks_game.Game.Services;


namespace W12_Final_tanks_game.Game.Scripting
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
            Actor tank1 = (Actor)cast.GetFirstActor("tank1");
            Actor tank2 = (Actor)cast.GetFirstActor("tank2");
            Actor bullet1 = (Actor)cast.GetFirstActor("bullet1");
            Actor bullet2 = (Actor)cast.GetFirstActor("bullet2");
            List<Actor> levelOne = cast.GetActors("levelOne");
            List<Actor> levelTwo = cast.GetActors("levelTwo");
            List<Actor> levelThree = cast.GetActors("levelThree");
            Actor score1 = cast.GetFirstActor("score1");
            Actor score2 = cast.GetFirstActor("score2");
            Actor lives1 = cast.GetFirstActor("lives1");
            Actor lives2 = cast.GetFirstActor("lives2");

            
            List<Actor> messages = cast.GetActors("messages");
          
            videoService.ClearBuffer();

            // Add some if statements and create different walls to act like different levels
            if (Constants.LEVEL == 1)
            {
                videoService.DrawActors(levelOne);

            }
            else if (Constants.LEVEL == 2)
            {
                videoService.DrawActors(levelTwo);
            }
            else if (Constants.LEVEL == 3)
            {
                videoService.DrawActors(levelThree);
            }
            else if (Constants.LEVEL > 3)
            {
                videoService.CloseWindow();
            }

            videoService.DrawActor(tank1);
            videoService.DrawActor(tank2);
            videoService.DrawActor(bullet1);
            videoService.DrawActor(bullet2);
            videoService.DrawActor(score1);
            videoService.DrawActor(score2);
            videoService.DrawActor(lives1);
            videoService.DrawActor(lives2);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}