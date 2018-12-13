using Battleship.Services;
using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Player Board
            IPlayerBoard playerBoard = new PlayerBoard();

            // Get Parameters to Create a board
            Console.WriteLine("Enter no of rows");
            int.TryParse(Console.ReadLine(), out var rows);
            Console.WriteLine("Enter no of Columns");
            int.TryParse(Console.ReadLine(), out var columns);
            playerBoard.CreateBoard(rows, columns);

            // Get parameters to Add Battleship
            while (true)
            {
                Console.WriteLine("Create Battleship or q to quit");
                if (Console.ReadLine().ToLower() == "q")
                    break;
                Console.WriteLine("Enter Battleship Name");
                string battleshipName = Console.ReadLine();
                Console.WriteLine("Battle ship start position");
                int.TryParse(Console.ReadLine(), out var start);
                Console.WriteLine("Battleship end position");
                int.TryParse(Console.ReadLine(), out var end);
                Console.WriteLine("Battleship alignment 1 for horizantal, or any number for vertical");
                int.TryParse(Console.ReadLine(), out var alignment);
                var align =(alignment == 1) ? Services.Enums.Alignment.Horizantal : Services.Enums.Alignment.Vertical;
                Coordinate coordinate = new Coordinate(start, end, align);
                try
                {
                    playerBoard.AddBattleShip(coordinate, battleshipName);
                }
                catch(IndexOutOfRangeException indexOutOfRangeException)
                {
                    Console.WriteLine(indexOutOfRangeException.Message);
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
                catch (InvalidOperationException invalidOperationException)
                {
                    Console.WriteLine(invalidOperationException.Message);
                }
            }
            while (!playerBoard.GameStatus())
            {
                Console.WriteLine("Enter row to attack");
                int.TryParse(Console.ReadLine(), out var row);
                Console.WriteLine("Enter Column to attack");
                int.TryParse(Console.ReadLine(), out var column);

                var result = playerBoard.Attack(row, column);
                Console.WriteLine(result);
            }
            if (playerBoard.GameStatus() != false)
                Console.WriteLine("Game Over!!!");
            Console.ReadLine();
        }
    }
}
