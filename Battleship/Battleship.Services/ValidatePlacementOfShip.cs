using Battleship.Services.Interfaces;
using Battleship.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Services
{
    public class ValidatePlacementOfShip : IValidatePlacementOfShip
    {
        private bool IsCoordinatesWithInBoardCoordinates(Coordinate coordinate, IBoard board)
        {
            if (coordinate.Alignment == Enums.Alignment.Horizantal && (coordinate.Start > board.NoOfRows || coordinate.End > board.NoOfColumns))
                throw new IndexOutOfRangeException(BattleshipConstants.CoordinatesOutOfIndex);
            else if (coordinate.Alignment == Enums.Alignment.Vertical && (coordinate.Start > board.NoOfRows || coordinate.End > board.NoOfRows))
                throw new IndexOutOfRangeException(BattleshipConstants.CoordinatesOutOfIndex);
            return true;

        }

        private bool IsCoordinateValid(Coordinate coordinate)
        {
            if (coordinate.Start <= 0 || coordinate.End <= 0)
                throw new ArgumentException(BattleshipConstants.CoordinatesAreInvalid);
            return true;
        }

        private bool IsShipOverLaping(List<Square> squares)
        {
            if (squares.Any(square => square.Status == Enums.SquareStatus.occupied))
                throw new InvalidOperationException(BattleshipConstants.ShipOverLaping);
            return true;
        }

        public bool Validate(Coordinate coordinate, IBoard board, List<Square> squares)
        {
            if (IsCoordinateValid(coordinate) && IsCoordinatesWithInBoardCoordinates(coordinate, board) && IsShipOverLaping(squares))
                return true;
            return false;
        }
    }
}
