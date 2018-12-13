using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services.Interfaces
{
    public interface IBoard
    {
        int NoOfRows { get; set; }
        int NoOfColumns { get; set; }
        List<Square> Squares { get; set; }
        List<Square> FindSquares(Coordinate coordinate);
        Square FindSquare(int row, int column);
    }
}
