// using W09_Prove_cycle_game.Game.Casting;
// using W09_Prove_cycle_game.Game.Directing;
// using W09_Prove_cycle_game.Game.Scripting;
// using W09_Prove_cycle_game.Game.Services;
// using W09_Prove_cycle_game;
// using System.Threading;

// namespace W09_Prove_cycle_game
// {
//     public class Restart : Cast
//     {
//         public bool restartGame = false;

//         public Restart(Cast cast)
//         {
//             RemoveActor(cast);
//             AddActor(cast);
//         }

//         public void RemoveActor(Cast cast)
//         {
//             //Thread.Sleep(1000);
//             Snake snake = (Snake)cast.GetFirstActor("snake");
//             Snake snake1 = (Snake)cast.GetFirstActor("snake1");
//             Actor message = (Actor)cast.GetFirstActor("messages");
//             // Point direction = new Point(1, 0);
//             // Point direction1 = new Point(-15, 0);
//             snake.SetVelocity(Constants.SNAKE_INT_VEL);
//             snake.SetPosition(Constants.SNAKE_INT_POS);
//             snake.SetColor(Constants.HEAVY_ORANGE);

//             snake1.SetVelocity(Constants.SNAKE1_INT_VEL);
//             snake1.SetPosition(Constants.SNAKE1_INT_POS);
//             snake1.SetColor(Constants.LIGHT_BLUE);


//             // cast.RemoveActor("snake", snake);
//             // cast.RemoveActor("snake1", snake1);
//             // cast.RemoveActor("messages", message);

//             // cast.AddActor("snake", new Snake(new Point(45,300), new Color(223, 116, 12), new Point(15, 0)));
//             // cast.AddActor("snake1", new Snake(new Point(855,300), new Color(111, 195, 223), new Point(-15,0)));
//             // Snake snake2 = (Snake)cast.GetFirstActor("snake");
//             // Snake snake3 = (Snake)cast.GetFirstActor("snake1");
//             // snake2.TurnHead(direction);
//             // snake3.TurnHead(direction1);
//             // cast.AddActor("score", new Score("Player 1"));
//             // cast.AddActor("score1", new Score("Player 2"));
//         }

//         public void AddActor(Cast cast);
//         {

//         }
//     }

// }