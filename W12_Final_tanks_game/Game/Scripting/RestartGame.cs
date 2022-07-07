// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Threading;
// using W11_Prove_retry.Game.Casting;
// using W11_Prove_retry.Game.Services;
// using W11_Prove_retry.Game.Scripting;


// namespace W11_Prove_retry.Game.Scripting
// {
//     /// <summary>
//     /// <para>An update action that handles interactions between the actors.</para>
//     /// <para>
//     /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
//     /// collides with the food, or the snake collides with its segments, or the game is over.
//     /// </para>
//     /// </summary>
//     public class  RestartGame : Action
//     {
//         private bool isGameOver = false;
//         private bool winnerIs1 = false;
//         private bool winnerTie = false;
//         private bool restart = false;

//         public RestartGame()
//         {   
//         }

//         /// <inheritdoc/>
//         public void Execute(Cast cast, Script script)
//         {
//             this.isGameOver = HandleCollisionsAction.isGameOver;
//             Console.WriteLine($"{isGameOver}");
//             Console.WriteLine($"{restart}");
//             this.restart = HandleCollisionsAction.restartGame;
//             HandleRestart(cast);
//         }

//         public void HandleRestart(Cast cast)
//         {
//             if (restart == true)
//             {
//                 isGameOver = false;
//                 winnerIs1 = false;
//                 winnerTie = false;

//                 Actor snake1 = (Actor)cast.GetFirstActor("snake1");
//                 Actor snake2 = (Actor)cast.GetFirstActor("snake2");
//                 Actor message = (Actor)cast.GetFirstActor("messages");

//                 Thread.Sleep(2000);
//                 message.SetText("");
//                 message.SetPosition(new Point(0,0));
//                 cast.RemoveActor("messages", message);

//                 cast.RemoveActor("snake1", snake1);
//                 cast.RemoveActor("snake2", snake2);

//                 ControlActorsAction.direction1 = Constants.direction1;
//                 ControlActorsAction.direction2 = Constants.direction2;

//                 snake1 = new Actor(Constants.SNAKE1_INT_POS, Constants.HEAVY_ORANGE, Constants.SNAKE1_INT_VEL);
//                 snake2 = new Actor(Constants.SNAKE2_INT_POS, Constants.LIGHT_BLUE, Constants.SNAKE2_INT_VEL);

//                 cast.AddActor("snake1", snake1);
//                 cast.AddActor("snake2", snake2);

//                 isGameOver = false;
//                 HandleCollisionsAction.isGameOver = false;

//                 restart = false;
//                 HandleCollisionsAction.restartGame = false;
//             }
            
//         }
//     }
// }