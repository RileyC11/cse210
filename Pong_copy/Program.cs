using System;
using Pong_copy.Game.Directing;
using Pong_copy.Game.Services;

namespace Pong_copy
{
    public class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director(SceneManager.VideoService);
            director.StartGame();
        }
    }
}
