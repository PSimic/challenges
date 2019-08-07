using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;

namespace TicTacToe
{
    public class Game
    {
        private static string[,] grid = { { "1", "2", "3" }, { "4", "5", "6" }, { "7", "8", "9" } };

        public static void Board()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"       |     |       ");
            Console.WriteLine($"    {grid[0, 0]}  |  {grid[0, 1]}  |  {grid[0, 2]}    ");
            Console.WriteLine($"  _____|_____|_____  ");
            Console.WriteLine($"       |     |       ");
            Console.WriteLine($"    {grid[1, 0]}  |  {grid[1, 1]}  |  {grid[1, 2]}    ");
            Console.WriteLine($"  _____|_____|_____  ");
            Console.WriteLine($"       |     |       ");
            Console.WriteLine($"    {grid[2, 0]}  |  {grid[2, 1]}  |  {grid[2, 2]}    ");
            Console.WriteLine($"       |     |       ");
            Console.WriteLine();
        }

        public static void UserInput(string player)
        {
            Console.WriteLine(player);
            Console.Write("Choose your field number: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    {
                        PlayerDecition(player, 0, 0);
                        break;
                    }
                case "2":
                    {
                        PlayerDecition(player, 0, 1);
                        break;
                    }
                case "3":
                    {
                        PlayerDecition(player, 0, 2);
                        break;
                    }
                case "4":
                    {
                        PlayerDecition(player, 1, 0);
                        break;
                    }
                case "5":
                    {
                        PlayerDecition(player, 1, 1);
                        break;
                    }
                case "6":
                    {
                        PlayerDecition(player, 1, 2);
                        break;
                    }
                case "7":
                    {
                        PlayerDecition(player, 2, 0);
                        break;
                    }
                case "8":
                    {
                        PlayerDecition(player, 2, 1);
                        break;
                    }
                case "9":
                    {
                        PlayerDecition(player, 2, 2);
                        break;
                    }
                case "r":
                    {
                        RestartGame();
                        break;
                    }
                case "q":
                    {
                        Environment.Exit(0);
                        break;
                    }
                default:
                    {
                        throw new Exception("Wrong input.");
                    }
            }
        }

        private static void PlayerDecition(string player, int i, int j)
        {
            if (player.Equals("Player 1") && grid[i, j] != "O" && grid[i, j] != "X")
                grid[i, j] = "O";
            else if (player.Equals("Player 2") && grid[i, j] != "O" && grid[i, j] != "X")
                grid[i, j] = "X";
            else
                throw new Exception("Alredy used field number.");
        }

        private static void RestartGame()
        {
            var fileName = Assembly.GetExecutingAssembly().Location;
            Process.Start(fileName);
            Environment.Exit(0);
        }

        private static bool WeHaveAWinner(out string winner)
        {
            string[] XO = { "X", "O" };

            foreach (var item in XO)
            {
                if (grid[0, 0] == item && grid[0, 1] == item && grid[0, 2] == item ||
                    grid[1, 0] == item && grid[1, 1] == item && grid[1, 2] == item ||
                    grid[2, 0] == item && grid[2, 1] == item && grid[2, 2] == item ||
                    grid[0, 0] == item && grid[1, 0] == item && grid[2, 0] == item ||
                    grid[0, 1] == item && grid[1, 1] == item && grid[2, 1] == item ||
                    grid[0, 2] == item && grid[1, 2] == item && grid[2, 2] == item ||
                    grid[0, 0] == item && grid[1, 1] == item && grid[2, 2] == item ||
                    grid[0, 2] == item && grid[1, 1] == item && grid[2, 0] == item)
                {
                    winner = item;
                    return true;
                }
            }

            winner = "";

            return false;
        }

        public static void Menu()
        {
            int playerNumber = 1;
            string winner = string.Empty;
            int counter = 0;

            do
            {
                if (playerNumber > 2)
                    playerNumber = 1;

                try
                {
                    Board();
                    UserInput($"Player {playerNumber}");
                    Board();

                    playerNumber++;
                    counter++;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message + " Press <ENTER> to try again.");
                    Console.ReadKey();
                }

                if (counter >= 9)
                {
                    Console.WriteLine();
                    Console.WriteLine("Draw game.");
                    break;
                }

            } while (!WeHaveAWinner(out winner));

            if (winner != string.Empty)
            {
                Console.WriteLine();
                if (winner.Equals("O"))
                    Console.WriteLine($"Congratulations!!!\nWinner is Player 1");
                else
                    Console.WriteLine($"Congratulations!!!\nWinner is Player 2");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to restart game.");
            Console.ReadKey();
            RestartGame();
        }
    }
}
