// // Author: Riley Corbin
// // Assignment: W01 Prove Tic-Tac-Toe

using System;
using System.Threading;
namespace TicTacToe
{
    class MyAttempt
    {
        static char[] array = {'0','1','2','3','4','5','6','7','8','9'};
        static int player = 1;
        static int choice;
        static int flag = 0;
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Player 1 will be X");
            Console.WriteLine("Player 2 will be O\n");

            while (flag != 1 && flag != -1)
            {
                createBoard();

                if (player % 2 == 0)
                {
                    Console.WriteLine("\nPlayer 2's turn");
                }
                else
                {
                    Console.WriteLine("\nPlayer 1's turn");
                }

                Console.Write("Choose a spot (1-9): ");
                string choiceStr = Console.ReadLine();
                choice = int.Parse(choiceStr);
                Console.WriteLine();

                if (array[choice] != 'X' && array[choice] != 'O' && choice >= 1 && choice <= 9)
                {
                    if (player % 2 == 0)
                    {
                        array[choice] = 'O';
                        player += 1;
                    }
                    else
                    {
                        array[choice] = 'X';
                        player += 1;
                    }
                }
                else if (array[choice] == 'X' || array[choice] == 'O' || choice < 1 || choice > 9)
                {
                    if (array[choice] == 'X' || array[choice] == 'O')
                    {
                        Console.WriteLine($"Sorry, spot {choice} is already marked with {array[choice]}.");
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that is not within the range 1-9.");
                    }
                    Console.WriteLine("Please choose a different spot.");
                }

                flag = checkWinner();
            }
            
            if (flag == 1)
            {
                createBoard();
                if (player % 2 == 0)
                {
                    Console.WriteLine("\nPlayer 1 won!");
                }
                else
                {
                    Console.WriteLine("\nPlayer 2 won!");
                } 
            }
            else
            {
                createBoard();
                Console.WriteLine("\nIt's a draw!");
            }

            
            Console.ReadLine();
            Console.Clear();

        }

        private static void createBoard()
        {
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array[1]}  |  {array[2]}  |  {array[3]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array[4]}  |  {array[5]}  |  {array[6]}  ");
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine($"  {array[7]}  |  {array[8]}  |  {array[9]}  ");
            Console.WriteLine("     |     |     ");

        }

        private static int checkWinner()
        {
            #region Horizontal Winning Condition
            if (array[1] == array[2] && array[2] == array[3])
            {
                return 1;
            }
            else if (array[4] == array[5] && array[5] == array[6])
            {
                return 1;
            }
            else if (array[7] == array[8] && array[8] == array[9])
            {
                return 1;
            }
            #endregion

            #region Vertical Winning Condition
            if (array[1] == array[4] && array[4] == array[7])
            {
                return 1;
            }
            else if (array[2] == array[5] && array[5] == array[8])
            {
                return 1;
            }
            else if (array[3] == array[6] && array[6] == array[9])
            {
                return 1;
            }
            #endregion

            #region Diagonal Winning Condition
            if (array[1] == array [5] && array[5] == array[9])
            {
                return 1;
            }
            else if (array[3] == array[5] && array[5] == array[7])
            {
                return 1;
            }
            #endregion

            #region Check For A Draw
            if (array[1] != '1' && array[2] != '2' && array[3] != '3' && array[4] != '4' && array[5] != '5' && array[6] != '6' && array[7] != '7' && array[8] != '8' && array[9] != '9')
            {
                return -1;
            }
            #endregion

            else
            {
                return 0;
            }

        }
    }
}