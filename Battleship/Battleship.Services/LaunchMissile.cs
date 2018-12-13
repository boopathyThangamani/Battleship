using Battleship.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services
{
    public class LaunchMissile : ILaunchMissile
    {
        public string Attack(int row, int column, IBoard board)
        {
            var square = board.FindSquare(row, column);
            if (square.Ship != null)
            {
                square.Status = Enums.SquareStatus.hit;
                if (square.Ship.Squares.All(s => s.Status == Enums.SquareStatus.hit))
                    return "Sunk";
            }
            else
                square.Status = Enums.SquareStatus.miss;
            return square.Status.ToString();

        }
    }
}
