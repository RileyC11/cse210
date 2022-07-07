using System;
using Pong_copy.Game.Casting;
using Pong_copy.Game.Services;


namespace Pong_copy.Game.Scripting
{
    public class TimedChangeSceneAction : Action
    {
        private string nextScene;
        private double delay;
        private DateTime start;
        
        public TimedChangeSceneAction(string nextScene, double delay, DateTime start)
        {
            this.nextScene = nextScene;
            this.delay = delay;
            this.start = start;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan elapsedTime = currentTime.Subtract(start);
            if (elapsedTime.Seconds > delay)
            {
                callback.OnNext(nextScene);
            }
        }
    }
}